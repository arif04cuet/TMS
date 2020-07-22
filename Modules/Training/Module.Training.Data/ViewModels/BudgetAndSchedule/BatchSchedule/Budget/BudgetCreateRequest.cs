using Module.Training.Entities;
using System.Collections.Generic;

namespace Module.Training.Data
{
    public class BudgetCreateRequest
    {
        public string Serial { get; set; }
        public string Category { get; set; }
        public long CourseSchedule { get; set; }
        public IEnumerable<BudgetItemRequest> Items { get; set; }
        public bool ReUsing { get; set; }

        public Budget Map(Budget budget = null)
        {
            var entity = budget ?? new Budget();
            entity.Serial = Serial;
            entity.Category = Category;
            entity.CourseScheduleId = CourseSchedule;
            return entity;
        }
    }
}
