using Module.Core.Shared;
using Module.CMS.Entities;
using System.IO;
using System.Linq.Expressions;
using System;
using Module.Core.Entities;

namespace Module.CMS.Data
{
    public class ContentViewModel : IViewModel
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Summery { get; set; }
        public string Body { get; set; }
        public IdNameViewModel Category { get; set; }

        public long? Image { get; set; }
        public string ImageUrl { get; set; }

        public Media Attachment { get; set; }
        public string AttachmentUrl { get; set; }

        public bool IsActive { get; set; }

        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }


        public static Expression<Func<Content, ContentViewModel>> Select()
        {
            return x => new ContentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                Summery = x.Summery,
                Body = x.Body,
                IsActive = x.IsActive,
                CreatedAt = x.CreatedAt.ToString(),
                UpdatedAt = x.UpdatedAt.ToString(),
                Category = new IdNameViewModel { Id = x.Category.Id, Name = x.Category.Name },
                Image = x.ImageId.HasValue ? x.Image.Id : 0,
                ImageUrl = x.ImageId.HasValue ? Path.Combine(MediaConstants.Path, x.Image.FileName) : string.Empty,
                Attachment = x.Attachment,
                AttachmentUrl = x.AttachmentId.HasValue ? Path.Combine(MediaConstants.Path, x.Attachment.FileName) : string.Empty,
            };
        }

    }
}
