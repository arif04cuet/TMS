using FluentValidation;
using Infrastructure.Data;

namespace Module.Asset.Data.Validators
{

    public class DepreciationUpdateRequestValidator : AbstractValidator<DepreciationUpdateRequest>
    {
        public DepreciationUpdateRequestValidator(IUnitOfWork unitOfWork)
        {
            var validator = new DepreciationCreateRequestValidator(unitOfWork);

            RuleFor(x => x).SetValidator(validator);

        }

    }
}
