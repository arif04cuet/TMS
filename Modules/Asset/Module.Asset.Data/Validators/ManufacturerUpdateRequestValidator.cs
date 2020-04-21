using FluentValidation;
using Infrastructure.Data;

namespace Module.Asset.Data.Validators
{

    public class ManufacturerUpdateRequestValidator : AbstractValidator<ManufacturerUpdateRequest>
    {
        public ManufacturerUpdateRequestValidator(IUnitOfWork unitOfWork)
        {
            var validator = new ManufacturerCreateRequestValidator(unitOfWork);

            RuleFor(x => x).SetValidator(validator);

        }

    }
}
