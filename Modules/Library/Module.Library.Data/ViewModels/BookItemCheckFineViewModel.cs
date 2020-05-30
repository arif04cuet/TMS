namespace Module.Library.Data
{
    public class BookItemCheckFineViewModel
    {
        public bool IsFined { get; set; }
        public double FineDays { get; set; }
        public double LateFineAmount { get; set; }
        public double LostFineAmount { get; set; }
    }
}
