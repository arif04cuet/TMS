using FluentValidation;
using Infrastructure.Data;
using Module.Asset.Entities;
using System.Threading.Tasks;


namespace Module.Asset.Data.Validators
{

    public class DepreciationCreateRequestValidator : AbstractValidator<DepreciationCreateRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepreciationCreateRequestValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.Name).NotEmpty().NotNull()
                .WithMessage("Depreciation name is required");
            RuleFor(x => x.Term).NotEmpty().NotNull()
           .WithMessage("Depreciation Term is required");

        }

    }

}
