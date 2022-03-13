using System.Threading.Tasks;

namespace ProductCampaignOrder.Infrastructure.CommandManager
{
    public interface ICommandRequestHandler<TRequest, TResult> where TRequest : ICommandRequest<TResult>
    {
        Task<TResult> HandleAsync(TRequest request);
    }
}
