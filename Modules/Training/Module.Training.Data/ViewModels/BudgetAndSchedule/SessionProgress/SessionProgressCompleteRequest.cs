namespace Module.Training.Data
{

    public class SessionProgressCompleteRequest
    {
        public long BatchScheduleId { get; set; }
        public long[] RoutinePeriods { get; set; }

    }

}
