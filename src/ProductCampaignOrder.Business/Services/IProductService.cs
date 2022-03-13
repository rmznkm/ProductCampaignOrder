using ProductCampaignOrder.Model;
using System.Threading.Tasks;

namespace ProductCampaignOrder.Business.Services
{
    public interface IProductService
    {
        Task<Product> GetByCampaingAsync(string productCode);

        Task CreateOrderAsync(string productCode, int quantity);
    }
}
