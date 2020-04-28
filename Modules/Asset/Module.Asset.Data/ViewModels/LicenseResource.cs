using System;

namespace Module.Asset.Data
{
    public class LicenseResource
    {
        public string Name { get; set; }
        public string ProductKey { get; set; }
        public int Seats { get; set; }
        public string OrderNumber { get; set; }
        public string LicenseToName { get; set; }
        public string LicenseToEmail { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Double PurchaseCost { get; set; }
        public DateTime ExpireDate { get; set; }

        public string Note { get; set; }

        public long CategoryId { get; set; }

        public long ManufacturerId { get; set; }
        public long SupplierId { get; set; }
        public long LocationId { get; set; }
        public long DepreciationId { get; set; }

        public bool IsActive { get; set; }

    }
}