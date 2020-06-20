using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(BudgetItem), Schema = SchemaConstants.Training)]
    public class BudgetItem : BaseEntity
    {
        public long BudgetId { get; set; }
        public Budget Budget { get; set; }
        public string Serial { get; set; }
        public string Details { get; set; }
        public double Rate { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
    }
}
