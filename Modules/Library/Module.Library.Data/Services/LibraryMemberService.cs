using Dapper;
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
        public readonly IRepository<LibraryCard> _libraryCardRepository;
        public readonly IMediaService _mediaService;

        public LibraryMemberService(
            IUnitOfWork unitOfWork,
            IUserService userService,
            IMediaService mediaService)
        {
            _mediaService = mediaService;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _libraryMemberRepository = _unitOfWork.GetRepository<LibraryMember>();
            _userRepository = _unitOfWork.GetRepository<User>();
            _userRoleRepository = _unitOfWork.GetRepository<UserRole>();
            _libraryCardRepository = _unitOfWork.GetRepository<LibraryCard>();
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

            var card = await _libraryCardRepository
                .FirstOrDefaultAsync(x => x.Id == request.CardId && !x.IsDeleted && x.MemberId == null);

            if (card == null)
                throw new ValidationException(LIBRARY_CARD_NOT_FOUND);

            member = new LibraryMember
            {
                UserId = user.Id,
                LibraryId = request.Library,
                MemberSince = request.MemberSince ?? DateTime.Now
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

            card.MemberId = user.Id;
            card.ExpireDate = request.CardExpireDate;
            member.CurrentCardId = card.Id;

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return user.Id;
        }

        public async Task<long> CreateAsync(LibraryMemberCreateRequest request, CancellationToken ct = default)
        {

            var card = await _libraryCardRepository
                .FirstOrDefaultAsync(x => x.Id == request.CardId && !x.IsDeleted && x.MemberId == null);

            if (card == null)
                throw new ValidationException(LIBRARY_CARD_NOT_FOUND);

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

            card.MemberId = user.Id;
            card.ExpireDate = request.CardExpireDate;

            member.CurrentCardId = card.Id;

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
            
            item.IsDeleted = true;

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
                    UserId = x.UserId,
                    Email = x.User.Email,
                    FullName = x.User.FullName,
                    Mobile = x.User.Mobile,
                    Library = new IdNameViewModel
                    {
                        Id = x.Library.Id,
                        Name = x.Library.Name
                    },
                    Photo = _mediaService.GetFullUrl(x.User.Profile.Media)
                })
                .ToListAsync();

            var total = await query.Select(x => x.Id).CountAsync();
            return new PagedCollection<LibraryMemberListViewModel>(items, total, pagingOptions);
        }

        public async Task<PagedCollection<IdNameViewModel>> ListMemberCardsAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {

            var sql = @"select  c.Id, c.Barcode as Name from [library].[LibraryMember] m
                        left join [library].[LibraryCard] c on c.Id = m.CurrentCardId
                        where m.CurrentCardId IS NOT NULL";

            var items = await _unitOfWork.GetConnection()
                .QueryAsync<IdNameViewModel>(sql);

            var total = items.Count();
            return new PagedCollection<IdNameViewModel>(items.ToList(), total, pagingOptions);
        }


        public async Task<LibraryMemberViewModel> GetAsync(long id)
        {
            var result = await _libraryMemberRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Include(x => x.CurrentCard)
                .Select(x => new LibraryMemberViewModel
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Email = x.User.Email,
                    FullName = x.User.FullName,
                    Mobile = x.User.Mobile,
                    Status = IdNameViewModel.Map(x.User.Status),
                    Library = new IdNameViewModel
                    {
                        Id = x.Library.Id,
                        Name = x.Library.Name
                    },
                    MemberSince = x.MemberSince,
                    Photo = x.Id.ToString(),
                    Card = x.CurrentCardId != null ? new LibraryCardViewModel
                    {
                        ExpireDate = x.CurrentCard.ExpireDate,
                        Id = x.CurrentCard.Id,
                        Barcode = x.CurrentCard.Barcode,
                        Status = IdNameViewModel.Map(x.CurrentCard.CardStatus),
                        CardType = IdNameViewModel.Map(x.CurrentCard.CardType),
                        Fees = x.CurrentCard.Fees,
                        MaxIssueCount = x.CurrentCard.MaxIssueCount
                    } : null
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<bool> UpdateAsync(LibraryMemberUpdateRequest request, CancellationToken ct = default)
        {
            var member = await _libraryMemberRepository
                .AsQueryable()
                .Include(x => x.CurrentCard)
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            var user = await _userRepository
                .FirstOrDefaultAsync(x => x.Id == member.UserId && !x.IsDeleted);

            if (member == null || user == null)
                throw new NotFoundException(LIBRARY_MEMBER_NOT_FOUND);

            member.LibraryId = request.Library;
            if (request.MemberSince.HasValue)
            {
                member.MemberSince = request.MemberSince.Value;
            }

            user.Mobile = request.Mobile;
            user.FullName = request.FullName;
            user.StatusId = request.Status;
            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                user.Password = request.Password.HashPassword();
            }

            if (member.CurrentCard != null)
            {
                member.CurrentCard.ExpireDate = request.CardExpireDate;
            }

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

    }
}
