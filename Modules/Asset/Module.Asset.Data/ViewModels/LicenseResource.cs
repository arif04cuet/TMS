using System;
using System.Collections.Generic;
using Module.Asset.Entities;

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
        public double PurchaseCost { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Note { get; set; }
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public long ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public long SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public long LocationId { get; set; }

        //public virtual Office Location { get; set; }
        //public long DepreciationId { get; set; }
        public virtual Depreciation Depreciation { get; set; }
        public List<LicenseSeat> SeatList { get; set; }
        public bool IsActive { get; set; }

        public License ToMap(License license = null)
        {
            var entity = license ?? new License();
            entity.Name = Name;
            entity.ProductKey = ProductKey;
            entity.Seats = Seats;
            entity.Available = Seats;
            entity.OrderNumber = OrderNumber;
            entity.LicenseToName = LicenseToName;
            entity.LicenseToEmail = LicenseToEmail;
            entity.PurchaseDate = PurchaseDate;
            entity.PurchaseCost = PurchaseCost;
            entity.ExpireDate = ExpireDate;
            entity.Note = Note;
            entity.CategoryId = CategoryId;
            entity.ManufacturerId = ManufacturerId;
            entity.IsActive = IsActive;
            entity.SupplierId = SupplierId;
            entity.LocationId = LocationId;
            //entity.DepreciationId = DepreciationId;
            return entity;
        }

    }

}


