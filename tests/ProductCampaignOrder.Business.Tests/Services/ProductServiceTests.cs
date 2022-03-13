using ProductCampaignOrder.Model;
using Moq;
using System.Threading.Tasks;
using Xunit;
using ProductCampaignOrder.Business.Services;
using ProductCampaignOrder.Infrastructure.Data;
using ProductCampaignOrder.TestHelper;

namespace ProductCampaignOrder.Business.Tests.Services
{
    public class ProductServiceTests : TestsFor<ProductService>
    {
        [Theory]
        [InlineData(null, 0)]
        [InlineData(" ", 1)]
        [InlineData("P1", 10)]
        public async Task CreateOrderAsync_Always_CallProductRepositoryAndOrderServiceAndCampaignService(string productCode, int quantity)
        {
            await Instance.CreateOrderAsync(productCode, quantity);

            GetMockFor<IProductRepository>().Verify(x => x.UpdateStockAsync(productCode, quantity));

            GetMockFor<IOrderService>().Verify(x => x.AddOrderAsync(productCode, quantity));

            GetMockFor<ICampaignService>().Verify(x => x.AddOrderAsync(productCode, It.IsAny<int>(), quantity));
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("P1")]
        public async Task GetByCampaingAsync_Always_CallProductRepository(string productCode)
        {
            await Instance.GetByCampaingAsync(productCode);

            GetMockFor<IProductRepository>().Verify(x => x.GetAsync(productCode));
        }

        [Fact]
        public async Task GetByCampaingAsync_IfThereIsProduct_CallCampaignService()
        {
            GetMockFor<IProductRepository>()
                .Setup(x => x.GetAsync("P1"))
                .Returns(Task.FromResult(new Product()));

            await Instance.GetByCampaingAsync("P1");

            GetMockFor<ICampaignService>().Verify(x => x.GetCampaignManipulationRateAsync("P1"));
        }
    }
}
