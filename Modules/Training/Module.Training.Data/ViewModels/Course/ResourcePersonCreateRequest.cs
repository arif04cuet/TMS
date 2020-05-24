using Module.Training.Entities;

namespace Module.Training.Data
{
    public class ResourcePersonCreateRequest
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public long Designation { get; set; }
        public long? Office { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string NID { get; set; }
        public string TIN { get; set; }

        public ResourcePerson Map(ResourcePerson person = null)
        {
            var entity = person ?? new ResourcePerson();
            entity.Name = Name;
            entity.DesignationId = Designation;
            entity.Email = Email;
            entity.Mobile = Mobile;
            entity.NID = NID;
            entity.OfficeId = Office;
            entity.ShortName = ShortName;
            entity.TIN = TIN;
            return entity;
        }
    }
}
