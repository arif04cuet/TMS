using FluentValidation;
using Infrastructure.Data;

namespace Module.Asset.Data.Validators
{

    public class LocationUpdateRequestValidator : AbstractValidator<LocationUpdateRequest>
    {
        public LocationUpdateRequestValidator(IUnitOfWork unitOfWork)
        {
            var validator = new LocationCreateRequestValidator(unitOfWork);

            RuleFor(x => x).SetValidator(validator);

        }

    }
}
