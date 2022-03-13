using Ardalis.GuardClauses;
using ProductCampaignOrder.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductCampaignOrder.Infrastructure.Data
{
    public class CampaignOrderInMemoryRepository : ICampaignOrderRepository
    {
        private readonly Dictionary<string, List<CampaignOrder>> CampaignOrderStore = new();
        public Task<List<CampaignOrder>> GetCampingOrdersAsync(string campaignName)
        {
            var result = new List<CampaignOrder>();
            if (!CampaignOrderStore.ContainsKey(campaignName))
            {
                return Task.FromResult(result);
            }
            return Task.FromResult(CampaignOrderStore[campaignName]);
        }

        public Task AddOrderAsync(CampaignOrder campaignOrder)
        {
            Guard.Against.Null(campaignOrder, nameof(campaignOrder));
            if (!CampaignOrderStore.ContainsKey(campaignOrder.CampaignName))
            {
                CampaignOrderStore.Add(campaignOrder.CampaignName, new List<CampaignOrder>());
            }
            CampaignOrderStore[campaignOrder.CampaignName].Add(campaignOrder);
            return Task.CompletedTask;
        }

    }
}
