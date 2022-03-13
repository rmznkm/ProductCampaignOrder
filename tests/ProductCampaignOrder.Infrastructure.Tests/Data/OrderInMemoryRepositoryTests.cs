using ProductCampaignOrder.Infrastructure.Data;
using ProductCampaignOrder.Model;
using ProductCampaignOrder.TestHelper;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ProductCampaignOrder.Infrastructure.Tests.Data
{
    public class OrderInMemoryRepositoryTests : TestsFor<OrderInMemoryRepository>
    {

        [Fact]
        public async Task AddAsync_IfNull_ThrowsArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => Instance.AddAsync(null));
        }

        [Fact]
        public async Task AddAsync_IfNotNull_Adds()
        {
            var order = new Order();
            await Instance.AddAsync(order);
        }
    }
}
