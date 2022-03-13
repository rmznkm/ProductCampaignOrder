using ProductCampaignOrder.Model;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using ProductCampaignOrder.Business.Handlers.Campaign;
using ProductCampaignOrder.Infrastructure.Data;
using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.TestHelper;

namespace ProductCampaignOrder.Business.Tests.Handlers
{
    public class CreateCampaignCommandRequestHandlerTests : TestsFor<CreateCampaignCommandRequestHandler>
    {
        [Fact]
        public async Task HandleAsync_IfNull_ThrowsArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => Instance.HandleAsync(null));
        }

        [Fact]
        public async Task HandleAsync_IfNotNull_CallsCampaignRepository()
        {
            await Instance.HandleAsync(new CreateCampaignCommandRequest());

            GetMockFor<ICampaignRepository>().Verify(x => x.AddAsync(It.IsAny<Campaign>()));
        }
    }
}
