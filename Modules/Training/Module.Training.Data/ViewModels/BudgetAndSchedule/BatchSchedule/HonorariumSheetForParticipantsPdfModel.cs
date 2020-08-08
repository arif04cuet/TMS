using System;
using System.Collections.Generic;

namespace Module.Training.Data
{
    public class HonorariumSheetForParticipantsPdfModel
    {
        public DateTime Date { get; set; }
        public string CourseName { get; set; }
        public IEnumerable<HonorariumPdfModelModel> Participants { get; set; }
    }
}
