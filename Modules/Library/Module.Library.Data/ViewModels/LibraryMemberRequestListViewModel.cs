using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
using Module.Core.Shared;
using Module.Library.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Library.Data
{
    public class LibraryMemberRequestListViewModel : LibraryMemberListViewModel
    {
        public bool IsApproved { get; set; }
        public DateTime RequestDate { get; set; }

        public static Expression<Func<LibraryMemberRequest, LibraryMemberRequestListViewModel>> SelectRequest(IMediaService mediaService)
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
                IsApproved = x.IsApproved,
                RequestDate = x.RequestDate,
                Photo = x.IsApproved ? mediaService.GetPhotoUrl(x.User.Profile.Media) : mediaService.GetPhotoUrl(x.Media)
            };
        }

    }
}
