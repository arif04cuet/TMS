using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(UserProfile), Schema = SchemaConstants.Core)]
    public class UserProfile : BaseEntity
    {
        public string NID { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? JoiningDate { get; set; }

        public long? BloodGroupId { get; set; }
        public BloodGroup BloodGroup { get; set; }

        public long? GenderId { get; set; }
        public Gender Gender { get; set; }

        public long? MaritalStatusId { get; set; }
        public MaritalStatus MaritalStatus { get; set; }

        public long? ReligionId { get; set; }
        public Religion Religion { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public long? MediaId { get; set; }
        public Media Media { get; set; }

        public long? ContactAddressId { get; set; }
        public Address ContactAddress { get; set; }

        public long? PermanentAddressId { get; set; }
        public Address PermanentAddress { get; set; }

        public long? OfficeAddressId { get; set; }
        public Address OfficeAddress { get; set; }

        public long? EducationId { get; set; }
        public Education Education { get; set; }

    }
}
