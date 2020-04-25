using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(LibraryCardStatus), Schema = SchemaConstants.Library)]
    public class LibraryCardStatus : IdNameEntity
    {
        public LibraryCardStatus() : base()
        {

        }

        public LibraryCardStatus(long id, string name) : base(id, name)
        {

        }
    }
}
