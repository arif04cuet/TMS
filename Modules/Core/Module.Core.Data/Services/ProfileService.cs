using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data.Criteria;
using Module.Core.Entities;
using Module.Core.Shared;
using Msi.UtilityKit.Security;
using System.IO;
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
        private readonly IAppService _appService;

        public ProfileService(
            IUnitOfWork unitOfWork,
            IAppService appService)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
            _userProfileRepository = _unitOfWork.GetRepository<UserProfile>();
            _userRoleRepository = _unitOfWork.GetRepository<UserRole>();
            _mediaRepository = _unitOfWork.GetRepository<Media>();
            _appService = appService;
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
                    Department = x.Department != null ? new IdNameViewModel
                    {
                        Id = x.Department.Id,
                        Name = x.Department.Name
                    } : null,
                    Designation = x.Designation != null ? new IdNameViewModel
                    {
                        Id = x.Designation.Id,
                        Name = x.Designation.Name
                    } : null,
                    Status = x.Status != null ? new IdNameViewModel
                    {
                        Id = x.Status.Id,
                        Name = x.Status.Name
                    } : null,
                    Roles = roles,

                    BloodGroup = x.Profile.BloodGroup != null ? new IdNameViewModel
                    {
                        Id = (long)x.Profile.BloodGroupId,
                        Name = x.Profile.BloodGroup.Name
                    } : null,
                    Gender = x.Profile.Gender != null ? new IdNameViewModel
                    {
                        Id = (long)x.Profile.GenderId,
                        Name = x.Profile.Gender.Name
                    } : null,
                    MaritalStatus = x.Profile.MaritalStatus != null ? new IdNameViewModel
                    {
                        Id = (long)x.Profile.MaritalStatusId,
                        Name = x.Profile.MaritalStatus.Name
                    } : null,
                    Religion = x.Profile.Religion != null ? new IdNameViewModel
                    {
                        Id = (long)x.Profile.ReligionId,
                        Name = x.Profile.Religion.Name
                    } : null,
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
                    Photo = x.Profile.MediaId.HasValue ? Path.Combine(_appService.GetServerUrl(), MediaConstants.Path, x.Profile.Media.FileName) : string.Empty
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
                var media = await _mediaRepository
                    .FirstOrDefaultAsync(x => x.Id == request.Media.Value);
                if (media != null)
                {
                    media.IsInUse = true;
                }
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
                string oldProfilePhotoPath = Path.Combine(ProjectManager.StoragePath, oldMedia.FileName);
                if (File.Exists(oldProfilePhotoPath))
                {
                    File.Delete(oldProfilePhotoPath);
                    _mediaRepository.Remove(oldMedia);
                    result += await _unitOfWork.SaveChangesAsync();
                }
            }
            return result > 0;
        }

    }
}
