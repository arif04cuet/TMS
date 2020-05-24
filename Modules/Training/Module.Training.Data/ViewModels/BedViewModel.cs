using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class BedViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IdNameViewModel Hostel { get; set; }
        public IdNameViewModel Building { get; set; }
        public IdNameViewModel Floor { get; set; }
        public IdNameViewModel Room { get; set; }
        public bool IsBooked { get; set; }

        public static Expression<Func<Bed, BedViewModel>> Select()
        {
            return (Bed x) => new BedViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Building = new IdNameViewModel { Id = x.Building.Id, Name = x.Building.Name },
                Floor = new IdNameViewModel { Id = x.Floor.Id, Name = x.Floor.Name },
                Hostel = new IdNameViewModel { Id = x.Hostel.Id, Name = x.Hostel.Name },
                Room = new IdNameViewModel { Id = x.Room.Id, Name = x.Room.Name },
                IsBooked = x.IsBooked
            };
        }
    }
}
