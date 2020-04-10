using FluentValidation;
using Infrastructure.Data;

namespace Module.Core.Data.Validators
{

    public class UserUpdateRequestValidator : AbstractValidator<UserUpdateRequest>
    {
        public UserUpdateRequestValidator(IUnitOfWork unitOfWork)
        {
            var validator = new UserCreateRequestValidator(unitOfWork, new UserCreateRequestValidatorOptions
            {
                AllowEmptyPassword = true,
                IgnoreEmailValidation = true
            });

            RuleFor(x => x).SetValidator(validator);

        }

    }
}
