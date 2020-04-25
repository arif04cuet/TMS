using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(Publisher), Schema = SchemaConstants.Library)]
    public class Publisher : IdNameEntity
    {

    }
}
