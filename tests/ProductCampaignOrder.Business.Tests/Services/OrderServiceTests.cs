using ProductCampaignOrder.Model;
using Moq;
using System.Threading.Tasks;
using Xunit;
using ProductCampaignOrder.Business.Services;
using ProductCampaignOrder.Infrastructure.Data;
using ProductCampaignOrder.TestHelper;

namespace ProductCampaignOrder.Business.Tests.Services
{
    public class OrderServiceTests : TestsFor<OrderService>
    {
        [Theory]
        [InlineData(null, 0)]
        [InlineData(" ", 1)]
        [InlineData("P1", 10)]
        public async Task AddOrderAsync_Always_CallOrderRepository(string productCode, int quantity)
        {
            await Instance.AddOrderAsync(productCode, quantity);

            GetMockFor<IOrderRepository>().Verify(x => x.AddAsync(It.IsAny<Order>()));
        }
    }
}
