using Ardalis.GuardClauses;
using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.Business.Services;
using ProductCampaignOrder.Infrastructure.CommandManager;
using System.Threading.Tasks;

namespace ProductCampaignOrder.Business.Handlers.Product
{
    public class GetProductCommandRequestHandler : ICommandRequestHandler<GetProductCommandRequest, GetProductCommandResponse>
    {
        private readonly IProductService productService;
        public GetProductCommandRequestHandler(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<GetProductCommandResponse> HandleAsync(GetProductCommandRequest request)
        {
            Guard.Against.Null(request, nameof(request));
            var product = await productService.GetByCampaingAsync(request.ProductCode);
            return new GetProductCommandResponse { Product = product };
        }
    }
}
