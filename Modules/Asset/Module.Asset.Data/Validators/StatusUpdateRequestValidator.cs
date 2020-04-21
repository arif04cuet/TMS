using FluentValidation;
using Infrastructure.Data;

namespace Module.Asset.Data.Validators
{

    public class StatusUpdateRequestValidator : AbstractValidator<StatusUpdateRequest>
    {
        public StatusUpdateRequestValidator(IUnitOfWork unitOfWork)
        {
            var validator = new StatusCreateRequestValidator(unitOfWork);

            RuleFor(x => x).SetValidator(validator);

        }

    }
}
