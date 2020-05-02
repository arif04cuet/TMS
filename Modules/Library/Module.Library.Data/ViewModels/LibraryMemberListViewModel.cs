using Module.Core.Shared;

namespace Module.Library.Data
{
    public class LibraryMemberListViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Photo { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public IdNameViewModel Library { get; set; }

    }
}
