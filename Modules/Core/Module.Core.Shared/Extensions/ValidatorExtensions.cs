using FluentValidation;
using FluentValidation.Validators;
using Infrastructure.Data;
using static Module.Core.Shared.MessageConstants;

namespace Module.Core.Shared
{
    public static class ValidatorExtensions
    {

        public static IRuleBuilderOptions<T, TProperty> Required<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder
                .NotNull()
                .WithMessage(THIS_FIELD_IS_REQUIRED)
                .NotEmpty()
                .WithMessage(THIS_FIELD_IS_REQUIRED);
        }

        public static IRuleBuilderOptions<T, TProperty> Mobile<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, IUnitOfWork unitOfWork)
        {
            return ruleBuilder
                .Required()
                .SetValidator(new UniqueMobileValidator(unitOfWork))
                .WithMessage("Mobile is not available");
        }

        public static IRuleBuilderOptions<T, TProperty> EmployeeId<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, IUnitOfWork unitOfWork)
        {
            return ruleBuilder
                .Required()
                .SetValidator(new UniqueEmployeeIdValidator(unitOfWork))
                .WithMessage("Employee ID is not available");
        }

        public static IRuleBuilderOptions<T, TProperty> Email<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, IUnitOfWork unitOfWork)
        {
            return ruleBuilder
                .Required()
                .SetValidator(new EmailValidator())
                .WithMessage(INVALID_EMAIL)
                .SetValidator(new UniqueEmailValidator(unitOfWork))
                .WithMessage(EMAIL_IS_NOT_AVAILABLE);
        }

    }
}
