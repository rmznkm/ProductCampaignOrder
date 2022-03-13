using ProductCampaignOrder.Model;

namespace ProductCampaignOrder.Business.Command
{
    public class GetCampaignCommandReponse
    {
        public Campaign Campaign { get; set; }

        public int TotalSales { get; set; }

        public int AvaragePrice { get; set; }

        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"Campaign {this.Campaign.Name} info; " +
                $"is active " + (this.IsActive ? "Available" : "Ended") +
                $"target sales count {this.Campaign.TargetSalesCount}, " +
                $"total sales {this.TotalSales}, " +
                $"avarage price {this.AvaragePrice}, ";
        }
    }
}
