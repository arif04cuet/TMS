using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Topic), Schema = SchemaConstants.Training)]
    public class Topic : IdNameEntity
    {
        public string Objectives { get; set; }
        public string Outcomes { get; set; }
        public string CourseMaterials { get; set; }
        public string CourseDetails { get; set; }
    }
}
