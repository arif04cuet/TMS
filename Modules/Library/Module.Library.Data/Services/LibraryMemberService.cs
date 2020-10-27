using Dapper;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Services;
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
        public readonly IRepository<LibraryMemberRequest> _libraryMemberRequestRepository;
        public readonly IRepository<User> _userRepository;
        public readonly IRepository<UserRole> _userRoleRepository;
        public readonly IUserService _userService;
        public readonly IRepository<LibraryCard> _libraryCardRepository;
        public readonly IRepository<UserProfile> _userProfileRepository;
        public readonly IMediaService _mediaService;
        public readonly IEmailSender _emailSender;
        public readonly IRazorViewRenderer _viewRenderer;

        public LibraryMemberService(
            IUnitOfWork unitOfWork,
            IUserService userService,
            IMediaService mediaService,
            IEmailSender emailSender,
            IRazorViewRenderer viewRenderer)
        {
            _mediaService = mediaService;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _emailSender = emailSender;
            _viewRenderer = viewRenderer;
            _libraryMemberRepository = _unitOfWork.GetRepository<LibraryMember>();
            _userRepository = _unitOfWork.GetRepository<User>();
            _userRoleRepository = _unitOfWork.GetRepository<UserRole>();
            _libraryCardRepository = _unitOfWork.GetRepository<LibraryCard>();
            _libraryMemberRequestRepository = _unitOfWork.GetRepository<LibraryMemberRequest>();
            _userProfileRepository = _unitOfWork.GetRepository<UserProfile>();
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
                MemberSince = request.MemberSince ?? DateTime.UtcNow
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
            card.IssueDate = DateTime.UtcNow;
            member.CurrentCardId = card.Id;

            await AddOrUpdateUserPhoto(user.Id, request.Photo);

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
                Password = request.Password.HashPassword(),
            };

            await _userRepository.AddAsync(user, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            var member = new LibraryMember
            {
                UserId = user.Id,
                LibraryId = request.Library,
                MemberSince = request.MemberSince.HasValue ? request.MemberSince.Value : DateTime.UtcNow
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
            card.IssueDate = DateTime.UtcNow;

            member.CurrentCardId = card.Id;

            await AddOrUpdateUserPhoto(user.Id, request.Photo);

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return user.Id;
        }

        public async Task<long> ApproveMemberAsync(LibraryMemberApproveCreateRequest request, CancellationToken ct = default)
        {
            long count = 0;
            foreach (var id in request.Ids)
            {
                var memberRequest = await _libraryMemberRequestRepository
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

                if (memberRequest == null)
                    throw new ValidationException("Member request not found");

                if (memberRequest.IsApproved)
                    throw new ValidationException("Member already approved");

                var isUserExist = (await _userRepository
                    .AsReadOnly()
                    .Where(x => (x.Email == memberRequest.Email || x.Mobile == memberRequest.Mobile) && !x.IsDeleted)
                    .Select(x => x.Id)
                    .CountAsync()) > 0;

                if (isUserExist)
                    throw new ValidationException("User already exist with requested user's email or mobile.");

                var user = new User
                {
                    FullName = memberRequest.FullName,
                    Email = memberRequest.Email,
                    Mobile = memberRequest.Mobile,
                    StatusId = StatusConstants.Pending,
                    Password = memberRequest.Password
                };
                await _userRepository.AddAsync(user, ct);
                var result = await _unitOfWork.SaveChangesAsync(ct);

                var member = new LibraryMember
                {
                    UserId = user.Id,
                    LibraryId = memberRequest.LibraryId,
                    MemberSince = DateTime.UtcNow
                };
                await _libraryMemberRepository.AddAsync(member, ct);
                memberRequest.IsApproved = true;

                var role = new UserRole
                {
                    UserId = user.Id,
                    RoleId = RoleConstants.LibraryMember
                };
                await _userRoleRepository.AddAsync(role, ct);

                result += await _unitOfWork.SaveChangesAsync(ct);
                count++;

                var htmlContent = await _viewRenderer.RenderViewToStringAsync("/Views/library-member-acceptance.cshtml", new LibraryMemberAcceptanceModel { Name = memberRequest.FullName });
                _ = _emailSender.SendAsync(memberRequest.Email, "Request Approved", htmlContent);
            }

            return count;
        }

        public async Task<long> CreateRequestAsync(LibraryMemberRequestCreateRequest request, CancellationToken ct = default)
        {
            var memberRequest = new LibraryMemberRequest
            {
                LibraryId = request.Library,
                RequestDate = DateTime.UtcNow,
                FullName = request.FullName,
                Mobile = request.Mobile,
                Email = request.Email,
                Password = request.Password.HashPassword()
            };
            await _libraryMemberRequestRepository.AddAsync(memberRequest, ct);
            var result = await _unitOfWork.SaveChangesAsync(ct);
            return memberRequest.Id;
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
            return await _libraryMemberRepository.ListAsync(LibraryMemberListViewModel.Select2(_mediaService), pagingOptions, searchOptions);
        }

        public async Task<PagedCollection<LibraryMemberRequestListViewModel>> ListMemberRequestAsync(bool? isApproved, IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {
            var query = _libraryMemberRequestRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            if (isApproved.HasValue)
            {
                query = query.Where(x => x.IsApproved == isApproved.Value);
            }

            var items = await query
                .ApplyPagination(pagingOptions)
                .Select(LibraryMemberRequestListViewModel.SelectRequest(_mediaService))
                .ToListAsync();

            var total = await query.Select(x => x.Id).CountAsync();
            return new PagedCollection<LibraryMemberRequestListViewModel>(items, total, pagingOptions);
        }

        public async Task<PagedCollection<LibraryMemberCardListViewModel>> ListMemberCardsAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {

            var sql = @"select u.FullName Member, c.Id, c.Barcode as Name from [library].[LibraryMember] m
                        left join [library].[LibraryCard] c on c.Id = m.CurrentCardId
                        left join [core].[User] u on u.Id = m.UserId
                        where m.CurrentCardId IS NOT NULL";

            var items = await _unitOfWork.GetConnection()
                .QueryAsync<LibraryMemberCardListViewModel>(sql);

            var total = items.Count();
            return new PagedCollection<LibraryMemberCardListViewModel>(items.ToList(), total, pagingOptions);
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
                    Photo = x.User != null && x.User.Profile != null ? _mediaService.GetPhotoUrl(x.User.Profile.Media) : null,
                    Card = x.CurrentCardId != null ? new LibraryCardViewModel
                    {
                        ExpireDate = x.CurrentCard.ExpireDate,
                        Id = x.CurrentCard.Id,
                        Barcode = x.CurrentCard.Barcode,
                        Status = IdNameViewModel.Map(x.CurrentCard.CardStatus),
                        CardType = IdNameViewModel.Map(x.CurrentCard.CardType),
                        CardFee = x.CurrentCard.CardFee,
                        LateFee = x.CurrentCard.LateFee,
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

            if (member.CurrentCardId == null)
            {
                var card = await _libraryCardRepository
                    .FirstOrDefaultAsync(x => x.Id == request.CardId && !x.IsDeleted && x.MemberId == null);

                if (card == null)
                    throw new ValidationException(LIBRARY_CARD_NOT_FOUND);

                card.MemberId = user.Id;
                card.ExpireDate = request.CardExpireDate;
                member.CurrentCardId = card.Id;
            }
            else
            {
                member.CurrentCard.ExpireDate = request.CardExpireDate;
            }

            var profile = await _userProfileRepository.FirstOrDefaultAsync(x => x.UserId == user.Id && !x.IsDeleted);
            if (profile != null && request.Photo.HasValue && profile.MediaId != request.Photo)
            {
                // photo changed
                long? oldMediaId = profile.MediaId;
                profile.MediaId = request.Photo;
                await _mediaService.UseAsync(request.Photo.Value);
                _ = _mediaService.DeleteMediaAsync(oldMediaId);
            }
            if (profile == null && request.Photo.HasValue)
            {
                profile = new UserProfile
                {
                    UserId = user.Id,
                    MediaId = request.Photo
                };
                await _userProfileRepository.AddAsync(profile);
            }

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

        private async Task AddOrUpdateUserPhoto(long userId, long? photoId)
        {
            if (photoId.HasValue)
            {
                var profile = await _userProfileRepository.FirstOrDefaultAsync(x => x.UserId == userId && !x.IsDeleted);

                if (profile == null)
                {
                    profile = new UserProfile
                    {
                        UserId = userId,
                        MediaId = photoId
                    };
                    await _userProfileRepository.AddAsync(profile);
                }
                else
                {
                    profile.MediaId = photoId;
                }
            }
        }
    }
}
