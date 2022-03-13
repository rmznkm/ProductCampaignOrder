using Ardalis.GuardClauses;
using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.Infrastructure.CommandManager;
using ProductCampaignOrder.Infrastructure.Data;
using System.Threading.Tasks;

namespace ProductCampaignOrder.Business.Handlers.Campaign
{
    public class CreateCampaignCommandRequestHandler : ICommandRequestHandler<CreateCampaignCommandRequest, CreateCampaignCommandResponse>
    {
        private readonly ICampaignRepository campaignRepository;
        private readonly ICurrentTimeProvider currentTimeProvider;

        public CreateCampaignCommandRequestHandler(ICampaignRepository campaignRepository, ICurrentTimeProvider currentTimeProvider)
        {
            this.campaignRepository = campaignRepository;
            this.currentTimeProvider = currentTimeProvider;
        }

        public async Task<CreateCampaignCommandResponse> HandleAsync(CreateCampaignCommandRequest request)
        {
            Guard.Against.Null(request, nameof(request));
            var campaign = new Model.Campaign
            {
                Name = request.CampaignName,
                ProductCode = request.ProductCode,
                Duration = request.Duration,
                PriceManipulationLimit = request.PriceManipulationLimit,
                TargetSalesCount = request.TargetSalesCount,
                StartedAt = currentTimeProvider.NowHour
            };
            await campaignRepository.AddAsync(campaign);
            return new CreateCampaignCommandResponse { Campaign = campaign };
        }
    }
}
