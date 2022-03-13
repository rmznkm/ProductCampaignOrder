using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.Infrastructure.CommandManager;
using ProductCampaignOrder.StringCommand.Manager;
using System.Collections.Generic;
using System.Linq;

namespace ProductCampaignOrder.StringCommand.Handlers
{
    public class CreateOrderStringCommandHandlerItem : AbstractStringCommandHandlerItem<CreateOrderCommandResponse>
    {
        public CreateOrderStringCommandHandlerItem(ICommandSender commandSender) : base(commandSender)
        {
        }

        protected override CreateOrderCommandRequest Build(IEnumerable<string> parameters)
        {
            var parameterList = parameters.ToList();
            var requestCommand = new CreateOrderCommandRequest
            {
                ProductCode = parameterList[0],
                Quantity = int.Parse(parameterList[1])
            };
            return requestCommand;
        }

        public override bool CanHandle(string command)
        {
            return command == "create_order";
        }

        protected override int GetParameterValidCount()
        {
            return 2;
        }
    }
}
