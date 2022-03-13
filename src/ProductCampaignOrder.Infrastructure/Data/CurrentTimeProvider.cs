namespace ProductCampaignOrder.Infrastructure.Data
{
    public class CurrentTimeProvider : ICurrentTimeProvider
    {
        private int hourManupulation;
        private readonly int startTime;

        public CurrentTimeProvider()
        {
            startTime = 0;
        }

        public int NowHour => startTime + hourManupulation;

        public void Decrease(int hour)
        {
            hourManupulation -= hour;
        }

        public void Increase(int hour)
        {
            hourManupulation += hour;
        }
    }
}
