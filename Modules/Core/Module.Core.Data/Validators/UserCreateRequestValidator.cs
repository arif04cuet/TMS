using FluentValidation;
using Infrastructure.Data;
using Module.Core.Shared;

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
                RuleFor(x => x.Email).Null().Email(_unitOfWork, null);
            }

            RuleFor(x => x.EmployeeId).EmployeeId(_unitOfWork, options.IgnoreUserId);

            RuleFor(x => x.Mobile).Mobile(_unitOfWork, options.IgnoreUserId);

            RuleFor(x => x.Password)
                .NotEmpty().NotNull().When(x => string.IsNullOrEmpty(x.Password) && options != null && !options.IgnoreEmailValidation)
                .WithMessage(THIS_FIELD_IS_REQUIRED)
                .MinimumLength(4).When(x => string.IsNullOrEmpty(x.Password) && options != null && !options.IgnoreEmailValidation)
                .WithMessage(MUST_BE_EQUAL_OR_GREATER_THAN_X0_CHARACTERS.i18n(4));

            RuleFor(x => x.Roles).Required();
        }

    }

    public class UserCreateRequestValidatorOptions
    {
        public bool AllowEmptyPassword { get; set; }
        public bool IgnoreEmailValidation { get; set; }
        public long? IgnoreUserId { get; set; }
    }
}
