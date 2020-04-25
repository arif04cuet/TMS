using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(EBookFormat), Schema = SchemaConstants.Library)]
    public class EBookFormat : IdNameEntity
    {
        public EBookFormat() : base()
        {

        }

        public EBookFormat(long id, string name) : base(id, name)
        {

        }
    }
}
