using Module.Core.Data;
using Module.Core.Shared;

namespace Module.Library.Data
{
    public class LibraryDashboardViewModel : IViewModel
    {
        public long TotalIssued { get; set; }
        public long TodaysIssue { get; set; }
        public long Pending { get; set; }
        public long TodaysReturn { get; set; }
        public long ReturnPending { get; set; }
        public long TotalMember { get; set; }
        public long TotalItem { get; set; }
        public long NewItem { get; set; }
    }
}
