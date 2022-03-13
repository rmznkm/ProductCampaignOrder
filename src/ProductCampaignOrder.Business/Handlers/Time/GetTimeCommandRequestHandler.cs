using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.Infrastructure.CommandManager;
using ProductCampaignOrder.Infrastructure.Data;
using System.Threading.Tasks;

namespace ProductCampaignOrder.Business.Handlers.Time
{
    public class GetTimeCommandRequestHandler : ICommandRequestHandler<GetTimeCommandRequest, GetTimeCommandResponse>
    {
        private readonly ICurrentTimeProvider currentTimeProvider;

        public GetTimeCommandRequestHandler(ICurrentTimeProvider currentTimeProvider)
        {
            this.currentTimeProvider = currentTimeProvider;
        }

        public Task<GetTimeCommandResponse> HandleAsync(GetTimeCommandRequest request)
        {
            return Task.FromResult(new GetTimeCommandResponse { NowHour = currentTimeProvider.NowHour });
        }
    }
}
