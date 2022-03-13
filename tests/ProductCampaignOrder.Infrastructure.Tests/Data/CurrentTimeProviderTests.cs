using FluentAssertions;
using ProductCampaignOrder.Infrastructure.Data;
using ProductCampaignOrder.TestHelper;
using Xunit;

namespace ProductCampaignOrder.Tests.Data
{
    public class CurrentTimeProviderTests : TestsFor<CurrentTimeProvider>
    {
        [Fact]
        public void Now_Always_StartsByZero()
        {
            var now = Instance.NowHour;
            now.Should().Be(0);
        }

        [Fact]
        public void Increase_Always_IncreaseHour()
        {
            Instance.Increase(5);
            var now = Instance.NowHour;
            now.Should().Be(5);
        }

        [Fact]
        public void Decrease_Always_DecreaseHour()
        {
            Instance.Decrease(5);
            var now = Instance.NowHour;
            now.Should().Be(-5);
        }
    }
}
