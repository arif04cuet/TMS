using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(Gender), Schema = SchemaConstants.Core)]
    public class Gender : IdNameEntity
    {
        public Gender() : base()
        {

        }

        public Gender(long id, string name) : base (id, name)
        {
            Id = id;
            Name = name;
        }
    }
}
