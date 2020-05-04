using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(District), Schema = SchemaConstants.Core)]
    public class District : IdNameEntity
    {
        public string BnName { get; set; }
        public long? DivisionId { get; set; }
        public Division Division { get; set; }
        public District() : base()
        {

        }

        public District(long id, string name) : base(id, name)
        {
        }

        public District(long id, long? divisionId, string name, string bnName) : base(id, name)
        {
            DivisionId = divisionId;
            BnName = bnName;
        }
    }
}
