using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.Business.Handlers.Time;
using ProductCampaignOrder.Infrastructure.Data;
using ProductCampaignOrder.TestHelper;
using System.Threading.Tasks;
using Xunit;

namespace ProductCampaignOrder.Business.Tests.Handlers
{
    public class GetTimeCommandRequestHandlerTests : TestsFor<GetTimeCommandRequestHandler>
    {
        [Fact]
        public async Task HandleAsync_Always_CallsCurrentTimeProvider()
        {
            await Instance.HandleAsync(new GetTimeCommandRequest());

            GetMockFor<ICurrentTimeProvider>().Verify(x => x.NowHour);
        }
    }
}
