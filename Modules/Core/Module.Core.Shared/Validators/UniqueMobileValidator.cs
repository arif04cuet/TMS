using FluentValidation.Resources;
using FluentValidation.Validators;
using Infrastructure.Data;
using Module.Core.Entities;
using System.Linq;

namespace Module.Core.Shared
{
    public class UniqueMobileValidator : PropertyValidator
    {
        readonly IUnitOfWork _unitOfWork;
        readonly long? _ignoreUserId;

        public UniqueMobileValidator(IUnitOfWork unitOfWork, long? ignoreUserId) : base(new LanguageStringSource(nameof(UniqueMobileValidator)))
        {
            _unitOfWork = unitOfWork;
            _ignoreUserId = ignoreUserId;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            string mobile = (string)context.PropertyValue;
            return IsValid(mobile);
        }

        public bool IsValid(string mobile)
        {
            var query = _unitOfWork.GetRepository<User>()
                        .AsReadOnly()
                        .Where(x => x.Mobile == mobile && !x.IsDeleted);
            if (_ignoreUserId.HasValue)
            {
                query = query.Where(x => x.Id != _ignoreUserId.Value);
            }
            var exist = query
                        .Select(x => x.Id)
                        .Count() > 0;
            return !exist;
        }
    }
}
