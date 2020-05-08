namespace Module.Library.Data
{
    public class LibraryMemberUpdateRequest : LibraryMemberCreateRequest
    {
        public long Id { get; set; }
        public long UserId { get; set; }
    }
}
