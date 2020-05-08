using FluentValidation.Resources;
using FluentValidation.Validators;
using Infrastructure.Data;
using Module.Core.Entities;
using System.Linq;

namespace Module.Core.Shared
{
    public class UniqueEmployeeIdValidator : PropertyValidator
    {
        readonly IUnitOfWork _unitOfWork;

        public UniqueEmployeeIdValidator(IUnitOfWork unitOfWork) : base(new LanguageStringSource(nameof(UniqueMobileValidator)))
        {
            _unitOfWork = unitOfWork;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            string employeeId = (string)context.PropertyValue;
            var exist = _unitOfWork.GetRepository<User>()
                        .AsReadOnly()
                        .Where(x => x.EmployeeId == employeeId && !x.IsDeleted)
                        .Select(x => x.Id)
                        .Count() > 0;
            return !exist;
        }
    }
}
