using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(CourseModule), Schema = SchemaConstants.Training)]
    public class CourseModule : IdNameEntity
    {
        public string Duration { get; set; }
        public string Marks { get; set; }
        public string Objectives { get; set; }
    }
}
