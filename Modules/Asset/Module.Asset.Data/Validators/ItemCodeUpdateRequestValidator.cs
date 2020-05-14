using FluentValidation;
using Infrastructure.Data;

namespace Module.Asset.Data.Validators
{

    public class ItemCodeUpdateRequestValidator : AbstractValidator<ItemCodeUpdateRequest>
    {
        public ItemCodeUpdateRequestValidator(IUnitOfWork unitOfWork)
        {
            var validator = new ItemCodeCreateRequestValidator(unitOfWork);

            RuleFor(x => x).SetValidator(validator);

        }

    }
}
