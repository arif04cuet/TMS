using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(District), Schema = SchemaConstants.Core)]
    public class District : IdNameEntity
    {        
        public District() : base()
        {

        }

        public District(long id, string name) : base(id, name)
        {
        }
    }
}
