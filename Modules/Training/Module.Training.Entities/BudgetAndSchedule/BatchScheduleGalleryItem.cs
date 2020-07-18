using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(BatchScheduleGalleryItem), Schema = SchemaConstants.Training)]
    public class BatchScheduleGalleryItem : BaseEntity
    {
        public long MediaId { get; set; }
        public Media Media { get; set; }

        public long BatchScheduleId { get; set; }
        public BatchSchedule BatchSchedule { get; set; }
    }
}
