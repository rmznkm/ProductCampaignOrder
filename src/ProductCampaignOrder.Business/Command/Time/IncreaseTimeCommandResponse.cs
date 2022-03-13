namespace ProductCampaignOrder.Business.Command
{
    public class IncreaseTimeCommandResponse
    {
        public int NowHour { get; set; }

        public override string ToString()
        {
            return $"Time is {this.NowHour}";
        }
    }
}
