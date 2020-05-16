﻿using Module.Core.Shared;

namespace Module.Asset.Data
{
    public class ConsumableCheckoutListViewModel : IViewModel
    {
        public long Id { get; set; }
        public long ConsumableId { get; set; }
        public IdNameViewModel User { get; set; }
    }
}