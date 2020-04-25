using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(BookFormat), Schema = SchemaConstants.Library)]
    public class BookFormat : IdNameEntity
    {
        public BookFormat() : base()
        {

        }

        public BookFormat(long id, string name) : base(id, name)
        {

        }
    }
}
