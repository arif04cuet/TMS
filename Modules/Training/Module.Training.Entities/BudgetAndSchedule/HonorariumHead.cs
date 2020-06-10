using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(HonorariumHead), Schema = SchemaConstants.Training)]
    public class HonorariumHead : BaseEntity
    {
        public long HonorariumForId { get; set; }
        public User HonorariumFor { get; set; }

        public int Year { get; set; }
    }
}
