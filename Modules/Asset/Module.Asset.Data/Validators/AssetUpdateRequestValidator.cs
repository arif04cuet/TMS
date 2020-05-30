using FluentValidation;
using Infrastructure.Data;
using Module.Core.Shared;
using System.Linq;

namespace Module.Asset.Data.Validators
{

    public class AssetUpdateRequestValidator : AbstractValidator<AssetUpdateRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssetUpdateRequestValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.AssetTag)
                .Required()
                .Must(IsUniqueAssetTag)
                .WithMessage("Asset tag must be unique.");

        }

        bool IsUniqueAssetTag(AssetUpdateRequest request, string tag)
        {
            var query = _unitOfWork.GetRepository<Entities.Asset>()
                .AsReadOnly()
                .Where(x => tag == x.AssetTag && x.Id != request.Id && !x.IsDeleted);

            var exist = query.Select(x => x.Id).Count() > 0;
            return !exist;
        }

    }

}
