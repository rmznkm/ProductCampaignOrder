using ProductCampaignOrder.Model;
using System.Threading.Tasks;

namespace ProductCampaignOrder.Infrastructure.Data
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);

        Task UpdateStockAsync(string productCode, int quantity);

        Task<Product> GetAsync(string productCode);
    }
}
