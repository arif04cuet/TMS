using FluentValidation;
using Infrastructure.Data;
using Module.Asset.Entities;
using System.Threading.Tasks;


namespace Module.Asset.Data.Validators
{

    public class ManufacturerCreateRequestValidator : AbstractValidator<ManufacturerCreateRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManufacturerCreateRequestValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.Name).NotEmpty().NotNull()
                .WithMessage("Manufacturer name is required");

            RuleFor(x => x.SupportEmail).NotEmpty().NotNull()
           .WithMessage("Manufacturer Support Email is required")
           .EmailAddress();

            RuleFor(x => x.SupportPhone).NotEmpty().NotNull()
                      .WithMessage("Manufacturer Support Phone is required");




        }

    }

}
