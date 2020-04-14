using Infrastructure.Data;
using Module.Library.Entities;
using System.Collections.Generic;

using static Module.Library.Data.ReservationStatusConstants;

namespace Module.Library.Data
{
    public class ReservationStatusSeedProvider : ISeedProvider<ReservationStatus>
    {
        public int Order => 0;
        public IEnumerable<ReservationStatus> GetSeeds()
        {
            return new List<ReservationStatus>
            {
                new ReservationStatus(Waiting, "Waiting"),
                new ReservationStatus(Pending, "Pending"),
                new ReservationStatus(Completed, "Completed"),
                new ReservationStatus(Canceled, "Canceled"),
                new ReservationStatus(None, "None")
            };
        }
    }
}
