using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.Business.Handlers.Order;
using ProductCampaignOrder.Business.Services;
using ProductCampaignOrder.TestHelper;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ProductCampaignOrder.Business.Tests.Handlers
{
    public class CreateOrderCommandRequestHandlerTests : TestsFor<CreateOrderCommandRequestHandler>
    {
        [Fact]
        public async Task HandleAsync_IfNull_ThrowsArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => Instance.HandleAsync(null));
        }

        [Fact]
        public async Task HandleAsync_IfNotNull_CallsProductService()
        {
            var request = new CreateOrderCommandRequest();
            await Instance.HandleAsync(request);

            GetMockFor<IProductService>().Verify(x => x.CreateOrderAsync(request.ProductCode, request.Quantity));
        }
    }
}
