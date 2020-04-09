using FluentValidation;
using Infrastructure.Data;
using Module.Core.Entities;
using System.Threading.Tasks;

namespace Module.Core.Data.Validators
{

    public class UserCreateRequestValidator : AbstractValidator<UserCreateRequest>
    {
        public UserCreateRequestValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.FullName).NotEmpty().NotNull()
                .WithMessage($"{nameof(UserCreateRequest.FullName)} is required.");

            RuleFor(x => x.Email).NotEmpty().NotNull()
                .WithMessage($"{nameof(UserCreateRequest.Email)} is required.")
                .MustAsync(async (x, ct) => await IsValidEmailAsync(unitOfWork, x))
                .WithMessage($"{nameof(UserCreateRequest.Email)} not available.");

            RuleFor(x => x.EmployeeId).NotEmpty().NotNull()
                .WithMessage($"{nameof(UserCreateRequest.EmployeeId)} is required.");

            RuleFor(x => x.Mobile).NotEmpty().NotNull()
                .WithMessage($"{nameof(UserCreateRequest.Mobile)} is required.");

            RuleFor(x => x.Password).NotEmpty().NotNull()
                .WithMessage($"{nameof(UserCreateRequest.Password)} is required.")
                .MinimumLength(4)
                .WithMessage($"{nameof(UserCreateRequest.Password)} must be equal or greater than 4 characters.");

        }

        async Task<bool> IsValidEmailAsync(IUnitOfWork unitOfWork, string email)
        {
            var user = await unitOfWork.GetRepository<User>().FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());

            return user != null;
        }


    }
}
