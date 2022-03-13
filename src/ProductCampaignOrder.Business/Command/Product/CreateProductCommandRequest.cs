using ProductCampaignOrder.Infrastructure.CommandManager;

namespace ProductCampaignOrder.Business.Command
{
    public class CreateProductCommandRequest : ICommandRequest<CreateProductCommandResponse>
    {
        public string ProductCode { get; set; }

        public int Price { get; set; }

        public int Stock { get; set; }
    }
}
