using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.Infrastructure.CommandManager;
using ProductCampaignOrder.StringCommand.Manager;
using System.Collections.Generic;
using System.Linq;

namespace ProductCampaignOrder.StringCommand.Handlers
{
    public class IncreaseTimeStringCommandHandlerItem : AbstractStringCommandHandlerItem<IncreaseTimeCommandResponse>
    {
        public IncreaseTimeStringCommandHandlerItem(ICommandSender commandSender) : base(commandSender)
        {
        }

        protected override IncreaseTimeCommandRequest Build(IEnumerable<string> parameters)
        {
            var parameterList = parameters.ToList();
            var requestCommand = new IncreaseTimeCommandRequest
            {
                Hour = int.Parse(parameterList[0]),
            };
            return requestCommand;
        }

        public override bool CanHandle(string command)
        {
            return command == "increase_time";
        }

        protected override int GetParameterValidCount()
        {
            return 1;
        }
    }
}
