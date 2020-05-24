using Module.Core.Shared;
using Module.Training.Entities;

namespace Module.Training.Data
{
    public class ResourcePersonViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public IdNameViewModel Designation { get; set; }
        public IdNameViewModel Office { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string NID { get; set; }
        public string TIN { get; set; }

        public static ResourcePersonViewModel Map(ResourcePerson person)
        {
            return new ResourcePersonViewModel
            {
                Id = person.Id,
                Designation = IdNameViewModel.Map(person.Designation),
                Email = person.Email,
                Mobile = person.Mobile,
                Name = person.Name,
                NID = person.NID,
                Office = person.OfficeId != null ? new IdNameViewModel { Id = person.Office.Id, Name = person.Office.OfficeName } : null,
                ShortName = person.ShortName,
                TIN = person.TIN
            };
        }
    }
}
