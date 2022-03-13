using Ardalis.GuardClauses;
using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.Infrastructure.CommandManager;
using ProductCampaignOrder.Infrastructure.Data;
using System.Threading.Tasks;

namespace ProductCampaignOrder.Business.Handlers.Time
{
    public class DecreaseTimeCommandRequestHandler : ICommandRequestHandler<DecreaseTimeCommandRequest, DecreaseTimeCommandResponse>
    {
        private readonly ICurrentTimeProvider currentTimeProvider;

        public DecreaseTimeCommandRequestHandler(ICurrentTimeProvider currentTimeProvider)
        {
            this.currentTimeProvider = currentTimeProvider;
        }

        public Task<DecreaseTimeCommandResponse> HandleAsync(DecreaseTimeCommandRequest request)
        {
            Guard.Against.Null(request, nameof(request));
            currentTimeProvider.Decrease(request.Hour);
            return Task.FromResult(new DecreaseTimeCommandResponse { NowHour = currentTimeProvider.NowHour });
        }
    }
}
