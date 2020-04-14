using Module.Core.Shared;
using System.Collections.Generic;

namespace Module.Core.Data
{
    public class UserViewModel : IViewModel
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string EmployeeId { get; set; }

        public IdNameViewModel Status { get; set; }
        public IdNameViewModel Designation { get; set; }
        public IdNameViewModel Department { get; set; }
        public ICollection<IdNameViewModel> Roles { get; set; }
    }
}
