using System;
using System.Threading.Tasks;
using Ardalis.GuardClauses;

namespace ProductCampaignOrder.Infrastructure.CommandManager
{
    public class CommandSender : ICommandSender
    {
        private readonly IServiceProvider serviceProvider;
        public CommandSender(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public Task<TResponse> SendAsync<TResponse>(ICommandRequest<TResponse> request)
        {
            Guard.Against.Null(request, nameof(request));
            var genericHandlerType = typeof(ICommandRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            var handleMethod = genericHandlerType.GetMethod(nameof(ICommandRequestHandler<ICommandRequest<TResponse>, TResponse>.HandleAsync));
            var requestHandler = serviceProvider.GetService(genericHandlerType);
            if (requestHandler is null)
            {
                throw new InvalidOperationException($"{genericHandlerType} not registered !");
            }
            return (Task<TResponse>)handleMethod.Invoke(requestHandler, new[] { request });
        }
    }
}
