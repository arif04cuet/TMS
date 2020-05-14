using FluentValidation;
using Infrastructure.Data;
using Module.Core.Shared;
using System.Linq;


namespace Module.Asset.Data.Validators
{

    public class AssetAuditCreateRequestValidator : AbstractValidator<AssetAuditCreateRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssetAuditCreateRequestValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.AssetTag)
                .Required()
                .Must(BeExistAsset)
                .WithMessage("Asset not found.");

        }

        bool BeExistAsset(string assetTag)
        {
            var exist = _unitOfWork.GetRepository<Entities.Asset>()
                .AsReadOnly()
                .Where(x => x.AssetTag == assetTag && !x.IsDeleted)
                .Select(x => x.Id)
                .Count() > 0;
            return exist;
        }

    }

}
