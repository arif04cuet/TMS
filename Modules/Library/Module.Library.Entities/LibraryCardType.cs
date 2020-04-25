using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(LibraryCardType), Schema = SchemaConstants.Library)]
    public class LibraryCardType : IdNameEntity
    {
        public LibraryCardType() : base()
        {

        }

        public LibraryCardType(long id, string name) : base(id, name)
        {
        }
    }
}
