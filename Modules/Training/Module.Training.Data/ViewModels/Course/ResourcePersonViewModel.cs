using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.IO;

namespace Module.Training.Data
{
    public class ResourcePersonViewModel : IViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public IdNameViewModel Designation { get; set; }
        public IdNameViewModel Office { get; set; }
        public IdNameViewModel HonorariumHead { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        public string AltMobile { get; set; }
        public string AltEmail { get; set; }

        public string MailingAddress { get; set; }
        public string OfficeAddress { get; set; }

        public string Cv { get; set; }
        public string CvFileName { get; set; }
        public string Photo { get; set; }

        public string NID { get; set; }
        public string TIN { get; set; }

        public string FacebookUrl { get; set; }
        public bool IsFacebookUrlPublic { get; set; }

        public string YouTubeUrl { get; set; }
        public bool IsYouTubeUrlPublic { get; set; }

        public string LinkedinUrl { get; set; }
        public bool IsLinkedinUrlPublic { get; set; }

        public string InstagramUrl { get; set; }
        public bool IsInstagramUrlPublic { get; set; }

        public IEnumerable<IdNameViewModel> Expertises { get; set; }

        public static Expression<Func<ResourcePerson, ResourcePersonViewModel>> Select()
        {
            return x => new ResourcePersonViewModel
            {
                Id = x.Id,
                UserId = x.UserId.Value,
                Designation = x.UserId != null && x.User.DesignationId != null ? new IdNameViewModel { Id = x.User.Designation.Id, Name = x.User.Designation.Name } : null,
                Email = x.User.Email,
                Mobile = x.User.Mobile,
                AltEmail = x.AltEmail,
                AltMobile = x.AltMobile,
                MailingAddress = x.MailingAddress,
                OfficeAddress = x.OfficeAddress,
                Name = x.User.FullName,
                NID = x.NID,
                Office = x.OfficeId != null ? new IdNameViewModel { Id = x.Office.Id, Name = x.Office.OfficeName } : null,
                HonorariumHead = x.HonorariumHeadId != null ? new IdNameViewModel { Id = x.HonorariumHead.Id, Name = x.HonorariumHead.Head } : null,
                ShortName = x.ShortName,
                TIN = x.TIN,
                Photo = x.PhotoId.HasValue ? Path.Combine(MediaConstants.Path, x.Photo.FileName) : string.Empty,
                Cv = x.CvId.HasValue ? Path.Combine(MediaConstants.Path, x.Cv.FileName) : string.Empty,
                CvFileName = x.CvId.HasValue ? x.Cv.FileName : string.Empty,

                FacebookUrl = x.FacebookUrl,
                IsFacebookUrlPublic = x.IsFacebookUrlPublic,
                YouTubeUrl = x.YouTubeUrl,
                IsYouTubeUrlPublic = x.IsYouTubeUrlPublic,
                LinkedinUrl = x.LinkedinUrl,
                IsLinkedinUrlPublic = x.IsLinkedinUrlPublic,
                InstagramUrl = x.InstagramUrl,
                IsInstagramUrlPublic = x.IsInstagramUrlPublic
            };
        }
    }
}
