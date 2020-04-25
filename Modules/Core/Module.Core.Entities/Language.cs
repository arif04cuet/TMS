using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(Language), Schema = SchemaConstants.Core)]
    public class Language : IdNameEntity
    {
        public Language() : base()
        {

        }

        public Language(long id, string name) : base(id, name)
        {
        }
    }
}
