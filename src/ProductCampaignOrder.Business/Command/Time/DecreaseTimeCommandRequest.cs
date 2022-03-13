using ProductCampaignOrder.Infrastructure.CommandManager;

namespace ProductCampaignOrder.Business.Command
{
    public class DecreaseTimeCommandRequest : ICommandRequest<DecreaseTimeCommandResponse>
    {
        public int Hour { get; set; }
    }
}
