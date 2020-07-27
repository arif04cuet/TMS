using Module.Core.Shared;
using Module.CMS.Entities;
using System.IO;
using System.Linq.Expressions;
using System;
using Module.Core.Entities;

namespace Module.CMS.Data
{
    public class BannerViewModel : IViewModel
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public long Media { get; set; }
        public string MediaUrl { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public bool IsActive { get; set; }


        public static Expression<Func<Banner, BannerViewModel>> Select()
        {
            return x => new BannerViewModel
            {
                Id = x.Id,
                Name = x.Name,
                IsActive = x.IsActive,
                CreatedAt = x.CreatedAt.ToString(),
                UpdatedAt = x.UpdatedAt.ToString(),

                Media = x.Media.Id,
                MediaUrl = Path.Combine(MediaConstants.Path, x.Media.FileName),

            };
        }

    }
}
