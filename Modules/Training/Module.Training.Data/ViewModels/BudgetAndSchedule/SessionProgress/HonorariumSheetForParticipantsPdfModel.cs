using System;
using System.Collections.Generic;

namespace Module.Training.Data
{
    public class HonorariumSheetForParticipantsPdfModel
    {
        public DateTime Date { get; set; }
        public string CourseName { get; set; }
        public IEnumerable<ParticipantHonorariumModel> ResourcePersons { get; set; }
    }

    public class ParticipantHonorariumModel
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public double Amount { get; set; }
        public double TenPercentReduceAmout { get; set; }
        public double NetAmount { get; set; }
    }

}
