using System.Threading.Tasks;

namespace ProductCampaignOrder.StringCommand
{
    public interface IStringCommandHandler
    {
        Task<object> HandleAsync(string command);
    }
}
