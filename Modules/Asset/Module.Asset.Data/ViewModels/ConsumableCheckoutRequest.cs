
namespace Module.Asset.Data
{
    public class ConsumableCheckoutRequest
    {
        public long ConsumableId { get; set; }
        public long UserId { get; set; }
        public string Note { get; set; }
        public int Quantity { get; set; }
    }
}
