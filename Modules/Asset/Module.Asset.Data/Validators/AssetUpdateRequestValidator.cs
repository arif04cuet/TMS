using FluentValidation;
using Infrastructure.Data;


namespace Module.Asset.Data.Validators
{

    public class AssetUpdateRequestValidator : AbstractValidator<AssetUpdateRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssetUpdateRequestValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x).SetValidator(x => new AssetCreateRequestValidator(_unitOfWork, x.Id));

        }

    }

}
