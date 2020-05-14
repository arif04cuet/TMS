using FluentValidation;
using Infrastructure.Data;
using Module.Asset.Entities;
using System.Threading.Tasks;


namespace Module.Asset.Data.Validators
{

    public class ItemCodeCreateRequestValidator : AbstractValidator<ItemCodeCreateRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemCodeCreateRequestValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.Name).NotEmpty().NotNull()
                .WithMessage("ItemCode name is required");
            RuleFor(x => x.Code).NotEmpty().NotNull()
                            .WithMessage("ItemCode code is required");
            RuleFor(x => x.CategoryId).NotEmpty().NotNull()
            .WithMessage("ItemCode Category is required");

        }

    }

}
