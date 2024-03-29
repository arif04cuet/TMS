﻿using Module.Asset.Entities;
using System;

namespace Module.Asset.Data
{
    public class CheckoutHistoryCreateRequest
    {
        // Could be Users, Assests, Accessories, Components or Consumables
        public long? TargetId { get; set; }
        public AssetType TargetType { get; set; }

        // Could be Users, Assests, Accessories, Components or Consumables
        public long? ItemId { get; set; }
        public AssetType ItemType { get; set; }
        public AssetAction Action { get; set; }
        public string Note { get; set; }
        public DateTime? IssueDate { get; set; }
        public int Quantity { get; set; }

        public CheckoutHistory Map()
        {
            var history = new CheckoutHistory
            {
                IssueDate = IssueDate ?? DateTime.UtcNow,
                ItemId = ItemId,
                ItemType = ItemType,
                TargetId = TargetId,
                TargetType = TargetType,
                Action = Action,
                Note = Note,
                Quantity = Quantity
            };
            return history;
        }
    }
}
