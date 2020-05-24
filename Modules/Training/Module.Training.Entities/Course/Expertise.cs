using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Expertise), Schema = SchemaConstants.Training)]
    public class Expertise : IdNameEntity
    {
    }
}
