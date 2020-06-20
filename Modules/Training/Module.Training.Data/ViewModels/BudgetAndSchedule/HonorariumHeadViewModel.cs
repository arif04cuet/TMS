using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class HonorariumHeadViewModel
    {
        public long Id { get; set; }
        public long HonorariumId { get; set; }
        public IdNameViewModel Designation { get; set; }
        public string Head { get; set; }
        public double Amount { get; set; }

        public static Expression<Func<HonorariumHead, HonorariumHeadViewModel>> Select()
        {
            return x => new HonorariumHeadViewModel
            {
                HonorariumId = x.HonorariumId,
                Amount = x.Amount,
                Designation = x.DesignationId != null ? new IdNameViewModel { Id = x.Designation.Id, Name = x.Designation.Name } : null,
                Id = x.Id,
                Head = x.Head
            };
        }
    }
}
