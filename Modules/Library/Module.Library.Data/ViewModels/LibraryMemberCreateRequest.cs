﻿using System;

namespace Module.Library.Data
{
    public class LibraryMemberCreateRequest
    {
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long Status { get; set; }
        public DateTime? MemberSince { get; set; }
        public long Library { get; set; }
        public long CardId { get; set; }
        public long? Photo { get; set; }
        public DateTime CardExpireDate { get; set; }
    }
}
