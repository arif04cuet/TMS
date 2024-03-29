﻿using System;

namespace Module.Training.Data
{
    public class MyExamListViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string BatchSchedule { get; set; }
        public string CourseSchedule { get; set; }
        public string Course { get; set; }
        public bool Attended { get; set; }
        public DateTime DateTime { get; set; }
    }
}
