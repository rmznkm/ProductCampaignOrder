using Ardalis.GuardClauses;
using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.Infrastructure.CommandManager;
using ProductCampaignOrder.Infrastructure.Data;
using System.Threading.Tasks;

namespace ProductCampaignOrder.Business.Handlers.Time
{
    public class IncreaseTimeCommandRequestHandler : ICommandRequestHandler<IncreaseTimeCommandRequest, IncreaseTimeCommandResponse>
    {
        private readonly ICurrentTimeProvider currentTimeProvider;

        public IncreaseTimeCommandRequestHandler(ICurrentTimeProvider currentTimeProvider)
        {
            this.currentTimeProvider = currentTimeProvider;
        }

        public Task<IncreaseTimeCommandResponse> HandleAsync(IncreaseTimeCommandRequest request)
        {
            Guard.Against.Null(request, nameof(request));
            currentTimeProvider.Increase(request.Hour);
            return Task.FromResult(new IncreaseTimeCommandResponse { NowHour = currentTimeProvider.NowHour });
        }
    }
}
