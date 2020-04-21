using FluentValidation;
using Infrastructure.Data;
using Module.Asset.Entities;
using System.Threading.Tasks;


namespace Module.Asset.Data.Validators
{

    public class SupplierCreateRequestValidator : AbstractValidator<SupplierCreateRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierCreateRequestValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.Name).NotEmpty().NotNull()
                .WithMessage("Supplier name is required");
            RuleFor(x => x.Address).NotEmpty().NotNull()
           .WithMessage("Supplier Address is required");

            RuleFor(x => x.ContactName).NotEmpty().NotNull()
                .WithMessage("Contact Name is a required field");

            RuleFor(x => x.ContactEmail).NotEmpty().NotNull()
           .WithMessage("Contact Email is a required field")
            .EmailAddress().WithMessage("Invalid email.");

            RuleFor(x => x.ContactPhone).NotEmpty().NotNull()
           .WithMessage("Contact Phone is a required field");

        }

    }

}
