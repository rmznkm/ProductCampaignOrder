namespace ProductCampaignOrder.Model
{
    public class Campaign
    {
        public string Name { get; set; }

        public string ProductCode { get; set; }

        public int Duration { get; set; }

        public int PriceManipulationLimit { get; set; }

        public int TargetSalesCount { get; set; }

        public int StartedAt { get; set; }
    }
}
