using ProductCampaignOrder.Infrastructure.CommandManager;

namespace ProductCampaignOrder.Business.Command
{
    public class CreateOrderCommandRequest : ICommandRequest<CreateOrderCommandResponse>
    {
        public string ProductCode { get; set; }

        public int Quantity { get; set; }
    }
}
