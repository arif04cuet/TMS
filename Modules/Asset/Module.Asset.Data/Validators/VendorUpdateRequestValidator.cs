using FluentValidation;
using Infrastructure.Data;

namespace Module.Asset.Data.Validators
{

    public class VendorUpdateRequestValidator : AbstractValidator<VendorUpdateRequest>
    {
        public VendorUpdateRequestValidator(IUnitOfWork unitOfWork)
        {
            var validator = new VendorCreateRequestValidator(unitOfWork, new VendorCreateRequestValidatorOptions
            {
                AllowEmptyPassword = true,
                IgnoreEmailValidation = true
            });

            RuleFor(x => x).SetValidator(validator);

        }

    }
}
