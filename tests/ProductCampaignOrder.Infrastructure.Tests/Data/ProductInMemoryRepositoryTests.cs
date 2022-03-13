using ProductCampaignOrder.Model;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;
using ProductCampaignOrder.Infrastructure.Data;
using ProductCampaignOrder.TestHelper;

namespace ProductCampaignOrder.Infrastructure.Tests.CommandManager
{
    public class ProductInMemoryRepositoryTests : TestsFor<ProductInMemoryRepository>
    {

        [Fact]
        public async Task AddAsync_IfNull_ThrowsArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => Instance.AddAsync(null));
        }

        [Fact]
        public async Task AddAsync_IfNotExist_Adds()
        {
            var product = new Product { Code = "P1" };

            await Instance.AddAsync(product);
        }

        [Fact]
        public async Task AddAsync_IfAddExist_ThrowsArgumentException()
        {
            var product = new Product { Code = "P1" };
            await Instance.AddAsync(product);

            await Assert.ThrowsAsync<ArgumentException>(() => Instance.AddAsync(product));
        }

        [Fact]
        public async Task GetAsync_IfNotExist_ReturnsNull()
        {
            var result = await Instance.GetAsync("P1");

            result.Should().BeNull();
        }

        [Fact]
        public async Task GetAsync_IfExist_Returns()
        {
            var product = new Product { Code = "P1" };
            await Instance.AddAsync(product);

            var result = await Instance.GetAsync("P1");

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateStockAsync_IfNotExist_ThrowsException()
        {
            await Assert.ThrowsAsync<Exception>(() => Instance.UpdateStockAsync("P1", 20));
        }

        [Fact]
        public async Task UpdateStockAsync_IfNotEnoughStock_ThrowsException()
        {
            var product = new Product { Code = "P1" };
            await Instance.AddAsync(product);

            await Assert.ThrowsAsync<Exception>(() => Instance.UpdateStockAsync("P1", 20));
        }

        [Fact]
        public async Task UpdateStockAsync_IfEnoughStock_Updates()
        {
            var product = new Product { Code = "P1", Stock = 10 };
            await Instance.AddAsync(product);

            await Instance.UpdateStockAsync("P1", 5);
        }
    }
}
