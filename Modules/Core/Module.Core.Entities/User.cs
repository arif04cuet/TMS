using Infrastructure.Entities;

namespace Module.Core.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string EmployeeId { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }

        public long? StatusId { get; set; }
        public Status Status { get; set; }

        public long? DesignationId { get; set; }
        public Designation Designation { get; set; }

        public long? DepartmentId { get; set; }
        public Department Department { get; set; }

        public virtual UserProfile Profile { get; set; }

    }
}
