using Module.Core.Shared;

namespace Module.Library.Data
{
    public class LibraryMemberViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Photo { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public IdNameViewModel Status { get; set; }
    }
}
