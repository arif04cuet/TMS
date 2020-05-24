using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(ResourcePerson), Schema = SchemaConstants.Training)]
    public class ResourcePerson : IdNameEntity
    {
        public string ShortName { get; set; }

        public long DesignationId { get; set; }
        public Designation Designation { get; set; }

        public long? OfficeId { get; set; }
        public Office Office { get; set; }

        public string Mobile { get; set; }
        public string Email { get; set; }
        public string NID { get; set; }
        public string TIN { get; set; }
    }

}
