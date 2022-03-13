using ProductCampaignOrder.Model;
using System.Threading.Tasks;

namespace ProductCampaignOrder.Infrastructure.Data
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
    }
}
