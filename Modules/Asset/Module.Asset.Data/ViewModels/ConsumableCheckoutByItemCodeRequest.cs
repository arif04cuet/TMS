
namespace Module.Asset.Data
{
    public class ConsumableCheckoutByItemCodeRequest
    {
        public long ItemCodeId { get; set; }
        public long UserId { get; set; }
        public string Note { get; set; }
        public int Quantity { get; set; }
    }
}
