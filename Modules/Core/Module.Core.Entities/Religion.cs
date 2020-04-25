using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(Religion), Schema = SchemaConstants.Core)]
    public class Religion : IdNameEntity
    {

        public Religion() : base()
        {

        }

        public Religion(long id, string name) : base(id, name)
        {
        }
    }
}
