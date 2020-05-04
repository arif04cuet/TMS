using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(Division), Schema = SchemaConstants.Core)]
    public class Division : IdNameEntity
    {
        public string BnName { get; set; }
        public Division() : base()
        {

        }

        public Division(long id, string name, string bnName) : base(id, name)
        {
            BnName = bnName;
        }
    }
}
