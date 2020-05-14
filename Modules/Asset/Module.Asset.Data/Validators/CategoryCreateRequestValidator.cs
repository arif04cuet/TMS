using FluentValidation;
using Infrastructure.Data;
using Module.Core.Shared;


namespace Module.Asset.Data.Validators
{

    public class CategoryCreateRequestValidator : AbstractValidator<CategoryCreateRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryCreateRequestValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.Name).Required();

        }

    }

}
