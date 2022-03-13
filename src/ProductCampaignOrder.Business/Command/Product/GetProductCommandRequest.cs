using ProductCampaignOrder.Infrastructure.CommandManager;

namespace ProductCampaignOrder.Business.Command
{
    public class GetProductCommandRequest : ICommandRequest<GetProductCommandResponse>
    {
        public string ProductCode { get; set; }
    }
}
