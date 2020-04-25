using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(User), Schema = SchemaConstants.Core)]
    public class User : BaseEntity
    {
        [Searchable]
        public string FullName { get; set; }

        [Searchable]
        public string Email { get; set; }

        [Searchable]
        public string Mobile { get; set; }

        public string EmployeeId { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }

        public long? StatusId { get; set; }
        public Status Status { get; set; }

        [Searchable]
        public long? DesignationId { get; set; }
        public Designation Designation { get; set; }

        public long? DepartmentId { get; set; }
        public Department Department { get; set; }

        public virtual UserProfile Profile { get; set; }

    }
}
