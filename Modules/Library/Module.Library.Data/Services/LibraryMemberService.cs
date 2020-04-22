using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
using Module.Core.Entities;
using Module.Core.Shared;
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
        public readonly IRepository<UserRole> _userRoleRepository;
        public readonly IUserService _userService;
        public readonly IRepository<MemberLibraryCard> _memberLibraryCardRepository;

        public LibraryMemberService(
            IUnitOfWork unitOfWork,
            IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
            _libraryMemberRepository = _unitOfWork.GetRepository<LibraryMember>();
            _userRepository = _unitOfWork.GetRepository<User>();
            _userRoleRepository = _unitOfWork.GetRepository<UserRole>();
            _memberLibraryCardRepository = _unitOfWork.GetRepository<MemberLibraryCard>();
        }

        public async Task<long> CreateFromUserAsync(LibraryMemberCreateFromUserRequest request, CancellationToken ct = default)
        {
            var user = await _userRepository
                .FirstOrDefaultAsync(x => x.Id == request.User && !x.IsDeleted, true, ct);

            if (user == null)
                throw new NotFoundException(USER_NOT_FOUND);

            // check already a member
            var member = await _libraryMemberRepository
                .FirstOrDefaultAsync(x => x.UserId == user.Id, true, ct);

            if (member != null)
                throw new ValidationException(ALREADY_A_MEMBER);

            member = new LibraryMember
            {
                UserId = user.Id,
                LibraryId = request.Library,
                MemberSince = request.MemberSince.HasValue ? request.MemberSince.Value : DateTime.Now
            };
            await _libraryMemberRepository.AddAsync(member, ct);

            // check library member role
            var role = await _userRoleRepository
                .FirstOrDefaultAsync(x => x.UserId == user.Id && x.RoleId == RoleConstants.LibraryMember, true, ct);

            if (role == null)
            {
                role = new UserRole
                {
                    UserId = user.Id,
                    RoleId = RoleConstants.LibraryMember
                };
                await _userRoleRepository.AddAsync(role, ct);
            }

            if (request.Card != null)
            {
                var card = request.Card.ToMemberLibraryCard(user.Id);
                await _memberLibraryCardRepository.AddAsync(card, ct);
            }

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return user.Id;
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
                MemberSince = request.MemberSince.HasValue ? request.MemberSince.Value : DateTime.Now
            };
            await _libraryMemberRepository.AddAsync(member, ct);

            var role = new UserRole
            {
                UserId = user.Id,
                RoleId = RoleConstants.LibraryMember
            };
            await _userRoleRepository.AddAsync(role, ct);

            if (request.Card != null)
            {
                var card = request.Card.ToMemberLibraryCard(user.Id);
                await _memberLibraryCardRepository.AddAsync(card, ct);
            }

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return user.Id;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            var item = await _libraryMemberRepository
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

            var user = await _userRepository
                .FirstOrDefaultAsync(x => x.Id == item.UserId);

            if (item == null || user == null)
                throw new NotFoundException(LIBRARY_MEMBER_NOT_FOUND);
            _libraryMemberRepository.Remove(item);

            await _userService.DeleteAsync(item.UserId);

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
                    Library = new IdNameViewModel
                    {
                        Id = x.Library.Id,
                        Name = x.Library.Name
                    },
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
                    UserId = x.UserId,
                    Email = x.User.Email,
                    FullName = x.User.FullName,
                    Mobile = x.User.Mobile,
                    Status = new IdNameViewModel
                    {
                        Id = x.User.Status.Id,
                        Name = x.User.Status.Name
                    },
                    Library = new IdNameViewModel
                    {
                        Id = x.Library.Id,
                        Name = x.Library.Name
                    },
                    MemberSince = x.MemberSince,
                    Photo = x.Id.ToString(),
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result != null)
            {
                var card = await _unitOfWork.GetRepository<MemberLibraryCard>()
                    .AsReadOnly()
                    .Where(x => x.UserId == result.UserId && !x.IsDeleted)
                    .Select(x => new MemberLibraryCardViewModel
                    {
                        Card = new IdNameViewModel
                        {
                            Id = x.LibraryCard.Id,
                            Name = x.LibraryCard.Name
                        },
                        ExpireDate = x.CardExpireDate,
                        Id = x.Id,
                        Number = x.CardNumber,
                        Status = new IdNameViewModel
                        {
                            Id = x.CardStatus.Id,
                            Name = x.CardStatus.Name
                        }
                    })
                    .FirstOrDefaultAsync();
                result.Card = card;
            }

            return result;
        }

        public async Task<bool> UpdateAsync(LibraryMemberUpdateRequest request, CancellationToken ct = default)
        {
            var item = await _libraryMemberRepository
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            var user = await _userRepository
                .FirstOrDefaultAsync(x => x.Id == item.UserId && !x.IsDeleted);

            if (item == null || user == null)
                throw new NotFoundException(LIBRARY_MEMBER_NOT_FOUND);

            item.LibraryId = request.Library;
            if (request.MemberSince.HasValue)
            {
                item.MemberSince = request.MemberSince.Value;
            }

            user.Mobile = request.Mobile;
            user.FullName = request.FullName;
            user.StatusId = request.Status;
            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                user.Password = request.Password.HashPassword();
            }

            var card = await _memberLibraryCardRepository
                .FirstOrDefaultAsync(x => x.UserId == user.Id && !x.IsDeleted);

            if (card != null && request.Card != null)
            {
                request.Card.MapTo(card);
            }

            if (card == null && request.Card != null)
            {
                card = request.Card.ToMemberLibraryCard(user.Id);
                await _memberLibraryCardRepository.AddAsync(card, ct);
            }

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

        public async Task<PagedCollection<IdNameViewModel>> GetCardsAsync(long memberId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {
            var userId = await GetUserIdByMemberIdAsync(memberId);
            var query = _memberLibraryCardRepository
                .Where(x => x.UserId == userId.Value)
                .ApplySearch(searchOptions);

            var items = await query
                .ApplyPagination(pagingOptions)
                .Select(x => new IdNameViewModel
                {
                    Id = x.Id,
                    Name = x.CardNumber
                })
                .ToListAsync();

            var total = await query.Select(x => x.Id).CountAsync();
            return new PagedCollection<IdNameViewModel>(items, total, pagingOptions);
        }

        private async Task<long?> GetUserIdByMemberIdAsync(long memberId)
        {
            var user = await _libraryMemberRepository
                .Where(x => x.Id == memberId && !x.IsDeleted)
                .Select(x => new { Id = x.UserId })
                .FirstOrDefaultAsync();
            return user?.Id;
        }

    }
}
