using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Entities;
using Msi.UtilityKit.Security;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Core.Data
{
    public class ProfileService : IProfileService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<UserProfile> _userProfileRepository;
        private readonly IRepository<UserRole> _userRoleRepository;

        public ProfileService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
            _userProfileRepository = _unitOfWork.GetRepository<UserProfile>();
            _userRoleRepository = _unitOfWork.GetRepository<UserRole>();
        }

        //public async Task<long> CreateAsync(UserCreateRequest request, CancellationToken cancellationToken = default)
        //{
        //    User newUser = new User
        //    {
        //        FullName = request.FullName,
        //        EmployeeId = request.EmployeeId,
        //        StatusId = request.Status,
        //        Email = request.Email,
        //        DepartmentId = request.Department,
        //        DesignationId = request.Designation,
        //        Password = request.Password.HashPassword()
        //    };

        //    await _userRepository.AddAsync(newUser, cancellationToken);
        //    var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        //    var userRoles = request.Roles.Select(x => new UserRole
        //    {
        //        UserId = newUser.Id,
        //        RoleId = x
        //    });
        //    await _userRoleRepository.AddRangeAsync(userRoles);

        //    UserProfile profile = new UserProfile { UserId = newUser.Id };
        //    await _userProfileRepository.AddAsync(profile, cancellationToken);

        //    result += await _unitOfWork.SaveChangesAsync(cancellationToken);
        //    return newUser.Id;
        //}

        public async Task<ProfileViewModel> Get(long userId, CancellationToken cancellationToken = default)
        {

            var roles = await _userRoleRepository
                .AsReadOnly()
                .Where(x => x.UserId == userId && !x.IsDeleted)
                .Select(x => new IdNameViewModel
                {
                    Id = x.RoleId,
                    Name = x.Role.Name
                })
                .ToListAsync();

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
                    ContactAddress = x.Profile.ContactAddress != null ? new AddressViewModel
                    {
                        AddressLine1 = x.Profile.ContactAddress.AddressLine1,
                        AddressLine2 = x.Profile.ContactAddress.AddressLine2,
                        ContactName = x.Profile.ContactAddress.ContactName,
                        District = x.Profile.ContactAddress.District != null ? new IdNameViewModel
                        {
                            Id = x.Profile.ContactAddress.District.Id,
                            Name = x.Profile.ContactAddress.District.Name
                        } : null,
                        Upazila = x.Profile.ContactAddress.Upazila != null ? new IdNameViewModel
                        {
                            Id = x.Profile.ContactAddress.Upazila.Id,
                            Name = x.Profile.ContactAddress.Upazila.Name
                        } : null
                    } : null,

                    PermanentAddress = x.Profile.PermanentAddress != null ? new AddressViewModel
                    {
                        AddressLine1 = x.Profile.PermanentAddress.AddressLine1,
                        AddressLine2 = x.Profile.PermanentAddress.AddressLine2,
                        ContactName = x.Profile.PermanentAddress.ContactName,
                        District = x.Profile.PermanentAddress.District != null ? new IdNameViewModel
                        {
                            Id = x.Profile.PermanentAddress.District.Id,
                            Name = x.Profile.PermanentAddress.District.Name
                        } : null,
                        Upazila = x.Profile.PermanentAddress.Upazila != null ? new IdNameViewModel
                        {
                            Id = x.Profile.PermanentAddress.Upazila.Id,
                            Name = x.Profile.PermanentAddress.Upazila.Name
                        } : null
                    } : null,

                    OfficeAddress = x.Profile.OfficeAddress != null ? new AddressViewModel
                    {
                        AddressLine1 = x.Profile.OfficeAddress.AddressLine1,
                        AddressLine2 = x.Profile.OfficeAddress.AddressLine2,
                        ContactName = x.Profile.OfficeAddress.ContactName,
                        District = x.Profile.OfficeAddress.District != null ? new IdNameViewModel
                        {
                            Id = x.Profile.OfficeAddress.District.Id,
                            Name = x.Profile.OfficeAddress.District.Name
                        } : null,
                        Upazila = x.Profile.OfficeAddress.Upazila != null ? new IdNameViewModel
                        {
                            Id = x.Profile.OfficeAddress.Upazila.Id,
                            Name = x.Profile.OfficeAddress.Upazila.Name
                        } : null
                    } : null,

                    Educations = x.Profile.Educations.Select(y => new EducationViewModel
                    {
                        Id = y.Id,
                        Department = y.Department,
                        PassingYear = y.PassingYear,
                        University = y.University
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException("Profile not found.");

            return result;
        }

        public async Task<bool> UpdateAsync(ProfileRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository
                .AsQueryable()
                .Include(x => x.Profile)
                .FirstOrDefaultAsync(x => x.Id == request.UserId && !x.IsDeleted);

            if (user == null)
                throw new NotFoundException($"Profile not found");

            user.FullName = request.FullName;
            user.Mobile = request.Mobile;
            if (!string.IsNullOrEmpty(request.Password) && string.IsNullOrEmpty(request.ConfirmPassword) && request.Password == request.ConfirmPassword)
            {
                user.Password = request.Password.HashPassword();
            }

            user.Profile.BloodGroupId = request.BloodGroup;
            user.Profile.DateOfBirth = request.DateOfBirth;
            user.Profile.GenderId = request.Gender;
            user.Profile.JoiningDate = request.JoiningDate;
            user.Profile.MaritalStatusId = request.MaritalStatus;
            user.Profile.NID = request.NID;
            user.Profile.ReligionId = request.Religion;

            request.ContactAddress.MapTo(user.Profile.ContactAddress);
            request.PermanentAddress.MapTo(user.Profile.PermanentAddress);
            request.OfficeAddress.MapTo(user.Profile.OfficeAddress);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

    }
}
