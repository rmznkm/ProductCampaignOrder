using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.Infrastructure.CommandManager;
using ProductCampaignOrder.StringCommand.Manager;
using System.Collections.Generic;
using System.Linq;

namespace ProductCampaignOrder.StringCommand.Handlers
{
    public class GetCampaignStringCommandHandlerItem : AbstractStringCommandHandlerItem<GetCampaignCommandReponse>
    {
        public GetCampaignStringCommandHandlerItem(ICommandSender commandSender) : base(commandSender)
        {
        }

        protected override GetCampaignCommandRequest Build(IEnumerable<string> parameters)
        {
            var parameterList = parameters.ToList();
            var requestCommand = new GetCampaignCommandRequest
            {
                CampaignName = parameterList[0]
            };
            return requestCommand;
        }

        public override bool CanHandle(string command)
        {
            return command == "get_campaign_info";
        }

        protected override int GetParameterValidCount()
        {
            return 1;
        }
    }
}
