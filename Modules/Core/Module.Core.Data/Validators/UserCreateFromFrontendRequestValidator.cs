using FluentValidation;
using Infrastructure.Data;
using Module.Core.Shared;

using static Module.Core.Shared.MessageConstants;

namespace Module.Core.Data.Validators
{

    public class UserCreateFromFrontendRequestValidator : AbstractValidator<UserCreateFromFrontendRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserCreateFromFrontendRequestValidator(IUnitOfWork unitOfWork, UserCreateRequestValidatorOptions options = null)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.FullName).Required();
            RuleFor(x => x.Email).Email(_unitOfWork, null);
            RuleFor(x => x.Mobile).Mobile(_unitOfWork, null);
            RuleFor(x => x.Password)
                .NotEmpty().NotNull().When(x => string.IsNullOrEmpty(x.Password) && options != null && !options.IgnoreEmailValidation)
                .WithMessage(THIS_FIELD_IS_REQUIRED)
                .MinimumLength(4).When(x => string.IsNullOrEmpty(x.Password) && options != null && !options.IgnoreEmailValidation)
                .WithMessage(MUST_BE_EQUAL_OR_GREATER_THAN_X0_CHARACTERS.i18n(4));
        }

    }
}
