namespace Module.Training.Entities
{
    public enum AllocationStatus : byte
    {
        TemporaryBooked = 1,
        Booked = 2,
        Cancelled = 3,
        CheckedOut = 4
    }
}
