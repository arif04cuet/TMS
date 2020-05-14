using System;

namespace Module.Asset.Data
{
    public class LicenseReportViewModel
    {
        public string License { get; set; }
        public string ProductKey { get; set; }
        public int Seats { get; set; }
        public int RemainingSeats { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PurchaseCost { get; set; }
        public string Depreciation { get; set; }
        public string Value { get; set; }
        public string Diff { get; set; }
    }
}
