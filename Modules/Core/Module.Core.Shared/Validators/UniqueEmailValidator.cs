using FluentValidation.Resources;
using FluentValidation.Validators;
using Infrastructure.Data;
using Module.Core.Entities;
using System.Linq;

namespace Module.Core.Shared
{
    public class UniqueEmailValidator : PropertyValidator
    {
        readonly IUnitOfWork _unitOfWork;
        readonly long? _ignoreUserId;

        public UniqueEmailValidator(IUnitOfWork unitOfWork, long? ignoreUserId) : base(new LanguageStringSource(nameof(UniqueEmailValidator)))
        {
            _unitOfWork = unitOfWork;
            _ignoreUserId = ignoreUserId;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            string email = (string)context.PropertyValue;
            return IsValid(email);
        }

        public bool IsValid(string email)
        {
            var query = _unitOfWork.GetRepository<User>()
                        .AsReadOnly()
                        .Where(x => !x.IsDeleted && x.Email.ToLower() == email.ToLower());
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
