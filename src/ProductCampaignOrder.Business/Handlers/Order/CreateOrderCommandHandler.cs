using Ardalis.GuardClauses;
using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.Business.Services;
using ProductCampaignOrder.Infrastructure.CommandManager;
using System.Threading.Tasks;

namespace ProductCampaignOrder.Business.Handlers.Order
{
    public class CreateOrderCommandRequestHandler : ICommandRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IProductService productService;

        public CreateOrderCommandRequestHandler(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<CreateOrderCommandResponse> HandleAsync(CreateOrderCommandRequest request)
        {
            Guard.Against.Null(request, nameof(request));
            await productService.CreateOrderAsync(request.ProductCode, request.Quantity);
            return new CreateOrderCommandResponse { Order = null };
        }
    }
}
