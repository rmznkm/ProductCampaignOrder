using Ardalis.GuardClauses;
using ProductCampaignOrder.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductCampaignOrder.Infrastructure.Data
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private readonly Dictionary<string, Product> Store = new();
        public Task AddAsync(Product product)
        {
            Guard.Against.Null(product, nameof(product));
            Store.Add(product.Code, product);
            return Task.CompletedTask;
        }

        public Task<Product> GetAsync(string productCode)
        {
            if (Store.ContainsKey(productCode))
            {
                return Task.FromResult(Store[productCode]);
            }

            return Task.FromResult((Product)null);
        }

        public Task UpdateStockAsync(string productCode, int quantity)
        {
            if (!Store.ContainsKey(productCode))
            {
                throw new Exception("ProductCodeNotFound");
            }

            var product = Store[productCode];
            if (product.Stock < quantity)
            {
                throw new Exception("StockIsNotEnough");
            }

            product.Stock -= quantity;

            return Task.CompletedTask;
        }
    }
}
