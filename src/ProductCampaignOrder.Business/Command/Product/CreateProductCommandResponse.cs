using ProductCampaignOrder.Model;

namespace ProductCampaignOrder.Business.Command
{
    public class CreateProductCommandResponse
    {
        public Product Product { get; set; }

        public override string ToString()
        {
            return $"Procut created; code {this.Product.Code}, " +
                $"price {this.Product.Price}, " +
                $"stock {this.Product.Stock}";
        }
    }
}
