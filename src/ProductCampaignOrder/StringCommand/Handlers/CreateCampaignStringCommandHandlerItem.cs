using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.Infrastructure.CommandManager;
using ProductCampaignOrder.StringCommand.Manager;
using System.Collections.Generic;
using System.Linq;

namespace ProductCampaignOrder.StringCommand.Handlers
{
    public class CreateCampaignStringCommandHandlerItem : AbstractStringCommandHandlerItem<CreateCampaignCommandResponse>
    {
        public CreateCampaignStringCommandHandlerItem(ICommandSender commandSender) : base(commandSender)
        {
        }

        protected override CreateCampaignCommandRequest Build(IEnumerable<string> parameters)
        {
            var parameterList = parameters.ToList();
            var requestCommand = new CreateCampaignCommandRequest
            {
                CampaignName = parameterList[0],
                ProductCode = parameterList[1],
                Duration = int.Parse(parameterList[2]),
                PriceManipulationLimit = int.Parse(parameterList[3]),
                TargetSalesCount = int.Parse(parameterList[4])
            };
            return requestCommand;
        }

        public override bool CanHandle(string command)
        {
            return command == "create_campaign";
        }

        protected override int GetParameterValidCount()
        {
            return 5;
        }
    }
}
