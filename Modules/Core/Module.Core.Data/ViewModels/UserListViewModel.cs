﻿using Module.Core.Shared;

namespace Module.Core.Data
{
    public class UserListViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Photo { get; set; }
        public string FullName { get; set; }
        public string Designation { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public IdNameViewModel Status { get; set; }
    }
}
