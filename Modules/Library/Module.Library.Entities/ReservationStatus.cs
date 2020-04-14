using Infrastructure.Entities;

namespace Module.Library.Entities
{
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
