using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(Office), Schema = SchemaConstants.Core)]
    public class Office : Address
    {
        public string OfficeName { get; set; }
    }
}
