using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Category), Schema = SchemaConstants.Training)]
    public class Category : IdNameEntity
    {
    }
}
