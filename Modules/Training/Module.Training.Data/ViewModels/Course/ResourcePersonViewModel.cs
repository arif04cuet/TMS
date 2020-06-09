using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class ResourcePersonViewModel : IViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public IdNameViewModel Designation { get; set; }
        public IdNameViewModel Office { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string NID { get; set; }
        public string TIN { get; set; }

        public IEnumerable<IdNameViewModel> Expertises { get; set; }

        public static Expression<Func<ResourcePerson, ResourcePersonViewModel>> Select()
        {
            return x => new ResourcePersonViewModel
            {
                Id = x.Id,
                UserId = x.UserId.Value,
                Designation = x.UserId != null && x.User.DesignationId != null ? new IdNameViewModel { Id = x.User.Designation.Id, Name = x.User.Designation.Name } : null,
                Email = x.User.Email,
                Mobile = x.User.Mobile,
                Name = x.User.FullName,
                NID = x.NID,
                Office = x.OfficeId != null ? new IdNameViewModel { Id = x.Office.Id, Name = x.Office.OfficeName } : null,
                ShortName = x.ShortName,
                TIN = x.TIN
            };
        }
    }
}
