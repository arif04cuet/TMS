using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class HostelViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public static Expression<Func<Hostel, HostelViewModel>> Select()
        {
            return (Hostel x) => new HostelViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address.AddressLine1
            };
        }
    }
}
