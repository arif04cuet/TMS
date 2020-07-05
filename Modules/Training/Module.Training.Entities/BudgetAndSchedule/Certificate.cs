using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Certificate), Schema = SchemaConstants.Training)]
    public class Certificate : BaseEntity
    {
        public string Serial { get; set; }

    }

}
