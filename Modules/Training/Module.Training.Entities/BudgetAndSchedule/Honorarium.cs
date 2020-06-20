using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Honorarium), Schema = SchemaConstants.Training)]
    public class Honorarium : BaseEntity
    {
        public HonorariumFor HonorariumFor { get; set; }
        public int Year { get; set; }
    }
}
