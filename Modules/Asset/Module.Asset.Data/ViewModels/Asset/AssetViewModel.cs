using Module.Core.Data;
using Module.Core.Shared;
using System;
using System.Linq.Expressions;

namespace Module.Asset.Data
{
    public class AssetViewModel
    {
        public long Id { get; set; }
        public string AssetTag { get; set; }
        public string Barcode { get; set; }
        public IdNameViewModel AssetModel { get; set; }
        public IdNameViewModel Status { get; set; }
        public string ItemNo { get; set; }
        public string Name { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? InventoryEntryDate { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public IdNameViewModel Supplier { get; set; }
        public string OrderNo { get; set; }
        public string InvoiceNo { get; set; }
        public double PurchaseCost { get; set; }
        public int Warranty { get; set; }
        public int Maintenance { get; set; }
        public string Note { get; set; }
        public bool IsRequestable { get; set; }
        public IdNameViewModel Location { get; set; }
        public string Photo { get; set; }
        public IdNameViewModel CheckoutToUser { get; set; }
        public IdNameViewModel CheckoutToLocation { get; set; }
        public IdNameViewModel CheckoutToAsset { get; set; }
        public AssetCategoryViewModel Category { get; set; }
        public long? CheckoutId { get; set; }
        public int EOL { get; set; }

        public double? WarrantyRemainingInDays { get; set; }
        public double? MaintenanceRemainingInDays { get; set; }

        public static Expression<Func<Entities.Asset, AssetViewModel>> Select(IMediaService mediaService)
        {
            return x => new AssetViewModel
            {
                Id = x.Id,
                Name = x.Name,
                PurchaseDate = x.PurchaseDate,
                PurchaseCost = x.PurchaseCost,
                Note = x.Note,
                Supplier = x.SupplierId != null ? new IdNameViewModel { Id = x.Supplier.Id, Name = x.Supplier.Name } : null,
                Location = x.LocationId != null ? new IdNameViewModel { Id = x.Location.Id, Name = x.Location.OfficeName } : null,
                AssetModel = new IdNameViewModel { Id = x.AssetModel.Id, Name = x.AssetModel.Name },
                IsRequestable = x.IsRequestable,
                ItemNo = x.ItemNo,
                OrderNo = x.OrderNo,
                InvoiceNo = x.InvoiceNo,
                Status = new IdNameViewModel { Id = x.Status.Id, Name = x.Status.Name },
                Warranty = x.Warranty,
                Maintenance = x.Maintenance,
                AssetTag = x.AssetTag,
                InvoiceDate = x.InvoiceDate,
                InventoryEntryDate = x.InventoryEntryDate,
                Barcode = x.Barcode,
                Category = new AssetCategoryViewModel { Id = x.AssetModel.Category.Id, Name = x.AssetModel.Category.Name, IsRequireUserConfirmation = x.AssetModel.Category.IsRequireUserConfirmation, IsSendEmailToUser = x.AssetModel.Category.IsSendEmail },

                CheckoutToUser = x.CheckoutId != null && x.Checkout.ChekoutToUserId != null ? new IdNameViewModel { Id = x.Checkout.ChekoutToUser.Id, Name = x.Checkout.ChekoutToUser.FullName } : null,

                CheckoutToLocation = x.CheckoutId != null && x.Checkout.ChekoutToLocationId != null ? new IdNameViewModel { Id = x.Checkout.ChekoutToLocation.Id, Name = x.Checkout.ChekoutToLocation.OfficeName } : null,

                CheckoutToAsset = x.CheckoutId != null && x.Checkout.ChekoutToAsset != null ? new IdNameViewModel { Id = x.Checkout.ChekoutToAsset.Id, Name = x.Checkout.ChekoutToAsset.Name } : null,

                CheckoutId = x.CheckoutId,
                Photo = mediaService.GetPhotoUrl(x.Media),

                EOL = x.EOL,
                WarrantyRemainingInDays = x.Warranty > 0 && x.PurchaseDate != null ? (x.PurchaseDate.Value.AddMonths(x.Warranty) - DateTime.Now).TotalDays : -1,

                MaintenanceRemainingInDays = x.Maintenance > 0 && x.PurchaseDate != null ?(x.PurchaseDate.Value.AddMonths(x.Maintenance) - DateTime.Now).TotalDays : -1
            };
        }
    }
}
