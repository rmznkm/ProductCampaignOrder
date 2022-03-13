using ProductCampaignOrder.Infrastructure.CommandManager;

namespace ProductCampaignOrder.Business.Command
{
    public class IncreaseTimeCommandRequest : ICommandRequest<IncreaseTimeCommandResponse>
    {
        public int Hour { get; set; }
    }
}
