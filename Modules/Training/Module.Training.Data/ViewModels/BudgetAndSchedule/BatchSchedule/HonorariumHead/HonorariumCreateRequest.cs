using Module.Training.Entities;
using System.Collections.Generic;

namespace Module.Training.Data
{
    public class HonorariumCreateRequest
    {
        public HonorariumFor HonorariumFor { get; set; }
        public int Year { get; set; }
        public IEnumerable<HonorariumHeadRequest> Heads { get; set; }

        public Honorarium Map(Honorarium honorariumHead = null)
        {
            var entity = honorariumHead ?? new Honorarium();
            entity.HonorariumFor = HonorariumFor;
            entity.Year = Year;
            return entity;
        }
    }
}
