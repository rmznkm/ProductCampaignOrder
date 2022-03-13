using ProductCampaignOrder.Model;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using ProductCampaignOrder.Business.Handlers.Product;
using ProductCampaignOrder.Infrastructure.Data;
using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.TestHelper;

namespace ProductCampaignOrder.Business.Tests.Handlers
{
    public class CreateProductCommandRequestHandlerTests : TestsFor<CreateProductCommandRequestHandler>
    {
        [Fact]
        public async Task HandleAsync_IfNull_ThrowsArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => Instance.HandleAsync(null));
        }

        [Fact]
        public async Task HandleAsync_IfNotNull_CallsProductRepository()
        {
            var request = new CreateProductCommandRequest();
            await Instance.HandleAsync(request);

            GetMockFor<IProductRepository>().Verify(x => x.AddAsync(It.IsAny<Product>()));
        }
    }
}
