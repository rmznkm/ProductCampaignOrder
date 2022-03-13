using System.Threading.Tasks;

namespace ProductCampaignOrder.Infrastructure.CommandManager
{
    public interface ICommandSender
    {
        Task<TResponse> SendAsync<TResponse>(ICommandRequest<TResponse> request);
    }
}
