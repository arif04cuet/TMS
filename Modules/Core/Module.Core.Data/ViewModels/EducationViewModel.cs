using System;

namespace Module.Core.Data
{
    public class EducationViewModel
    {
        public long Id { get; set; }
        public DateTime PassingYear { get; set; }
        public string University { get; set; }
        public string Department { get; set; }
    }
}
