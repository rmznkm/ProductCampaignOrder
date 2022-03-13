using ProductCampaignOrder.Model;

namespace ProductCampaignOrder.Business.Command
{
    public class CreateOrderCommandResponse
    {
        public Order Order { get; set; }

        public override string ToString()
        {
            return $"Order created; product {this.Order.ProductCode}, quantity {this.Order.Quantity}";
        }
    }
}
