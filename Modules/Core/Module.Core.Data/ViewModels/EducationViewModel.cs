﻿using Module.Core.Shared;

namespace Module.Core.Data
{
    public class EducationViewModel : IViewModel
    {
        public long Id { get; set; }
        public string PassingYear { get; set; }
        public string University { get; set; }
        public string Department { get; set; }
        public string Degree { get; set; }
        public string Result { get; set; }
    }
}
