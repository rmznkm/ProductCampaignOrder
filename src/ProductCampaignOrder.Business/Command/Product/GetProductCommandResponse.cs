using ProductCampaignOrder.Model;

namespace ProductCampaignOrder.Business.Command
{
    public class GetProductCommandResponse
    {
        public Product Product { get; set; }

        public override string ToString()
        {
            return $"Product {this.Product.Code} info; " +
                $"price {this.Product.Price}, " +
                $"stock {this.Product.Stock}";
        }
    }
}
