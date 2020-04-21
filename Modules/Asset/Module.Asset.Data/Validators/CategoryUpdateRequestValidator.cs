using FluentValidation;
using Infrastructure.Data;

namespace Module.Asset.Data.Validators
{

    public class CategoryUpdateRequestValidator : AbstractValidator<CategoryUpdateRequest>
    {
        public CategoryUpdateRequestValidator(IUnitOfWork unitOfWork)
        {
            var validator = new CategoryCreateRequestValidator(unitOfWork);

            RuleFor(x => x).SetValidator(validator);

        }

    }
}
