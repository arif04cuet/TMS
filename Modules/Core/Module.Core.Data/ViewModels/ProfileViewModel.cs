using Infrastructure;
using Module.Core.Data.ViewModels;
using System;
using System.Collections.Generic;

namespace Module.Core.Data
{
    public class ProfileViewModel
    {
        public long Id { get; set; }
        public IdNameViewModel Status { get; set; }
        public IdNameViewModel Designation { get; set; }
        public IdNameViewModel Department { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string EmployeeId { get; set; }

        public string FullName { get; set; }
        public string Photo { get; set; }
        public string NID { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? JoiningDate { get; set; }
        public IdNameViewModel Gender { get; set; }
        public IdNameViewModel MaritalStatus { get; set; }
        public IdNameViewModel Religion { get; set; }
        public IdNameViewModel BloodGroup { get; set; }
        public ICollection<IdNameViewModel> Roles { get; set; }

        public AddressViewModel ContactAddress { get; set; }
        public AddressViewModel PermanentAddress { get; set; }
        public AddressViewModel OfficeAddress { get; set; }

        public ICollection<EducationViewModel> Educations { get; set; }
    }
}
