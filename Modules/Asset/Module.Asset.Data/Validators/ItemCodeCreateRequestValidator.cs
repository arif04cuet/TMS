using FluentValidation;
using Infrastructure.Data;
using Module.Asset.Entities;
using Module.Core.Shared;
using System.Linq;

namespace Module.Asset.Data.Validators
{

    public class ItemCodeCreateRequestValidator : AbstractValidator<ItemCodeCreateRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly long? _itemCodeId;

        public ItemCodeCreateRequestValidator(IUnitOfWork unitOfWork, long? itemCodeId = null)
        {
            _unitOfWork = unitOfWork;
            _itemCodeId = itemCodeId;

            RuleFor(x => x.Name).Required();

            RuleFor(x => x.Code)
                .Required()
                .Must(BeUniqueItemCode)
                .WithMessage("Item code must be unique."); ;

            RuleFor(x => x.CategoryId).Required();

        }

        public bool BeUniqueItemCode(string itemCode)
        {
            var q = _unitOfWork.GetRepository<ItemCode>()
                .AsReadOnly()
                .Where(x => x.Code == itemCode && !x.IsDeleted);
            if (_itemCodeId.HasValue)
            {
                q = q.Where(x => x.Id != _itemCodeId.Value);
            }

            var exist = q.Select(x => x.Id).Count() > 0;
            return !exist;
        }

    }

}
