using Module.Core.Shared;

namespace Module.Training.Data
{
    public class HostelDashboardViewModel : IViewModel
    {
        public long TotalRoom { get; set; }
        public long FreeRoom { get; set; }
        public long TotalSeat { get; set; }
        public long FreeSeat { get; set; }
        public long BookingRequest { get; set; }
        public long TodaysCheckin { get; set; }
        public long TodaysCheckout { get; set; }
        public long TodaysCheckoutable { get; set; }
        public long RequiredRoomAndSeat { get; set; }
        public long AllocatedRoom { get; set; }
        public long AllocatedSeat { get; set; }
        public long CheckinAndCheckout { get; set; }
    }
}
