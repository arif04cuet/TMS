using Module.Training.Entities;
using System;

namespace Module.Training.Data
{
    public class RoutinePeriodRequest
    {
        public long? Id { get; set; }
        public long? Topic { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long ResourcePerson { get; set; }

        public RoutinePeriod Map(RoutinePeriod routinePeriod = null)
        {
            var entity = routinePeriod ?? new RoutinePeriod();
            entity.TopicId = Topic;
            entity.StartDate = StartDate;
            entity.EndDate = EndDate;
            entity.ResourcePersonId = ResourcePerson;
            return entity;
        }
    }
}
