using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(HonorariumHead), Schema = SchemaConstants.Training)]
    public class HonorariumHead : BaseEntity
    {
        public long HonorariumId { get; set; }
        public Honorarium Honorarium { get; set; }

        public long? DesignationId { get; set; }
        public Designation Designation { get; set; }

        public string Head { get; set; }

        public double Amount { get; set; }
    }
}
