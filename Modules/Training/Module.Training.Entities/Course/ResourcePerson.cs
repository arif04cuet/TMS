using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(ResourcePerson), Schema = SchemaConstants.Training)]
    public class ResourcePerson : BaseEntity
    {
        public string ShortName { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public long? OfficeId { get; set; }
        public Office Office { get; set; }

        public string NID { get; set; }
        public string TIN { get; set; }
    }

}
