using FluentValidation;

using static Module.Core.Shared.MessageConstants;

namespace Module.Core.Shared
{
    public static class ValidatorExtensions
    {

        public static IRuleBuilderOptions<T, TProperty> Required<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                .WithMessage(THIS_FIELD_IS_REQUIRED)
                .NotEmpty()
                .WithMessage(THIS_FIELD_IS_REQUIRED);
        }

    }
}
