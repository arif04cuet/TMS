using System;

namespace Module.Library.Data
{
    public class BookEntryListViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public double Price { get; set; }
        public string Voucher { get; set; }
        public DateTime EntryDate { get; set; }
        public long EntryAmount { get; set; }

    }
}
