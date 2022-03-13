using ProductCampaignOrder.Model;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;
using ProductCampaignOrder.Infrastructure.Data;
using ProductCampaignOrder.TestHelper;

namespace ProductCampaignOrder.Infrastructure.Tests.Data
{
    public class CampaignInMemoryRepositoryTests : TestsFor<CampaignInMemoryRepository>
    {

        [Fact]
        public async Task AddAsync_IfNull_ThrowsArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => Instance.AddAsync(null));
        }

        [Fact]
        public async Task AddAsync_IfNotExist_Adds()
        {
            var campaign = new Campaign { Name = "C1" };

            await Instance.AddAsync(campaign);
        }

        [Fact]
        public async Task AddAsync_IfAddExist_ThrowsArgumentException()
        {
            var campaign = new Campaign { Name = "C1" };
            await Instance.AddAsync(campaign);

            await Assert.ThrowsAsync<ArgumentException>(() => Instance.AddAsync(campaign));
        }

        [Fact]
        public async Task GetAsync_IfNotExist_ReturnsNull()
        {
            var result = await Instance.GetAsync("C1");

            result.Should().BeNull();
        }

        [Fact]
        public async Task GetAsync_IfExist_Returns()
        {
            var campaign = new Campaign { Name = "C1" };
            await Instance.AddAsync(campaign);

            var result = await Instance.GetAsync("C1");

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetByProductCoodeAsync_Always_ReturnsExistCount()
        {
            var campaign1 = new Campaign { Name = "C1",ProductCode="P1" };
            var campaign2 = new Campaign { Name = "C2",ProductCode="P1" };
            await Instance.AddAsync(campaign1);
            await Instance.AddAsync(campaign2);

            var result = await Instance.GetByProductCoodeAsync("P1");

            result.Count.Should().Be(2);
        }


        [Fact]
        public async Task GetByProductCoodeAsync_Always_ReturnsCorrectName()
        {
            var campaign1 = new Campaign { Name = "C1", ProductCode = "P1" };
            var campaign2 = new Campaign { Name = "C2", ProductCode = "P2" };
            await Instance.AddAsync(campaign1);
            await Instance.AddAsync(campaign2);

            var result = await Instance.GetByProductCoodeAsync("P1");

            foreach (var item in result)
            {
                item.ProductCode.Should().Be("P1");
            }
        }
    }
}
