using ProductCampaignOrder.Model;

namespace ProductCampaignOrder.Business.Command
{
    public class CreateCampaignCommandResponse
    {
        public Campaign Campaign { get; set; }

        public override string ToString()
        {
            return $"Campaign created; name {this.Campaign.Name}, " +
                $"product {this.Campaign.ProductCode}, " +
                $"duration {this.Campaign.Duration}, " +
                $"limit {this.Campaign.PriceManipulationLimit}, " +
                $"target sales count {this.Campaign.TargetSalesCount}";
        }
    }
}
