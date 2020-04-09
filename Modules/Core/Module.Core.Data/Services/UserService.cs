using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Security;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Core.Data
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;

        public UserService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
        }

        public async Task<long> CreateAsync(UserCreateRequest request, CancellationToken cancellationToken = default)
        {
            User newUser = new User
            {
                Email = request.Email,
                Password = request.Password.HashPassword()
            };

            await _userRepository.AddAsync(newUser, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return newUser.Id;
        }

        public async Task<bool> DeleteAsync(long userId, CancellationToken cancellationToken = default)
        {
            User user = await _userRepository.FirstOrDefaultAsync(x => x.Id == userId, true);

            if (user == null)
                throw new NotFoundException("User not found");

            _userRepository.Remove(user);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<UserViewModel> Get(long userId, CancellationToken cancellationToken = default)
        {
            var result = _userRepository
                .AsReadOnly()
                .Select(x => new UserViewModel
                {
                    Id = x.Id,
                    Email = x.Email
                })
                .FirstOrDefault(x => x.Id == userId);

            if (result == null)
                throw new NotFoundException("User not found");

            return await Task.FromResult(result);
        }

        public async Task<PagedCollection<UserListViewModel>> ListAsync(IPagingOptions pagingOptions, CancellationToken cancellationToken = default)
        {
            var items = await _userRepository
                .AsReadOnly()
                .Select(x => new UserListViewModel
                {
                    Id = x.Id,
                    Email = x.Email
                })
                .ApplyPagination(pagingOptions)
                .ToListAsync();

            var total = _userRepository.AsReadOnly().Count();

            var result = new PagedCollection<UserListViewModel>(items, total, pagingOptions);
            return result;
        }

        public async Task<bool> UpdateAsync(UserUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (user == null)
                throw new NotFoundException($"User not found");

            //TODO: update user

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

    }
}
