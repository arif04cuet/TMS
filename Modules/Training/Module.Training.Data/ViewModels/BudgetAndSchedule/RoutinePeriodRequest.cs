using Module.Training.Entities;
using System;

namespace Module.Training.Data
{
    public class RoutinePeriodRequest
    {
        public long? Id { get; set; }
        public long? Topic { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public long ResourcePerson { get; set; }

        public RoutinePeriod Map(RoutinePeriod routinePeriod = null)
        {
            var entity = routinePeriod ?? new RoutinePeriod();
            entity.TopicId = Topic;
            entity.StartTime = StartTime;
            entity.EndTime = EndTime;
            entity.ResourcePersonId = ResourcePerson;
            return entity;
        }
    }
}
