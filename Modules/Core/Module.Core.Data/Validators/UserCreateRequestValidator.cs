using FluentValidation;
using Infrastructure.Data;
using Module.Core.Entities;
using Module.Core.Shared;
using System.Threading.Tasks;

using static Module.Core.Shared.MessageConstants;

namespace Module.Core.Data.Validators
{

    public class UserCreateRequestValidator : AbstractValidator<UserCreateRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserCreateRequestValidator(IUnitOfWork unitOfWork, UserCreateRequestValidatorOptions options = null)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.FullName).Required();

            if (options == null || !options.IgnoreEmailValidation)
            {
                RuleFor(x => x.Email)
                    .Required()
                    .EmailAddress()
                    .WithMessage(INVALID_EMAIL)
                    .MustAsync(async (x, ct) => await IsValidEmailAsync(x))
                    .WithMessage(EMAIL_IS_NOT_AVAILABLE);
            }

            RuleFor(x => x.EmployeeId).Required();
            RuleFor(x => x.Mobile).Required();

            RuleFor(x => x.Password)
                .NotEmpty().NotNull().When(x => string.IsNullOrEmpty(x.Password) && options != null && !options.IgnoreEmailValidation)
                .WithMessage(THIS_FIELD_IS_REQUIRED)
                .MinimumLength(4).When(x => string.IsNullOrEmpty(x.Password) && options != null && !options.IgnoreEmailValidation)
                .WithMessage(MUST_BE_EQUAL_OR_GREATER_THAN_X0_CHARACTERS.i18n(4));

            RuleFor(x => x.Roles).Required();
        }

        bool IsValidRolesAsync(long[] roles)
        {
            if (roles == null && roles.Length <= 0)
                return false;
            return true;
        }

        async Task<bool> IsValidEmailAsync(string email)
        {
            var user = await _unitOfWork.GetRepository<User>()
                .FirstOrDefaultAsync(x => !x.IsDeleted && x.Email.ToLower() == email.ToLower(), true);
            return user == null;
        }

    }

    public class UserCreateRequestValidatorOptions
    {
        public bool AllowEmptyPassword { get; set; }
        public bool IgnoreEmailValidation { get; set; }
    }
}
