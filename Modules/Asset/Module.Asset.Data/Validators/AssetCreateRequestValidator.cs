using FluentValidation;
using Infrastructure.Data;
using Module.Core.Shared;
using System.Collections.Generic;
using System.Linq;


namespace Module.Asset.Data.Validators
{

    public class AssetCreateRequestValidator : AbstractValidator<AssetCreateRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssetCreateRequestValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.Items)
                .Required()
                .Must(IsUniqueAssetTag)
                .WithMessage("Asset tag must be unique.");

        }

        bool IsUniqueAssetTag(IEnumerable<AssetItemCreateRequest> items)
        {

            var tags = items.Select(x => x.AssetTag);
            var uniqueTags = tags.Distinct();

            if (tags.Count() != uniqueTags.Count())
                return false;

            var query = _unitOfWork.GetRepository<Entities.Asset>()
                .AsReadOnly()
                .Where(x => tags.Contains(x.AssetTag) && !x.IsDeleted);

            var exist = query.Select(x => x.Id).Count() > 0;
            return !exist;
        }

    }

}
