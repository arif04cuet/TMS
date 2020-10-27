using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Module.Core.Entities;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Msi.UtilityKit.Security;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using static Module.Core.Shared.MessageConstants;

namespace Module.Core.Data
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<UserProfile> _userProfileRepository;
        private readonly IRepository<UserRole> _userRoleRepository;
        private readonly IPermissionService _permissionService;
        private readonly IAppService _appService;
        private readonly IMediaService _mediaService;

        public UserService(
            IUnitOfWork unitOfWork,
            IPermissionService permissionService,
            IAppService appService,
            IMediaService mediaService)
        {
            _mediaService = mediaService;
            _unitOfWork = unitOfWork;
            _appService = appService;
            _permissionService = permissionService;
            _userRepository = _unitOfWork.GetRepository<User>();
            _userProfileRepository = _unitOfWork.GetRepository<UserProfile>();
            _userRoleRepository = _unitOfWork.GetRepository<UserRole>();
        }

        public async Task<long> CreateAsync(UserCreateRequest request, CancellationToken cancellationToken = default)
        {
            var newUser = new User
            {
                FullName = request.FullName,
                EmployeeId = request.EmployeeId,
                StatusId = request.Status,
                Email = request.Email,
                Mobile = request.Mobile,
                DepartmentId = request.Department,
                DesignationId = request.Designation,
                Password = request.Password.HashPassword()
            };

            await _userRepository.AddAsync(newUser, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            var userRoles = request.Roles.Select(x => new UserRole
            {
                UserId = newUser.Id,
                RoleId = x
            });
            await _userRoleRepository.AddRangeAsync(userRoles);

            UserProfile profile = new UserProfile { UserId = newUser.Id };
            await _userProfileRepository.AddAsync(profile, cancellationToken);

            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            return newUser.Id;
        }

        public async Task<bool> DeleteAsync(long userId, CancellationToken cancellationToken = default)
        {
            User user = await _userRepository.FirstOrDefaultAsync(x => x.Id == userId && !x.IsDeleted, true);

            if (user == null)
                throw new NotFoundException(USER_NOT_FOUND);

            user.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<UserViewModel> Get(long userId, CancellationToken cancellationToken = default)
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
                .Where(x => !x.IsDeleted)
                .Select(x => new UserViewModel
                {
                    Id = x.Id,
                    Email = x.Email,
                    EmployeeId = x.EmployeeId,
                    FullName = x.FullName,
                    Mobile = x.Mobile,
                    Department = x.Department != null ? new IdNameViewModel { Id = x.Department.Id, Name = x.Department.Name } : null,
                    Designation = x.Designation != null ? new IdNameViewModel { Id = x.Designation.Id, Name = x.Designation.Name } : null,
                    Status = x.Status != null ? new IdNameViewModel { Id = x.Status.Id, Name = x.Status.Name } : null,
                    Roles = roles
                })
                .FirstOrDefaultAsync(x => x.Id == userId);

            if (result == null)
                throw new NotFoundException(USER_NOT_FOUND);

            return result;
        }

        public async Task<PagedCollection<UserListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _userRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await itemsQuery
                .ApplyPagination(pagingOptions)
                .Select(x => new UserListViewModel
                {
                    Id = x.Id,
                    Designation = x.Designation.Name,
                    Mobile = x.Mobile,
                    FullName = x.FullName,
                    Email = x.Email,
                    Photo = _mediaService.GetPhotoUrl(x.Profile.Media),
                    Status = x.Status != null ? new IdNameViewModel { Id = x.Status.Id, Name = x.Status.Name } : null,
                })
                .ToListAsync();

            var total = await itemsQuery.Select(x => x.Id).CountAsync();

            var result = new PagedCollection<UserListViewModel>(items, total, pagingOptions);
            return result;
        }

        public async Task<bool> UpdateAsync(UserUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (user == null)
                throw new NotFoundException(USER_NOT_FOUND);

            user.FullName = request.FullName;
            user.EmployeeId = request.EmployeeId;
            user.DesignationId = request.Designation;
            user.DepartmentId = request.Department;
            user.Mobile = request.Mobile;
            user.StatusId = request.Status;

            if (!string.IsNullOrEmpty(request.Password))
            {
                user.Password = request.Password.HashPassword();
            }

            // delete old roles
            var oldRoles = _userRoleRepository.Where(x => x.UserId == user.Id);
            if (oldRoles != null)
                _userRoleRepository.RemoveRange(oldRoles);

            // add new roles
            var newRoles = request.Roles.Select(x => new UserRole
            {
                UserId = user.Id,
                RoleId = x
            });
            await _userRoleRepository.AddRangeAsync(newRoles);

            // update permissions
            if (request.Permissions != null && request.Permissions.Count > 0)
            {
                var r = await _permissionService.AssignUserPermission(user.Id, request.Permissions);
            }

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<long> CreateFromFrontendAsync(UserCreateFromFrontendRequest request, CancellationToken cancellationToken = default)
        {
            var newUser = new User
            {
                FullName = request.FullName,
                StatusId = StatusConstants.Pending,
                Email = request.Email,
                Mobile = request.Mobile,
                DesignationId = request.Designation,
                Password = request.Password.HashPassword()
            };

            await _userRepository.AddAsync(newUser, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            UserProfile profile = new UserProfile { UserId = newUser.Id };
            await _userProfileRepository.AddAsync(profile, cancellationToken);

            if (request.Media.HasValue)
            {
                profile.MediaId = request.Media;
                await _mediaService.UseAsync(request.Media.Value);
            }

            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            return newUser.Id;
        }

    }
}
