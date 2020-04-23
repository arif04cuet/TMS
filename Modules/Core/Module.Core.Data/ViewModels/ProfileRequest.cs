using System;

namespace Module.Core.Data
{
    public class ProfileRequest
    {
        public long UserId { get; set; }
        public string FullName { get; set; }
        public string EmployeeId { get; set; }
        public long Designation { get; set; }
        public long? Department { get; set; }
        public string Mobile { get; set; }

        public long? Media { get; set; }
        public string NID { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? JoiningDate { get; set; }
        public long? Gender { get; set; }
        public long? MaritalStatus { get; set; }
        public long? Religion { get; set; }
        public long? BloodGroup { get; set; }

        public AddressRequest ContactAddress { get; set; }
        public AddressRequest PermanentAddress { get; set; }
        public AddressRequest OfficeAddress { get; set; }
        public EducationRequest Education { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }

}
