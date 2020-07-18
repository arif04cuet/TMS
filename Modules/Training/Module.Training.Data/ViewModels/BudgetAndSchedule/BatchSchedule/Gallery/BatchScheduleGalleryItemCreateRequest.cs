using Module.Training.Entities;

namespace Module.Training.Data
{
    public class BatchScheduleGalleryItemCreateRequest
    {
        public long MediaId { get; set; }
        public long BatchScheduleId { get; set; }

        public BatchScheduleGalleryItem Map()
        {
            return new BatchScheduleGalleryItem
            {
                MediaId = MediaId,
                BatchScheduleId = BatchScheduleId
            };
        }
    }
}
