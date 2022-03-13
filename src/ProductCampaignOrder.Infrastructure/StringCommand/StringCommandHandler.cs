using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCampaignOrder.StringCommand
{
    public class StringCommandHandler : IStringCommandHandler
    {
        private readonly IEnumerable<IStringCommandHandlerItem> handlerItems;

        public StringCommandHandler(IEnumerable<IStringCommandHandlerItem> handlerItems)
        {
            this.handlerItems = handlerItems;
        }

        public Task<object> HandleAsync(string command)
        {
            Guard.Against.Null(command, nameof(command));
            var commandItems = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var operation = commandItems[0];
            foreach (var handler in handlerItems)
            {
                if (!handler.CanHandle(operation))
                {
                    continue;
                }

                return handler.HandleAsync(commandItems.TakeLast(commandItems.Length - 1));
            }

            throw new Exception("HandlerNotFound");
        }
    }
}
