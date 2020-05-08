using FluentValidation;
using Infrastructure.Data;

namespace Module.Core.Data.Validators
{

    public class UserUpdateRequestValidator : AbstractValidator<UserUpdateRequest>
    {
        public UserUpdateRequestValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x).SetValidator(request =>
            {
                return new UserCreateRequestValidator(unitOfWork, new UserCreateRequestValidatorOptions
                {
                    AllowEmptyPassword = true,
                    IgnoreEmailValidation = true,
                    IgnoreUserId = request.Id
                });
            });

        }

    }
}
