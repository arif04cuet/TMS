using FluentValidation;
using Infrastructure.Data;
using Module.Asset.Entities;
using System.Threading.Tasks;


namespace Module.Asset.Data.Validators
{

    public class LicenseCreateRequestValidator : AbstractValidator<LicenseCreateRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public LicenseCreateRequestValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.Name).NotEmpty().NotNull();

            RuleFor(x => x.ProductKey).NotEmpty().NotNull();

            RuleFor(x => x.Seats).NotEmpty().NotNull();

            RuleFor(x => x.LicenseToName).NotEmpty().NotNull();

            RuleFor(x => x.LicenseToEmail).NotEmpty().NotNull().EmailAddress();

            RuleFor(x => x.PurchaseDate).NotEmpty().NotNull();

            RuleFor(x => x.PurchaseCost).NotEmpty().NotNull();

            RuleFor(x => x.ExpireDate).NotEmpty().NotNull();
            RuleFor(x => x.CategoryId).NotEmpty().NotNull();

            RuleFor(x => x.ManufacturerId).NotEmpty().NotNull();
            RuleFor(x => x.SupplierId).NotEmpty().NotNull();
            //RuleFor(x => x.LocationId).NotEmpty().NotNull();
            RuleFor(x => x.DepreciationId).NotEmpty().NotNull();



        }

    }

}
