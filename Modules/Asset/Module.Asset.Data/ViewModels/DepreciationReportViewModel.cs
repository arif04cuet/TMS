using System;

namespace Module.Asset.Data
{
    public class DepreciationReportViewModel
    {
        public string Asset { get; set; }
        public string Serial { get; set; }
        public string DepreciationName { get; set; }
        public int NumberOfMonths { get; set; }
        public AssetCheckoutViewModel CheckedOut { get; set; }
        public string Location { get; set; }
        public DateTime? Purchased { get; set; }
        public DateTime? EOL { get; set; }
        public string Cost { get; set; }
        public string Value { get; set; }
        public string Diff { get; set; }
    }
}
