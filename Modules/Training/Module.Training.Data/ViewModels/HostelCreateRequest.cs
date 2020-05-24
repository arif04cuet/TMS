using Module.Core.Entities;
using Module.Training.Entities;

namespace Module.Training.Data
{
    public class HostelCreateRequest
    {

        public string Name { get; set; }
        public string Address { get; set; }

        public Hostel Map(Hostel hostel = default)
        {
            var entity = hostel ?? new Hostel();
            entity.Name = Name;

            entity.Address = entity.Address ?? new Address();
            entity.Address.AddressLine1 = Address;

            return entity;
        }
    }
}
