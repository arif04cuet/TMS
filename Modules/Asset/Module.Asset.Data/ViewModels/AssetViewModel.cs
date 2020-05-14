﻿using Module.Core.Shared;
using System;

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
        public IdNameViewModel Supplier { get; set; }
        public string OrderNo { get; set; }
        public double PurchaseCost { get; set; }
        public int Warranty { get; set; }
        public string Note { get; set; }
        public bool IsRequestable { get; set; }
        public IdNameViewModel Location { get; set; }
        public string Photo { get; set; }
        public IdNameViewModel CheckoutToUser { get; set; }
        public IdNameViewModel CheckoutToLocation { get; set; }
        public IdNameViewModel CheckoutToAsset { get; set; }
        public AssetCategoryViewModel Category { get; set; }
        public long? CheckoutId { get; set; }
    }
}
