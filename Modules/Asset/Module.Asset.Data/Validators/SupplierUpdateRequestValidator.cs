using FluentValidation;
using Infrastructure.Data;

namespace Module.Asset.Data.Validators
{

    public class SupplierUpdateRequestValidator : AbstractValidator<SupplierUpdateRequest>
    {
        public SupplierUpdateRequestValidator(IUnitOfWork unitOfWork)
        {
            var validator = new SupplierCreateRequestValidator(unitOfWork);

            RuleFor(x => x).SetValidator(validator);

        }

    }
}
