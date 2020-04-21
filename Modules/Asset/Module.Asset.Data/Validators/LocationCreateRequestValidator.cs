using FluentValidation;
using Infrastructure.Data;
using Module.Asset.Entities;
using System.Threading.Tasks;


namespace Module.Asset.Data.Validators
{

    public class LocationCreateRequestValidator : AbstractValidator<LocationCreateRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocationCreateRequestValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.Name).NotEmpty().NotNull()
                .WithMessage("Location name is required");
            RuleFor(x => x.Address).NotEmpty().NotNull()
           .WithMessage("Location Term is required");

        }

    }

}
