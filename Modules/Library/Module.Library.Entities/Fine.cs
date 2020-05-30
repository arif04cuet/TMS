using Module.Core.Entities.Constants;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(Fine), Schema = SchemaConstants.Library)]
    public class Fine : LibraryEntity
    {
        public float DueAmount { get; set; }
        public float TotalAmount { get; set; }
        public float LostFineAmount { get; set; }
        public float LateFineAmount { get; set; }
        public DateTime? PaymentDate { get; set; }

    }
}
