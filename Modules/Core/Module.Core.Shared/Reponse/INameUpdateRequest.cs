namespace Module.Core.Shared
{
    public interface INameUpdateRequest : INameCreateRequest
    {
        long Id { get; set; }
    }
}
