using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(Status), Schema = SchemaConstants.Core)]
    public class Status : IdNameEntity
    {
        public Status()
        {

        }

        public Status(long id, string name) : base(id, name)
        {
        }
    }
}
