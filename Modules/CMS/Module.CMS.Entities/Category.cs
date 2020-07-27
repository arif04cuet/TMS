using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.CMS.Entities
{
    [Table(nameof(Category), Schema = SchemaConstants.Cms)]
    public class Category : IdNameEntity
    {
    }
}
