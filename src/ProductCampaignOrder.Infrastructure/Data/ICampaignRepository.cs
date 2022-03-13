using ProductCampaignOrder.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductCampaignOrder.Infrastructure.Data
{
    public interface ICampaignRepository
    {
        Task AddAsync(Campaign campaign);     

        Task<Campaign> GetAsync(string campaignName);

        Task<List<Campaign>> GetByProductCoodeAsync(string productCode);       
    }
}
