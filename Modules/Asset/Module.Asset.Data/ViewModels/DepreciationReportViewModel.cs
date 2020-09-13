namespace Module.Asset.Data
{
    public class DepreciationReportViewModel
    {
        public string AssetName { get; set; }
        public long AssetId { get; set; }
        public long DepreciationId { get; set; }
        public double Price { get; set; }
        public int EOL { get; set; }
        public int DepreciationFrequency { get; set; }
        public float DepreciationRate { get; set; }
        public float DepreciationValue { get; set; }
        public string Status { get; set; }
    }
}
