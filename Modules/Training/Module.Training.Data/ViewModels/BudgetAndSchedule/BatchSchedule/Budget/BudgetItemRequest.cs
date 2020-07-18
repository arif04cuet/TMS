using Module.Training.Entities;

namespace Module.Training.Data
{
    public class BudgetItemRequest
    {
        public long? Id { get; set; }
        public string Serial { get; set; }
        public string Details { get; set; }
        public double Rate { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }

        public BudgetItem Map(BudgetItem budgetItem = null)
        {
            var entity = budgetItem ?? new BudgetItem();
            entity.Serial = Serial;
            entity.Details = Details;
            entity.Rate = Rate;
            entity.Quantity = Quantity;
            entity.Total = Quantity * Rate;
            return entity;
        }
    }
}
