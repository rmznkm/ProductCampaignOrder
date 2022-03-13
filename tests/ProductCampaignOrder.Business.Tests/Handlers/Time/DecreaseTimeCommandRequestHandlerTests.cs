using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using ProductCampaignOrder.Business.Handlers.Time;
using ProductCampaignOrder.Infrastructure.Data;
using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.TestHelper;

namespace ProductCampaignOrder.Business.Tests.Handlers
{
    public class DecreaseTimeCommandRequestHandlerTests : TestsFor<DecreaseTimeCommandRequestHandler>
    {
        [Fact]
        public async Task HandleAsync_IfNull_ThrowsArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => Instance.HandleAsync(null));
        }

        [Fact]
        public async Task HandleAsync_IfNotNull_CallsCurrentTimeProvider()
        {
            await Instance.HandleAsync(new DecreaseTimeCommandRequest());

            GetMockFor<ICurrentTimeProvider>().Verify(x => x.Decrease(It.IsAny<int>()));

            GetMockFor<ICurrentTimeProvider>().Verify(x => x.NowHour);
        }
    }
}
