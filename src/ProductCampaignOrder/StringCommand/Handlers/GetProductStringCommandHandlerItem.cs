using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.Infrastructure.CommandManager;
using ProductCampaignOrder.StringCommand.Manager;
using System.Collections.Generic;
using System.Linq;

namespace ProductCampaignOrder.StringCommand.Handlers
{
    public class GetProductStringCommandHandlerItem : AbstractStringCommandHandlerItem<GetProductCommandResponse>
    {
        public GetProductStringCommandHandlerItem(ICommandSender commandSender) : base(commandSender)
        {
        }

        protected override GetProductCommandRequest Build(IEnumerable<string> parameters)
        {
            var parameterList = parameters.ToList();
            var requestCommand = new GetProductCommandRequest
            {
                ProductCode = parameterList[0]
            };
            return requestCommand;
        }

        public override bool CanHandle(string command)
        {
            return command == "get_product_info";
        }

        protected override int GetParameterValidCount()
        {
            return 1;
        }
    }
}
