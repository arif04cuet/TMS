using FluentValidation;
using Infrastructure.Data;
using Module.Core.Shared;

namespace Module.Library.Data.Validators
{
    public class LibraryMemberRequestCreateRequestValidator : AbstractValidator<LibraryMemberRequestCreateRequest>
    {

        private readonly IUnitOfWork _unitOfWork;
        public LibraryMemberRequestCreateRequestValidator(
            IUnitOfWork unitOfWork,
            long? ignoreUserId = default)
        {
            _unitOfWork = unitOfWork;

            if(!ignoreUserId.HasValue)
            {
                RuleFor(x => x.Email).Email(_unitOfWork, ignoreUserId);
            }
            RuleFor(x => x.Mobile).Mobile(_unitOfWork, ignoreUserId);

        }

    }
}
