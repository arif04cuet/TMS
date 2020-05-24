using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Method), Schema = SchemaConstants.Training)]
    public class Method : IdNameEntity
    {
    }
}
