using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(Division), Schema = SchemaConstants.Core)]
    public class Division : IdNameEntity
    {
        public Division()
        {

        }

        public Division(long id, string name)
        {
        }
    }
}
