using Module.Core.Shared;
using System;

namespace Module.Training.Data
{
    public class AllocationViewModel : IViewModel
    {
        public long Id { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime? CheckoutDate { get; set; }
        public IdNameViewModel User { get; set; }
        public IdNameViewModel Room { get; set; }
        public IdNameViewModel Bed { get; set; }
        public long Days { get; set; }
        public double Amount { get; set; }
    }
}
