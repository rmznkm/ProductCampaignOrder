using Ardalis.GuardClauses;
using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.Business.Services;
using ProductCampaignOrder.Infrastructure.CommandManager;
using ProductCampaignOrder.Infrastructure.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCampaignOrder.Business.Handlers.Campaign
{
    public class GetCampaignCommandRequestHandler : ICommandRequestHandler<GetCampaignCommandRequest, GetCampaignCommandReponse>
    {
        private readonly ICampaignOrderRepository campaignOrderRepository;
        private readonly ICampaignService campaignService;

        public GetCampaignCommandRequestHandler(ICampaignService campaignService,
            ICampaignOrderRepository campaignOrderRepository)
        {
            this.campaignService = campaignService;
            this.campaignOrderRepository = campaignOrderRepository;
        }

        public async Task<GetCampaignCommandReponse> HandleAsync(GetCampaignCommandRequest request)
        {
            Guard.Against.Null(request, nameof(request));
            var campaign = await campaignService.GetAsync(request.CampaignName);
            var orders = await campaignOrderRepository.GetCampingOrdersAsync(request.CampaignName);
           
            var totalSales = 0;
            var avaragePrice = 0;
            if (orders != null && orders.Count > 0)
            {
                totalSales = orders.Count;
                avaragePrice = orders.Sum(x => x.Amount) / orders.Count;
            }

            return new GetCampaignCommandReponse
            {
                Campaign = campaign,
                TotalSales = totalSales,
                AvaragePrice = avaragePrice,
                IsActive = campaignService.IsActive(campaign)
            };
        }
    }
}
