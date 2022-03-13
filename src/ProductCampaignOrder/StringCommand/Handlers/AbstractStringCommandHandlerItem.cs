using Ardalis.GuardClauses;
using ProductCampaignOrder.Infrastructure.CommandManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCampaignOrder.StringCommand.Manager
{
    public abstract class AbstractStringCommandHandlerItem<TResponse> : IStringCommandHandlerItem
    {
        private readonly ICommandSender commandSender;

        protected AbstractStringCommandHandlerItem(ICommandSender commandSender)
        {
            this.commandSender = commandSender;
        }

        protected abstract ICommandRequest<TResponse> Build(IEnumerable<string> parameters);

        public abstract bool CanHandle(string command);

        public async Task<object> HandleAsync(IEnumerable<string> parameters)
        {
            Guard.Against.Null(parameters, nameof(parameters));
            var validCount = GetParameterValidCount();
            if (parameters.Count() != validCount)
            {
                throw new Exception($"Parameters Count Must Be {validCount}");
            }
            var commandRequest = Build(parameters);
            var result = await commandSender.SendAsync(commandRequest);
            return result;
        }

        protected abstract int GetParameterValidCount();
    }
}
