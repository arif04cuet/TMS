using FluentValidation;
using Infrastructure.Data;
using Module.Core.Entities;
using System.Threading.Tasks;
using Module.Core.Shared;

using static Module.Core.Shared.MessageConstants;
using System.Threading;

namespace Module.Library.Data.Validators
{
    public class LibraryMemberCreateRequestValidator : AbstractValidator<LibraryMemberCreateRequest>
    {

        private readonly IUnitOfWork _unitOfWork;
        public LibraryMemberCreateRequestValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.Email).Email(_unitOfWork);

            RuleFor(x => x.Mobile).Mobile(_unitOfWork);

        }

    }
}
