using System;

namespace Module.Library.Data
{
    public class LibraryMemberRequestCreateRequest
    {
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long? Library { get; set; }
        public long? Media { get; set; }
    }
}
