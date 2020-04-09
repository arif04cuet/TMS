using Module.Core.Entities;

namespace Module.Core.Data
{
    public class UserCreateRequest
    {
        public string FullName { get; set; }
        public string EmployeeId { get; set; }
        public long Designation { get; set; }
        public long? Department { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long[] Roles { get; set; }
        public long Status { get; set; }

    }

}
