using ProductCampaignOrder.Model;
using System.Threading.Tasks;

namespace ProductCampaignOrder.Business.Services
{
    public interface IOrderService
    {
        Task<Order> AddOrderAsync(string productCode, int quantity);
    }
}
