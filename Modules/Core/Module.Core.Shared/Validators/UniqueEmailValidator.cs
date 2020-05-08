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

        public UniqueEmailValidator(IUnitOfWork unitOfWork) : base(new LanguageStringSource(nameof(UniqueEmailValidator)))
        {
            _unitOfWork = unitOfWork;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            string email = (string)context.PropertyValue;
            var exist = _unitOfWork.GetRepository<User>()
                        .AsReadOnly()
                        .Where(x => !x.IsDeleted && x.Email.ToLower() == email.ToLower())
                        .Select(x => x.Id)
                        .Count() > 0;
            return !exist;
        }
    }
}
