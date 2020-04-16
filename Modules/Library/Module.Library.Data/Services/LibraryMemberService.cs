using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Entities;
using Module.Library.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Msi.UtilityKit.Security;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using static Module.Core.Shared.MessageConstants;

namespace Module.Library.Data
{
    public class LibraryMemberService : ILibraryMemberService
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IRepository<LibraryMember> _libraryMemberRepository;
        public readonly IRepository<User> _userRepository;

        public LibraryMemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _libraryMemberRepository = _unitOfWork.GetRepository<LibraryMember>();
            _userRepository = _unitOfWork.GetRepository<User>();
        }

        public async Task<long> CreateAsync(LibraryMemberCreateRequest request, CancellationToken ct = default)
        {
            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                Mobile = request.Mobile,
                StatusId = request.Status,
                Password = request.Password.HashPassword()
            };

            await _userRepository.AddAsync(user, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            var member = new LibraryMember
            {
                UserId = user.Id,
                LibraryId = request.Library,
                MemberSince = DateTime.UtcNow
            };
            await _libraryMemberRepository.AddAsync(member, ct);
            var result = await _unitOfWork.SaveChangesAsync(ct);
            return user.Id;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            var item = await _libraryMemberRepository
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

            if (item == null)
                throw new NotFoundException(LIBRARY_NOT_FOUND);

            _libraryMemberRepository.Remove(item);
            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

        public async Task<PagedCollection<LibraryMemberListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {
            var query = _libraryMemberRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await query
                .ApplyPagination(pagingOptions)
                .Select(x => new LibraryMemberListViewModel
                {
                    Id = x.Id,
                    Email = x.User.Email,
                    FullName = x.User.FullName,
                    Mobile = x.User.Mobile,
                    Photo = x.Id.ToString()
                })
                .ToListAsync();

            var total = await query.Select(x => x.Id).CountAsync();
            return new PagedCollection<LibraryMemberListViewModel>(items, total, pagingOptions);
        }

        public async Task<LibraryMemberViewModel> GetAsync(long id)
        {
            var result = await _libraryMemberRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new LibraryMemberViewModel
                {
                    Id = x.Id,
                    Email = x.User.Email,
                    FullName = x.User.FullName,
                    Mobile = x.User.Mobile,
                    Photo = x.Id.ToString()
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<bool> UpdateAsync(LibraryMemberUpdateRequest request, CancellationToken ct = default)
        {
            var item = await _libraryMemberRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.UserId == request.UserId);

            if (item == null)
                throw new NotFoundException(LIBRARY_NOT_FOUND);

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

    }
}
