using ProductCampaignOrder.Infrastructure.Data;
using ProductCampaignOrder.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCampaignOrder.Business.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository campaignRepository;
        private readonly ICampaignOrderRepository campaignOrderRepository;
        private readonly ICurrentTimeProvider currentTimeProvider;

        public CampaignService(ICampaignRepository campaignRepository, ICampaignOrderRepository campaignOrderRepository, ICurrentTimeProvider currentTimeProvider)
        {
            this.campaignRepository = campaignRepository;
            this.campaignOrderRepository = campaignOrderRepository;
            this.currentTimeProvider = currentTimeProvider;
        }

        public async Task AddOrderAsync(string productCode, int amount, int quantity)
        {
            var campaign = await GetActiveCampaignAsync(productCode);
            if (campaign is null)
            {
                return;
            }

            var campaignOrder = new CampaignOrder { CampaignName = campaign.Name, Amount = amount, Quantity = quantity };
            await campaignOrderRepository.AddOrderAsync(campaignOrder);
        }

        public bool IsActive(Campaign campaign)
        {
            var nowHour = currentTimeProvider.NowHour;
            var result = (campaign.StartedAt + campaign.Duration) >= nowHour;
            return result;
        }

        private async Task<Campaign> GetActiveCampaignAsync(string productCode)
        {
            var campaigns = await campaignRepository.GetByProductCoodeAsync(productCode);

            if (campaigns is null || campaigns.Count < 1)
            {
                return null;
            }

            var nowHour = currentTimeProvider.NowHour;
            var result = campaigns.FirstOrDefault(x => (x.StartedAt + x.Duration) >= nowHour);
            return result;
        }

        public async Task<int?> GetCampaignManipulationRateAsync(string productCode)
        {
            var campaign = await GetActiveCampaignAsync(productCode);
            if (campaign is null)
            {
                return null;
            }

            var campaignOrders = await campaignOrderRepository.GetCampingOrdersAsync(campaign.Name);
            var availiableCountRatio =(double) (campaign.TargetSalesCount - campaignOrders?.Count) / campaign.TargetSalesCount;
            if (availiableCountRatio <= 0)
            {
                return null;
            }

            var nowHour = currentTimeProvider.NowHour;
            var availableDurationRatio = (double)((campaign.StartedAt + campaign.Duration)-nowHour) / campaign.Duration;
            if (availableDurationRatio < 0)
            {
                //aktifleri aldığı için buna gerek yok aslında
                return null;
            }

            var availableRatio = (1.0 - availableDurationRatio) * availiableCountRatio;
            if (availableRatio > 1.0)
            {
                //burda bir terslik var loglanmalı
                return null;
            }

            int result = (int)Math.Round(availableRatio * campaign.PriceManipulationLimit);
            return result;
        }

        public Task<Campaign> GetAsync(string campaignName)
        {
            return campaignRepository.GetAsync(campaignName);
        }
    }
}
