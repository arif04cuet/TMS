using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(ReservationStatus), Schema = SchemaConstants.Library)]
    public class ReservationStatus : IdNameEntity
    {
        public ReservationStatus() : base()
        {

        }

        public ReservationStatus(long id, string name) : base(id, name)
        {

        }
    }
}
