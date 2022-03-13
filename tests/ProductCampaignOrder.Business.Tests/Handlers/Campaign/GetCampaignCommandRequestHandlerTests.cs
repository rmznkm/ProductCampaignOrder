using ProductCampaignOrder.Model;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using ProductCampaignOrder.Business.Handlers.Campaign;
using ProductCampaignOrder.Business.Services;
using ProductCampaignOrder.Infrastructure.Data;
using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.TestHelper;

namespace ProductCampaignOrder.Business.Tests.Handlers
{
    public class GetCampaignCommandRequestHandlerTests : TestsFor<GetCampaignCommandRequestHandler>
    {
        [Fact]
        public async Task HandleAsync_IfNull_ThrowsArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => Instance.HandleAsync(null));
        }

        [Fact]
        public async Task HandleAsync_IfNotNull_CallsCampaignServiceAndCampaignOrderRepository()
        {
            var request = new GetCampaignCommandRequest();
            await Instance.HandleAsync(request);

            GetMockFor<ICampaignService>().Verify(x => x.GetAsync(request.CampaignName));

            GetMockFor<ICampaignOrderRepository>().Verify(x => x.GetCampingOrdersAsync(request.CampaignName));

            GetMockFor<ICampaignService>().Verify(x => x.IsActive(It.IsAny<Campaign>()));
        }
    }
}
