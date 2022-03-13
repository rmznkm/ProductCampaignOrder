using Ardalis.GuardClauses;
using ProductCampaignOrder.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductCampaignOrder.Infrastructure.Data
{
    public class OrderInMemoryRepository : IOrderRepository
    {
        private readonly List<Order> Store = new();
        public Task AddAsync(Order order)
        {
            Guard.Against.Null(order, nameof(order));
            Store.Add(order);
            return Task.CompletedTask;
        }
    }
}
