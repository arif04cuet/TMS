using FluentValidation;
using Infrastructure.Data;
using Module.Core.Shared;

namespace Module.Library.Data.Validators
{
    public class LibraryMemberCreateRequestValidator : AbstractValidator<LibraryMemberCreateRequest>
    {

        private readonly IUnitOfWork _unitOfWork;
        public LibraryMemberCreateRequestValidator(
            IUnitOfWork unitOfWork,
            long? ignoreUserId = default)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.Email).Email(_unitOfWork, ignoreUserId);
            RuleFor(x => x.Mobile).Mobile(_unitOfWork, ignoreUserId);

        }

    }
}
