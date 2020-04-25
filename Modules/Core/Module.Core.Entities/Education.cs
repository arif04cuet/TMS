using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(Education), Schema = SchemaConstants.Core)]
    public class Education : IEntity
    {
        public long Id { get; set; }
        public string PassingYear { get; set; }
        public string University { get; set; }
        public string Department { get; set; }
        public string Degree { get; set; }
        public string Result { get; set; }
    }
}
