using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class AllocationViewModel : IViewModel
    {
        public long Id { get; set; }
        public DateTime? CheckinDate { get; set; }
        public DateTime? CheckoutDate { get; set; }
        public IdNameViewModel User { get; set; }
        public IdNameViewModel Room { get; set; }
        public IdNameViewModel Bed { get; set; }
        public long Days { get; set; }
        public double Amount { get; set; }
        public IdNameViewModel Status { get; set; }

        public static Expression<Func<Allocation, AllocationViewModel>> Select()
        {
            return x => new AllocationViewModel
            {
                Id = x.Id,
                Amount = x.Amount,
                Bed = x.BedId.HasValue ? new IdNameViewModel { Id = x.Bed.Id, Name = x.Bed.Name } : null,
                CheckinDate = x.CheckinDate,
                CheckoutDate = x.CheckoutDate,
                Days = x.Days,
                Room = x.RoomId.HasValue ? new IdNameViewModel { Id = x.Room.Id, Name = x.Room.Name } : null,
                User = new IdNameViewModel { Id = x.User.Id, Name = x.User.FullName },
                Status = x.Status.HasValue ? new IdNameViewModel { Id = (long)x.Status, Name = x.Status.ToString() } : null
            };
        }
    }
}
