using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.Infrastructure.CommandManager;
using ProductCampaignOrder.StringCommand.Manager;
using System.Collections.Generic;
using System.Linq;

namespace ProductCampaignOrder.StringCommand.Handlers
{
    public class DecreaseTimeStringCommandHandlerItem : AbstractStringCommandHandlerItem<DecreaseTimeCommandResponse>
    {
        public DecreaseTimeStringCommandHandlerItem(ICommandSender commandSender) : base(commandSender)
        {
        }

        protected override DecreaseTimeCommandRequest Build(IEnumerable<string> parameters)
        {
            var parameterList = parameters.ToList();
            var requestCommand = new DecreaseTimeCommandRequest
            {
                Hour = int.Parse(parameterList[0]),
            };
            return requestCommand;
        }

        public override bool CanHandle(string command)
        {
            return command == "decrease_time";
        }

        protected override int GetParameterValidCount()
        {
            return 1;
        }
    }
}
