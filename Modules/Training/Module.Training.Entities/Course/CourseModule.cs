using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(CourseModule), Schema = SchemaConstants.Training)]
    public class CourseModule : IdNameEntity
    {

        public CourseModule()
        {
            Topics = new HashSet<CourseModuleTopic>();
        }

        public string Duration { get; set; }
        public int Marks { get; set; }
        public string Objectives { get; set; }

        public long? DirectorId { get; set; }
        public User Director { get; set; }

        public virtual ICollection<CourseModuleTopic> Topics { get; set; }
    }
}
