using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data.Criteria;
using Module.Core.Entities;
using Module.Core.Shared;
using Msi.UtilityKit.Security;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using static Module.Core.Shared.MessageConstants;

namespace Module.Core.Data
{
    public class ProfileService : IProfileService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<UserProfile> _userProfileRepository;
        private readonly IRepository<UserRole> _userRoleRepository;
        private readonly IRepository<Media> _mediaRepository;
        private readonly IMediaService _mediaService;

        public ProfileService(
            IUnitOfWork unitOfWork,
            IMediaService mediaService)
        {
            _unitOfWork = unitOfWork;
            _mediaService = mediaService;
            _userRepository = _unitOfWork.GetRepository<User>();
            _userProfileRepository = _unitOfWork.GetRepository<UserProfile>();
            _userRoleRepository = _unitOfWork.GetRepository<UserRole>();
            _mediaRepository = _unitOfWork.GetRepository<Media>();
        }

        public async Task<ProfileViewModel> Get(long userId, CancellationToken cancellationToken = default)
        {

            var roles = await _userRoleRepository.MatchAsync(new FindRolesByUserIdCriteria(userId));

            var result = await _userRepository
                .AsReadOnly()
                .Include(x => x.Profile)
                .Where(x => x.Id == userId && !x.IsDeleted)
                .Select(x => new ProfileViewModel
                {
                    Id = x.Id,
                    Email = x.Email,
                    EmployeeId = x.EmployeeId,
                    FullName = x.FullName,
                    Mobile = x.Mobile,
                    Department = IdNameViewModel.Map(x.Department),
                    Designation = IdNameViewModel.Map(x.Designation),
                    Status = IdNameViewModel.Map(x.Status),
                    Roles = roles,

                    BloodGroup = IdNameViewModel.Map(x.Profile.BloodGroup),
                    Gender = IdNameViewModel.Map(x.Profile.Gender),
                    MaritalStatus = IdNameViewModel.Map(x.Profile.MaritalStatus),
                    Religion = IdNameViewModel.Map(x.Profile.Religion),
                    DateOfBirth = x.Profile.DateOfBirth,
                    NID = x.Profile.NID,
                    JoiningDate = x.Profile.JoiningDate,
                    ContactAddress = AddressViewModel.Map(x.Profile.ContactAddress),
                    PermanentAddress = AddressViewModel.Map(x.Profile.PermanentAddress),
                    OfficeAddress = AddressViewModel.Map(x.Profile.OfficeAddress),

                    Education = x.Profile.Education != null ? new EducationViewModel
                    {
                        Id = x.Profile.Education.Id,
                        Department = x.Profile.Education.Department,
                        PassingYear = x.Profile.Education.PassingYear,
                        University = x.Profile.Education.University,
                        Degree = x.Profile.Education.Degree,
                        Result = x.Profile.Education.Result
                    } : null,
                    Photo = _mediaService.GetFullUrl(x.Profile.Media)
                })
                .FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException(PROFILE_NOT_FOUND);

            return result;
        }

        public async Task<bool> UpdateAsync(ProfileRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository
                .FirstOrDefaultAsync(x => x.Id == request.UserId && !x.IsDeleted);

            if (user == null)
                throw new NotFoundException(PROFILE_NOT_FOUND);

            user.FullName = request.FullName;
            user.Mobile = request.Mobile;
            if (!string.IsNullOrEmpty(request.Password) && string.IsNullOrEmpty(request.ConfirmPassword) && request.Password == request.ConfirmPassword)
            {
                user.Password = request.Password.HashPassword();
            }

            var profile = await _userProfileRepository
                .AsQueryable()
                .Include(x => x.ContactAddress)
                .Include(x => x.OfficeAddress)
                .Include(x => x.PermanentAddress)
                .Include(x => x.Education)
                .Include(x => x.Media)
                .FirstOrDefaultAsync(x => x.UserId == user.Id);

            if (profile == null)
            {
                profile = new UserProfile();
                profile.UserId = user.Id;
                profile.ContactAddress = new Address();
                profile.OfficeAddress = new Address();
                profile.PermanentAddress = new Address();
                profile.Education = new Education();
                await _userProfileRepository.AddAsync(profile);
            }

            profile.BloodGroupId = request.BloodGroup;
            profile.DateOfBirth = request.DateOfBirth;
            profile.GenderId = request.Gender;
            profile.JoiningDate = request.JoiningDate;
            profile.MaritalStatusId = request.MaritalStatus;
            profile.NID = request.NID;
            profile.ReligionId = request.Religion;

            var oldMedia = profile.Media;
            if (request.Media.HasValue)
            {
                profile.MediaId = request.Media;
                await _mediaService.UseAsync(request.Media.Value);
            }

            if (request.ContactAddress != null)
                request.ContactAddress.MapTo(profile.ContactAddress);

            if (request.PermanentAddress != null)
                request.PermanentAddress.MapTo(profile.PermanentAddress);

            if (request.OfficeAddress != null)
                request.OfficeAddress.MapTo(profile.OfficeAddress);

            if (request.Education != null)
                request.Education.MapTo(profile.Education);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            if (oldMedia != null && result > 0)
            {
                // successfully updated
                _ = _mediaService.DeleteMediaAsync(oldMedia.Id);
            }
            return result > 0;
        }

    }
}
