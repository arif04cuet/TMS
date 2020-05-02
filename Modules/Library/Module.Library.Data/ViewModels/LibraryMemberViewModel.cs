using Module.Core.Shared;
using System;

namespace Module.Library.Data
{
    public class LibraryMemberViewModel : IViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Photo { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime? MemberSince { get; set; }
        public IdNameViewModel Status { get; set; }
        public IdNameViewModel Library { get; set; }
        public LibraryCardViewModel Card { get; set; }
    }
}
