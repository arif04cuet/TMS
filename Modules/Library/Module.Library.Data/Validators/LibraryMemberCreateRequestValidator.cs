using FluentValidation;
using Infrastructure.Data;
using Module.Core.Entities;
using System.Threading.Tasks;
using Module.Core.Shared;

using static Module.Core.Shared.MessageConstants;
using System.Threading;

namespace Module.Library.Data.Validators
{
    public class LibraryMemberCreateRequestValidator : AbstractValidator<LibraryMemberCreateRequest>
    {

        private readonly IUnitOfWork _unitOfWork;
        public LibraryMemberCreateRequestValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.Email)
                .Required()
                .EmailAddress()
                .WithMessage(INVALID_EMAIL)
                .MustAsync((x, ct) => IsValidEmailAsync(x, ct))
                .WithMessage(EMAIL_IS_NOT_AVAILABLE);
        }

        private async Task<bool> IsValidEmailAsync(string email, CancellationToken ct = default)
        {
            var user = await _unitOfWork.GetRepository<User>()
                .FirstOrDefaultAsync(x => !x.IsDeleted && x.Email.ToLower() == email.ToLower(), true, ct);

            return user == null;
        }

    }
}
