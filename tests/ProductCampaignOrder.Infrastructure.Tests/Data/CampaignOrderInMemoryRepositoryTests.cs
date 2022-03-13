using ProductCampaignOrder.Model;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;
using ProductCampaignOrder.Infrastructure.Data;
using ProductCampaignOrder.TestHelper;

namespace ProductCampaignOrder.Infrastructure.Tests.Data
{
    public class CampaignOrderInMemoryRepositoryTests : TestsFor<CampaignOrderInMemoryRepository>    
    {
        [Fact]
        public async Task AddOrderAsync_IfNull_ThrowsArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => Instance.AddOrderAsync(null));
        }

        [Fact]
        public async Task AddOrderAsync_IfNotNull_Adds()
        {
            var campaignOrder = new CampaignOrder { CampaignName = "C1" };
            await Instance.AddOrderAsync(campaignOrder);
        }

        [Fact]
        public async Task GetAsync_IfExist_ReturnCount()
        {
            var campaignOrder1 = new CampaignOrder { CampaignName = "C1" };
            var campaignOrder2 = new CampaignOrder { CampaignName = "C1" };
            await Instance.AddOrderAsync(campaignOrder1);
            await Instance.AddOrderAsync(campaignOrder2);

            var result = await Instance.GetCampingOrdersAsync("C1");

            result.Count.Should().Be(2);
        }

        [Fact]
        public async Task GetAsync_IfExist_ReturnExactName()
        {
            var campaignOrder1 = new CampaignOrder { CampaignName = "C1" };
            var campaignOrder2 = new CampaignOrder { CampaignName = "C2" };
            await Instance.AddOrderAsync(campaignOrder1);
            await Instance.AddOrderAsync(campaignOrder2);

            var result = await Instance.GetCampingOrdersAsync("C1");
            foreach (var item in result)
            {
                item.CampaignName.Should().Be("C1");
            }
        }
    }
}
