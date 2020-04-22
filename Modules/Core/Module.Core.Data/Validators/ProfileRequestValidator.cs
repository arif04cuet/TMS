using FluentValidation;
using Infrastructure.Data;
using Module.Core.Shared;

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

            RuleFor(x => x.FullName).Required();
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
