using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(Module), Schema = SchemaConstants.Core)]
    public class Module : IdNameEntity
    {
        public Module() : base()
        {

        }

        public Module(long id, string name) : base(id, name)
        {

        }
    }
}
