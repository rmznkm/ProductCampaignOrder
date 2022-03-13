using Ardalis.GuardClauses;
using ProductCampaignOrder.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductCampaignOrder.Infrastructure.Data
{
    public class CampaignInMemoryRepository : ICampaignRepository
    {
        private readonly Dictionary<string, Campaign> CampaignStore = new();

        public Task AddAsync(Campaign campaign)
        {
            Guard.Against.Null(campaign, nameof(campaign));
            CampaignStore.Add(campaign.Name, campaign);
            return Task.CompletedTask;
        }

        public Task<Campaign> GetAsync(string campaignName)
        {
            if (CampaignStore.ContainsKey(campaignName))
            {
                return Task.FromResult(CampaignStore[campaignName]);
            }

            return Task.FromResult((Campaign)null);
        }

        public Task<List<Campaign>> GetByProductCoodeAsync(string productCode)
        {
            var result = new List<Campaign>();
            foreach (var item in CampaignStore.Values)
            {
                if (item.ProductCode == productCode)
                {
                    result.Add(item);
                }
            }
            return Task.FromResult(result);
        }
    }
}
