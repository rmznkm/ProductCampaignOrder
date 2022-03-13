namespace ProductCampaignOrder.Infrastructure.Data
{
    public interface ICurrentTimeProvider
    {
        public int NowHour { get; }
        void Increase(int hour);
        void Decrease(int hour);
    }
}
