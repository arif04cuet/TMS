using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class BudgetItemViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Serial { get; set; }
        public string Details { get; set; }
        public double Rate { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }

        public static Expression<Func<BudgetItem, BudgetItemViewModel>> Select()
        {
            return x => new BudgetItemViewModel
            {
                Id = x.Id,
                Serial = x.Serial,
                Details = x.Details,
                Rate = x.Rate,
                Quantity = x.Quantity,
                Total = x.Total
            };
        }
    }
}
