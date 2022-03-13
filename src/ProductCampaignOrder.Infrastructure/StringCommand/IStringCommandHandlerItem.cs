using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductCampaignOrder.StringCommand
{
    public interface IStringCommandHandlerItem
    {        
        bool CanHandle(string command);

        Task<object> HandleAsync(IEnumerable<string> parameters);
    }
}
