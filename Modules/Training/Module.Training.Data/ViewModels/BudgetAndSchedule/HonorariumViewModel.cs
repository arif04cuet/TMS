using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class HonorariumViewModel
    {
        public long Id { get; set; }
        public IdNameViewModel HonorariumFor { get; set; }
        public int Year { get; set; }
        public IEnumerable<HonorariumHeadViewModel> Heads { get; set; }

        public static Expression<Func<Honorarium, HonorariumViewModel>> Select()
        {
            return x => new HonorariumViewModel
            {
                Id = x.Id,
                HonorariumFor = new IdNameViewModel { Id = (long)x.HonorariumFor, Name = x.HonorariumFor.ToString() },
                Year = x.Year,
            };
        }
    }
}
