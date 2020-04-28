using FluentValidation;
using Infrastructure.Data;

namespace Module.Asset.Data.Validators
{

    public class LicenseUpdateRequestValidator : AbstractValidator<LicenseUpdateRequest>
    {
        public LicenseUpdateRequestValidator(IUnitOfWork unitOfWork)
        {
            var validator = new LicenseCreateRequestValidator(unitOfWork);

            RuleFor(x => x).SetValidator(validator);

        }

    }
}
