using Module.Core.Entities;

namespace Module.Core.Data
{
    public class EducationRequest
    {
        public string PassingYear { get; set; }
        public string University { get; set; }
        public string Department { get; set; }
        public string Degree { get; set; }
        public string Result { get; set; }

        public Education MapTo(Education education)
        {
            if (education != null)
            {
                education.Degree = Degree;
                education.Department = Department;
                education.PassingYear = PassingYear;
                education.Result = Result;
                education.University = University;
            }
            return education;
        }

    }

}
