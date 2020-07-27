using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.CMS.Entities
{
    [Table(nameof(CmsCategory), Schema = SchemaConstants.Cms)]
    public class CmsCategory : IdNameEntity
    {
    }
}
