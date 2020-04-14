using FluentValidation;
using Infrastructure.Data;

using static Module.Core.Shared.MessageConstants;

namespace Module.Core.Data.Validators
{

    public class ProfileRequestValidator : AbstractValidator<ProfileRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfileRequestValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x)
                .Must(x => IsValidPassword(x))
                .WithMessage(PASSWORD_NOT_MATCHED);

            RuleFor(x => x.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage(THIS_FIELD_IS_REQUIRED);
        }

        bool IsValidPassword(ProfileRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.ConfirmPassword) && request.Password != request.ConfirmPassword)
            {
                return false;
            }
            return true;
        }

    }
}
