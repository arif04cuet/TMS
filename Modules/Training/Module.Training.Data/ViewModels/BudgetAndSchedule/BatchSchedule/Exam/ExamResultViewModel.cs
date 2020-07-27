namespace Module.Training.Data
{
    public class ExamResultViewModel
    {
        //public long AllocationId { get; set; }
        public long Id { get; set; }
        public int TotalMark { get; set; }
        public string Name { get; set; }
        public long ParticipantId { get; set; }
        public bool IsMcq { get; set; }
    }
}
