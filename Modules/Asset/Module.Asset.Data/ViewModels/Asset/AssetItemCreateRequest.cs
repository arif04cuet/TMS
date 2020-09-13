namespace Module.Asset.Data
{
    public class AssetItemCreateRequest
    {
        public long AssetModel { get; set; }
        public string AssetTag { get; set; }
        public long Status { get; set; }
        public string ItemNo { get; set; }
        public double PurchaseCost { get; set; }
        public int Warranty { get; set; }
        public int Maintenance { get; set; }
        public int Eol { get; set; }
        public bool IsRequestable { get; set; }
        public long? Media { get; set; }
    }
}
