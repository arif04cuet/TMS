using FluentValidation;
using Infrastructure.Data;

namespace Module.Asset.Data.Validators
{

    public class ItemCodeUpdateRequestValidator : AbstractValidator<ItemCodeUpdateRequest>
    {
        public ItemCodeUpdateRequestValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x).SetValidator(x => new ItemCodeCreateRequestValidator(unitOfWork, x.Id));
        }

    }
}
