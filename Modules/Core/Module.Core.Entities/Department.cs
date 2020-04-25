using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(Department), Schema = SchemaConstants.Core)]
    public class Department : IdNameEntity
    {
        public Department() : base()
        {

        }

        public Department(long id, string name) : base(id, name)
        {

        }
    }
}
