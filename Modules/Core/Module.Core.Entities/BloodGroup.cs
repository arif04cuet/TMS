using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(BloodGroup), Schema = SchemaConstants.Core)]
    public class BloodGroup : IdNameEntity
    {
        public BloodGroup() : base()
        {

        }

        public BloodGroup(long id, string name) : base(id, name)
        {
        }
    }
}
