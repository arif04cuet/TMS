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
                RuleFor(x => x.Email).Email(_unitOfWork);
            }

            RuleFor(x => x.EmployeeId).EmployeeId(_unitOfWork);
            RuleFor(x => x.Mobile).Mobile(_unitOfWork);

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
        public bool IsUpdateMode { get; set; }
    }
}
