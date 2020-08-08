using System;
using System.Collections.Generic;

namespace Module.Training.Data
{
    public class HonorariumSheetForResourcePersonsPdfModel
    {
        public DateTime Date { get; set; }
        public string CourseName { get; set; }
        public IEnumerable<HonorariumPdfModelModel> ResourcePersons { get; set; }
    }

    public class HonorariumPdfModelModel
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public double Amount { get; set; }
        public double TenPercentReduceAmout { get; set; }
        public double NetAmount { get; set; }
    }

}
