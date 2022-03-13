using ProductCampaignOrder.Infrastructure.Data;
using ProductCampaignOrder.Model;
using System.Threading.Tasks;

namespace ProductCampaignOrder.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly ICurrentTimeProvider currentTimeProvider;

        public OrderService(IOrderRepository orderRepository, ICurrentTimeProvider currentTimeProvider)
        {
            this.orderRepository = orderRepository;
            this.currentTimeProvider = currentTimeProvider;
        }

        public async Task<Order> AddOrderAsync(string productCode, int quantity)
        {
            var order = new Order { ProductCode = productCode, Quantity = quantity, OrderAt = currentTimeProvider.NowHour };
            await orderRepository.AddAsync(order);
            return order;
        }
    }
}
