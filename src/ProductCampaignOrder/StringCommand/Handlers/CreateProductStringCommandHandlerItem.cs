using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.Infrastructure.CommandManager;
using ProductCampaignOrder.StringCommand.Manager;
using System.Collections.Generic;
using System.Linq;

namespace ProductCampaignOrder.StringCommand.Handlers
{
    public class CreateProductStringCommandHandlerItem : AbstractStringCommandHandlerItem<CreateProductCommandResponse>
    {
        public CreateProductStringCommandHandlerItem(ICommandSender commandSender) : base(commandSender)
        {
        }

        protected override CreateProductCommandRequest Build(IEnumerable<string> parameters)
        {
            var parameterList = parameters.ToList();
            var requestCommand = new CreateProductCommandRequest
            {
                ProductCode = parameterList[0],
                Price = int.Parse(parameterList[1]),
                Stock = int.Parse(parameterList[2])
            };
            return requestCommand;
        }

        public override bool CanHandle(string command)
        {
            return command == "create_product";
        }

        protected override int GetParameterValidCount()
        {
            return 3;
        }
    }
}
