using ProductCampaignOrder.Model;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using ProductCampaignOrder.Business.Services;
using ProductCampaignOrder.Infrastructure.Data;
using ProductCampaignOrder.TestHelper;

namespace ProductCampaignOrder.Business.Tests.Services
{
    public class CampaignServiceTests : TestsFor<CampaignService>
    {
        [Fact]
        public async Task AddOrderAsync_IfThereIsNoActiveCampaign_NotCallCampaignOrderRepository()
        {
            GetMockFor<ICampaignRepository>()
                .Setup(x => x.GetByProductCoodeAsync(It.IsAny<string>()))
                .Returns(Task.FromResult<List<Campaign>>(null));

            await Instance.AddOrderAsync("P1", 50, 50);

            GetMockFor<ICampaignOrderRepository>().Verify(x => x.AddOrderAsync(It.IsAny<CampaignOrder>()), Times.Never);
        }

        [Fact]
        public async Task AddOrderAsync_IfThereIsActiveCampaign_CallCampaignOrderRepository()
        {
            GetMockFor<ICampaignRepository>()
                .Setup(x => x.GetByProductCoodeAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new List<Campaign> {
                    new Campaign
                    {
                        Name="C1",
                        ProductCode="P1",
                        Duration=10
                    }
                }));

            await Instance.AddOrderAsync("P1", 50, 50);

            GetMockFor<ICampaignOrderRepository>().Verify(x => x.AddOrderAsync(It.IsAny<CampaignOrder>()));
        }

        [Fact]
        public void IsActive_IfGreaterOrEqualThenNow_ReturnTrue()
        {
            var result = Instance.IsActive(new Campaign { Duration = 1 });

            result.Should().BeTrue();
        }

        [Fact]
        public void IsActive_IfLessThenNow_ReturnFalse()
        {
            GetMockFor<ICurrentTimeProvider>()
                  .Setup(x => x.NowHour)
                  .Returns(10);

            var result = Instance.IsActive(new Campaign { Duration = 1 });

            result.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("C1")]
        public async Task GetAsync_Always_CallCampaignRepository(string campaignName)
        {
            await Instance.GetAsync(campaignName);

            GetMockFor<ICampaignRepository>().Verify(x => x.GetAsync(campaignName));
        }

        [Fact]
        public async Task GetCampaignManipulationRateAsync_IfThereIsNoActiveCampaign_ReturnsNull()
        {
            GetMockFor<ICampaignRepository>()
                .Setup(x => x.GetByProductCoodeAsync(It.IsAny<string>()))
                .Returns(Task.FromResult<List<Campaign>>(null));

            var result = await Instance.GetCampaignManipulationRateAsync("P1");

            result.Should().BeNull();
        }

        [Fact]
        public async Task GetCampaignManipulationRateAsync_IfReachedTargetSalesCount_ReturnsNull()
        {
            GetMockFor<ICampaignRepository>()
                  .Setup(x => x.GetByProductCoodeAsync(It.IsAny<string>()))
                  .Returns(Task.FromResult(new List<Campaign> {
                    new Campaign
                    {
                        Name="C1",
                        ProductCode="P1",
                        TargetSalesCount=1,
                        Duration=10
                    }
                  }));

            GetMockFor<ICampaignOrderRepository>()
                 .Setup(x => x.GetCampingOrdersAsync(It.IsAny<string>()))
                 .Returns(Task.FromResult(new List<CampaignOrder> { new CampaignOrder() }));

            var result = await Instance.GetCampaignManipulationRateAsync("P1");

            result.Should().BeNull();
        }

        [Fact]
        public async Task GetCampaignManipulationRateAsync_IfDurationExpired_ReturnsNull()
        {
            GetMockFor<ICampaignRepository>()
                  .Setup(x => x.GetByProductCoodeAsync(It.IsAny<string>()))
                  .Returns(Task.FromResult(new List<Campaign> {
                    new Campaign
                    {
                        Name="C1",
                        ProductCode="P1",
                        TargetSalesCount=10,
                        Duration=10
                    }
                  }));

            GetMockFor<ICampaignOrderRepository>()
                 .Setup(x => x.GetCampingOrdersAsync(It.IsAny<string>()))
                 .Returns(Task.FromResult(new List<CampaignOrder> { new CampaignOrder() }));

            GetMockFor<ICurrentTimeProvider>()
                .Setup(x => x.NowHour)
                .Returns(20);

            var result = await Instance.GetCampaignManipulationRateAsync("P1");

            result.Should().BeNull();
        }

        [Fact]
        public async Task GetCampaignManipulationRateAsync_IfReturnResult_MustBeLessThan1()
        {
            GetMockFor<ICampaignRepository>()
                  .Setup(x => x.GetByProductCoodeAsync(It.IsAny<string>()))
                  .Returns(Task.FromResult(new List<Campaign> {
                    new Campaign
                    {
                        Name="C1",
                        ProductCode="P1",
                        TargetSalesCount=10,
                        Duration=10
                    }
                  }));

            GetMockFor<ICampaignOrderRepository>()
                 .Setup(x => x.GetCampingOrdersAsync(It.IsAny<string>()))
                 .Returns(Task.FromResult(new List<CampaignOrder> { new CampaignOrder() }));

            GetMockFor<ICurrentTimeProvider>()
                .Setup(x => x.NowHour)
                .Returns(5);

            var result = await Instance.GetCampaignManipulationRateAsync("P1");

            result.Should().BeLessOrEqualTo(1);
            result.Should().BeGreaterOrEqualTo(0);
        }
    }
}
