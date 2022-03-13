using Ardalis.GuardClauses;
using ProductCampaignOrder.Business.Command;
using ProductCampaignOrder.Infrastructure.CommandManager;
using ProductCampaignOrder.Infrastructure.Data;
using System.Threading.Tasks;

namespace ProductCampaignOrder.Business.Handlers.Product
{
    public class CreateProductCommandRequestHandler : ICommandRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductRepository productRespository;

        public CreateProductCommandRequestHandler(IProductRepository productRespository)
        {
            this.productRespository = productRespository;
        }

        public async Task<CreateProductCommandResponse> HandleAsync(CreateProductCommandRequest request)
        {
            Guard.Against.Null(request, nameof(request));
            var product = new Model.Product { Code = request.ProductCode, Stock = request.Stock, Price = request.Price };
            await productRespository.AddAsync(product);
            return new CreateProductCommandResponse { Product = product };
        }
    }
}
