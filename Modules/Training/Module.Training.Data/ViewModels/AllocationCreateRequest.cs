using System;

namespace Module.Training.Data
{
    public class AllocationCreateRequest
    {
        public DateTime CheckinDate { get; set; }
        public long Participant { get; set; }
        public long? Room { get; set; }
        public long? Bed { get; set; }
    }
}
