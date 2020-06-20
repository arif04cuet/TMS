using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class BudgetViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Serial { get; set; }
        public string Category { get; set; }
        public IdNameViewModel CourseSchedule { get; set; }
        public IEnumerable<BudgetItemViewModel> Items { get; set; }

        public static Expression<Func<Budget, BudgetViewModel>> Select()
        {
            return x => new BudgetViewModel
            {
                Id = x.Id,
                Serial = x.Serial,
                Category = x.Category,
                CourseSchedule = new IdNameViewModel { Id = x.CourseSchedule.Id, Name = x.CourseSchedule.Name },
                Items = x.Items.Select(y => new BudgetItemViewModel
                {
                    Id = y.Id,
                    Serial = y.Serial,
                    Details = y.Details,
                    Quantity = y.Quantity,
                    Rate = y.Rate,
                    Total = y.Total
                })
            };
        }
    }
}
