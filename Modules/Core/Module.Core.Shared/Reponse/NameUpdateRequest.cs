namespace Module.Core.Shared
{
    public class NameUpdateRequest : NameCreateRequest, INameUpdateRequest
    {
        public long Id { get; set; }
    }
}
