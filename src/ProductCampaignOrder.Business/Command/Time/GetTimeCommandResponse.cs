namespace ProductCampaignOrder.Business.Command
{
    public class GetTimeCommandResponse
    {
        public int NowHour { get; set; }

        public override string ToString()
        {
            return $"Time is {this.NowHour}";
        }
    }
}
