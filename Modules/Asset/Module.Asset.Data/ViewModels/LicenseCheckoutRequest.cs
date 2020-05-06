using System;
using System.Collections.Generic;
using Module.Asset.Entities;

namespace Module.Asset.Data
{
    public class LicenseCheckoutRequest
    {
        public long Id { get; set; }
        public long IssuedToUserId { get; set; }
        public string Note { get; set; }

        public CheckoutHistory ToMap(CheckoutHistory licenseCheckoutRequest = null)
        {
            var entity = licenseCheckoutRequest ?? new CheckoutHistory();
            entity.TargetId = IssuedToUserId;
            entity.IssueDate = DateTime.Now;
            entity.Note = Note;
            entity.Action = AssetAction.Checkout;
            return entity;
        }
    }

}


