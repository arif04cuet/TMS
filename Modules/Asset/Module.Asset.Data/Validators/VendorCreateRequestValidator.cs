using FluentValidation;
using Infrastructure.Data;
using Module.Asset.Entities;
using System.Threading.Tasks;


namespace Module.Asset.Data.Validators
{

    public class VendorCreateRequestValidator : AbstractValidator<VendorCreateRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public VendorCreateRequestValidator(IUnitOfWork unitOfWork, VendorCreateRequestValidatorOptions options = null)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.VendorName).NotEmpty().NotNull()
                .WithMessage("Vendor name is required");

            if (options == null || !options.IgnoreEmailValidation)
            {
                RuleFor(x => x.VendorEmail).NotEmpty().NotNull()
                    .WithMessage("Email is required")
                    .EmailAddress()
                    .WithMessage("Invalid email.")
                    .MustAsync(async (x, ct) => await IsValidEmailAsync(x))
                    .WithMessage($"Email is not available.");
            }

            RuleFor(x => x.AccountManagerName).NotEmpty().NotNull()
                .WithMessage("This is a required field");

            RuleFor(x => x.AccountManagerPhone).NotEmpty().NotNull()
                .WithMessage("This is a required field");
        }



        async Task<bool> IsValidEmailAsync(string email)
        {
            var user = await _unitOfWork.GetRepository<Vendor>().FirstOrDefaultAsync(x => x.VendorEmail.ToLower() == email.ToLower());
            return user == null;
        }

    }

    public class VendorCreateRequestValidatorOptions
    {
        public bool AllowEmptyPassword { get; set; }
        public bool IgnoreEmailValidation { get; set; }
    }
}
