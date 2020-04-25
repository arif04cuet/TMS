using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(MemberStatus), Schema = SchemaConstants.Library)]
    public class MemberStatus : IdNameEntity
    {
        public MemberStatus() : base()
        {

        }

        public MemberStatus(long id, string name) : base(id, name)
        {

        }
    }
}
