using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Course), Schema = SchemaConstants.Training)]
    public class Course : IdNameEntity
    {
        public long CategoryId { get; set; }
        public Category Category { get; set; }

        public string Objective { get; set; }
        public string Description { get; set; }
    }
}
