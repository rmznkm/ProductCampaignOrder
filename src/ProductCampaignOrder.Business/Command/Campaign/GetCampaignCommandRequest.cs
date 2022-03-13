using ProductCampaignOrder.Infrastructure.CommandManager;

namespace ProductCampaignOrder.Business.Command
{
    public class GetCampaignCommandRequest : ICommandRequest<GetCampaignCommandReponse>
    {
        public string CampaignName { get; set; }
    }
}
