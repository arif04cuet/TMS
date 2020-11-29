using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Facilities), Schema = SchemaConstants.Training)]
    [CheckUnique]
    public class Facilities : IdNameEntity
    {
    }
}
