using FluentValidation;
using Infrastructure.Data;
using Module.Asset.Entities;
using System.Threading.Tasks;


namespace Module.Asset.Data.Validators
{

    public class CategoryCreateRequestValidator : AbstractValidator<CategoryCreateRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryCreateRequestValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.Name).NotEmpty().NotNull()
                .WithMessage("Category name is required");
            RuleFor(x => x.Type).NotEmpty().NotNull()
           .WithMessage("Category Type is required")
           .IsInEnum();

        }

    }

}
