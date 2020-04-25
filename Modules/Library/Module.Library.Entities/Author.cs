using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(Author), Schema = SchemaConstants.Library)]
    public class Author : IdNameEntity
    {
    }
}
