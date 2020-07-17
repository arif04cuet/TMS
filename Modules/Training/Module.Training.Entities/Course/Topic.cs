using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Topic), Schema = SchemaConstants.Training)]
    public class Topic : IdNameEntity
    {

        public Topic()
        {
            ResoursePersons = new HashSet<TopicResourcePerson>();
        }

        public string Objectives { get; set; }
        public string Outcomes { get; set; }
        public string CourseMaterials { get; set; }
        public string CourseDetails { get; set; }

        public long? MethodId { get; set; }
        public Method Method { get; set; }

        public long? EvaluationMethodId { get; set; }
        public EvaluationMethod EvaluationMethod { get; set; }

        public int Duration { get; set; }
        public int Marks { get; set; }

        public virtual ICollection<TopicResourcePerson> ResoursePersons { get; private set; }
    }
}
