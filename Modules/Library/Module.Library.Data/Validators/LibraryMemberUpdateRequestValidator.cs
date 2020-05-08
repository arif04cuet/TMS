using FluentValidation;
using Infrastructure.Data;

namespace Module.Library.Data.Validators
{
    public class LibraryMemberUpdateRequestValidator : AbstractValidator<LibraryMemberUpdateRequest>
    {

        private readonly IUnitOfWork _unitOfWork;
        public LibraryMemberUpdateRequestValidator(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x).SetValidator(r => new LibraryMemberCreateRequestValidator(_unitOfWork, r.Id));

        }

    }
}
