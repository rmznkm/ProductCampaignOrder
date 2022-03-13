using ProductCampaignOrder.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductCampaignOrder.Infrastructure.Data
{
    public interface ICampaignOrderRepository
    {
        Task AddOrderAsync(CampaignOrder campaignOrder);

        Task<List<CampaignOrder>> GetCampingOrdersAsync(string campaignName);
    }
}
