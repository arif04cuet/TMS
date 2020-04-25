using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(Designation), Schema = SchemaConstants.Core)]
    public class Designation : IdNameEntity
    {
        public Designation() : base()
        {

        }

        public Designation(long id, string name) : base(id, name)
        {

        }
    }
}
