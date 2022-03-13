using ProductCampaignOrder.Infrastructure.Data;
using ProductCampaignOrder.Model;
using System.Threading.Tasks;

namespace ProductCampaignOrder.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IOrderService orderService;
        private readonly ICampaignService campaignService;

        public ProductService(IProductRepository productRepository,
            ICampaignService campaignService,
            IOrderService orderService)
        {
            this.orderService = orderService;
            this.productRepository = productRepository;
            this.campaignService = campaignService;
        }

        public async Task CreateOrderAsync(string productCode, int quantity)
        {
            var calculatedAmount = await CalculateCurrentAmount(productCode);

            await productRepository.UpdateStockAsync(productCode, quantity);

            await orderService.AddOrderAsync(productCode, quantity);

            await campaignService.AddOrderAsync(productCode, calculatedAmount, quantity);
        }

        public async Task<Product> GetByCampaingAsync(string productCode)
        {
            var product = await productRepository.GetAsync(productCode);
            if (product is null)
            {
                return product;
            }
            var manipulationRate = await campaignService.GetCampaignManipulationRateAsync(productCode);
            if (manipulationRate != null && manipulationRate.Value > 0)
            {
                return new Product
                {
                    Code = product.Code,
                    Stock = product.Stock,
                    Price = product.Price * (100 - manipulationRate.Value) / 100
                };
            }

            return product;
        }

        private async Task<int> CalculateCurrentAmount(string productCode)
        {
            var product = await GetByCampaingAsync(productCode);
            return product is null ? 0 : product.Price;
        }
    }
}
