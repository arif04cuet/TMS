using FluentValidation;
using Infrastructure.Data;
using Module.Core.Shared;
using System.Linq;


namespace Module.Asset.Data.Validators
{

    public class AssetCreateRequestValidator : AbstractValidator<AssetCreateRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly long? _assetId;

        public AssetCreateRequestValidator(IUnitOfWork unitOfWork, long? assetId = null)
        {
            _unitOfWork = unitOfWork;
            _assetId = assetId;

            RuleFor(x => x.AssetTag)
                .Required()
                .Must(IsUniqueAssetTag)
                .WithMessage("Asset tag should be unique.");

        }

        bool IsUniqueAssetTag(string assetTag)
        {
            var q = _unitOfWork.GetRepository<Entities.Asset>()
                .AsReadOnly()
                .Where(x => x.AssetTag == assetTag && !x.IsDeleted);

            if(_assetId.HasValue)
            {
                q = q.Where(x => x.Id != _assetId.Value);
            }

            var exist = q.Select(x => x.Id).Count() > 0;
            return !exist;
        }

    }

}
