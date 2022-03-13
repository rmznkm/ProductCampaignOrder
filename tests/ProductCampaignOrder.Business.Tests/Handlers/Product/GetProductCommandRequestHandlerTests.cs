using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.Business.Handlers.Product;
using ProductCampaignOrder.Business.Services;
using ProductCampaignOrder.TestHelper;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ProductCampaignOrder.Business.Tests.Handlers
{
    public class GetProductCommandRequestHandlerTests : TestsFor<GetProductCommandRequestHandler>
    {
        [Fact]
        public async Task HandleAsync_IfNull_ThrowsArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => Instance.HandleAsync(null));
        }

        [Fact]
        public async Task HandleAsync_IfNotNull_CallsProductRepository()
        {
            var request = new GetProductCommandRequest();
            await Instance.HandleAsync(request);

            GetMockFor<IProductService>().Verify(x => x.GetByCampaingAsync(request.ProductCode));
        }
    }
}
