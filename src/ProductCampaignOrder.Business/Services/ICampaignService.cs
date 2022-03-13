using ProductCampaignOrder.Model;
using System.Threading.Tasks;

namespace ProductCampaignOrder.Business.Services
{
    public interface ICampaignService
    {
        bool IsActive(Campaign campaign);

        Task<int?> GetCampaignManipulationRateAsync(string productCode);

        Task AddOrderAsync(string productCode, int amount, int quantity);

        Task<Campaign> GetAsync(string campaignName);
    }
}
