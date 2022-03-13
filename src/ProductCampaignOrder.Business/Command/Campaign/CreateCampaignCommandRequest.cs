using ProductCampaignOrder.Infrastructure.CommandManager;

namespace ProductCampaignOrder.Business.Command
{
    public class CreateCampaignCommandRequest : ICommandRequest<CreateCampaignCommandResponse>
    {
        public string CampaignName { get; set; }

        public string ProductCode { get; set; }

        public int Duration { get; set; }

        public int PriceManipulationLimit { get; set; }

        public int TargetSalesCount { get; set; }
    }
}
