using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(CourseMethod), Schema = SchemaConstants.Training)]
    public class CourseMethod : BaseEntity
    {
        public long CourseId { get; set; }
        public Course Course { get; set; }

        public long MethodId { get; set; }
        public Method Method { get; set; }
    }
}
