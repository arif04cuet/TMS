﻿using Module.Core.Shared;

namespace Module.Asset.Data
{
    public class AccessoryCheckoutListViewModel : IViewModel
    {
        public long Id { get; set; }
        public long AccessoryId { get; set; }
        public IdNameViewModel User { get; set; }
    }
}
