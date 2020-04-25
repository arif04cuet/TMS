using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(MaritalStatus), Schema = SchemaConstants.Core)]
    public class MaritalStatus : IdNameEntity
    {
        public MaritalStatus() : base()
        {

        }

        public MaritalStatus(long id, string name) : base(id, name)
        {
        }
    }
}
