using FluentValidation;
using Infrastructure.Data;
using Module.Core.Entities;
using System.Threading.Tasks;

using static Module.Core.Data.Constants.MessageConstants;

namespace Module.Core.Data.Validators
{

    public class UserCreateRequestValidator : AbstractValidator<UserCreateRequest>
    {
        public UserCreateRequestValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.FullName).NotEmpty().NotNull()
                .WithMessage(THIS_FIELD_IS_REQUIRED);

            RuleFor(x => x.Email).NotEmpty().NotNull()
                .WithMessage(THIS_FIELD_IS_REQUIRED)
                .MustAsync(async (x, ct) => await IsValidEmailAsync(unitOfWork, x))
                .WithMessage($"Email is not available.");

            RuleFor(x => x.EmployeeId).NotEmpty().NotNull()
                .WithMessage(THIS_FIELD_IS_REQUIRED);

            RuleFor(x => x.Mobile).NotEmpty().NotNull()
                .WithMessage(THIS_FIELD_IS_REQUIRED);

            RuleFor(x => x.Password).NotEmpty().NotNull()
                .WithMessage(THIS_FIELD_IS_REQUIRED)
                .MinimumLength(4)
                .WithMessage($"{nameof(UserCreateRequest.Password)} must be equal or greater than 4 characters.");

        }

        async Task<bool> IsValidEmailAsync(IUnitOfWork unitOfWork, string email)
        {
            var user = await unitOfWork.GetRepository<User>().FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());

            return user == null;
        }


    }
}
