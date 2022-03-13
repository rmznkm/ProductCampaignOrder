using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.Infrastructure.CommandManager;
using ProductCampaignOrder.StringCommand.Manager;
using System.Collections.Generic;

namespace ProductCampaignOrder.StringCommand.Handlers
{
    public class GetTimeStringCommandHandlerItem : AbstractStringCommandHandlerItem<GetTimeCommandResponse>
    {
        public GetTimeStringCommandHandlerItem(ICommandSender commandSender) : base(commandSender)
        {
        }

        protected override GetTimeCommandRequest Build(IEnumerable<string> parameters)
        {
            var requestCommand = new GetTimeCommandRequest();
            return requestCommand;
        }

        public override bool CanHandle(string command)
        {
            return command == "get_time";
        }

        protected override int GetParameterValidCount()
        {
            return 0;
        }
    }
}
