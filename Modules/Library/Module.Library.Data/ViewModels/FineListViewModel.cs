using Module.Core.Shared;
using System;

namespace Module.Library.Data
{
    public class FineListViewModel
    {

        public long Id { get; set; }
        public IdNameViewModel Member { get; set; }
        public double DueAmount { get; set; }
        public double PaidAmount { get; set; }
        public long FineDays { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; }
        public double TotalAmount { get; set; }

    }
}
