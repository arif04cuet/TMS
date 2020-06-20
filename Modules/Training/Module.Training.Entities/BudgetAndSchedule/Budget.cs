using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Budget), Schema = SchemaConstants.Training)]
    public class Budget : BaseEntity
    {

        public Budget()
        {
            Items = new HashSet<BudgetItem>();
        }

        public long CourseScheduleId { get; set; }
        public CourseSchedule CourseSchedule { get; set; }

        public string Serial { get; set; }
        public string Category { get; set; }

        public ICollection<BudgetItem> Items { get; }
    }
}
