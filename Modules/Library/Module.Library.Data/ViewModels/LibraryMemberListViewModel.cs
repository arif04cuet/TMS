using Module.Core.Data;
using Module.Core.Shared;
using Module.Library.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Library.Data
{
    public class LibraryMemberListViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Photo { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public IdNameViewModel Library { get; set; }
        public IdNameViewModel Card { get; set; }

        public static Expression<Func<LibraryMemberRequest, LibraryMemberListViewModel>> Select(IMediaService mediaService)
        {
            return x => new LibraryMemberRequestListViewModel
            {
                Id = x.Id,
                Email = x.Email,
                FullName = x.FullName,
                Mobile = x.Mobile,
                Library = new IdNameViewModel
                {
                    Id = x.Library.Id,
                    Name = x.Library.Name
                },
                Photo = mediaService.GetPhotoUrl(x.User.Profile.Media)
            };
        }

        public static Expression<Func<LibraryMember, LibraryMemberListViewModel>> Select2(IMediaService mediaService)
        {
            return x => new LibraryMemberRequestListViewModel
            {
                Id = x.Id,
                UserId = x.UserId,
                Email = x.User.Email,
                FullName = x.User.FullName,
                Mobile = x.User.Mobile,
                Library = new IdNameViewModel
                {
                    Id = x.Library.Id,
                    Name = x.Library.Name
                },
                Card = x.CurrentCardId != null ? new IdNameViewModel
                {
                    Id = x.CurrentCard.Id,
                    Name = x.CurrentCard.Barcode
                } : null,
                Photo = mediaService.GetPhotoUrl(x.User.Profile.Media)
            };
        }

    }
}
