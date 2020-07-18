using System;

namespace Module.Training.Data
{
    public class AllocationUpdateRequest : AllocationCreateRequest
    {
        public long Id { get; set; }
        public int Days { get; set; }
        public double Amount { get; set; }
        public DateTime? ChekoutDate { get; set; }
    }
}
