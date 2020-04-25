using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(BookStatus), Schema = SchemaConstants.Library)]
    public class BookStatus : IdNameEntity
    {
        public BookStatus() : base()
        {

        }

        public BookStatus(long id, string name) : base(id, name)
        {

        }
    }
}
