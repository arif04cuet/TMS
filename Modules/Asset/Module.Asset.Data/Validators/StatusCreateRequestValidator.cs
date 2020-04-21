using FluentValidation;
using Infrastructure.Data;
using Module.Asset.Entities;
using System.Threading.Tasks;


namespace Module.Asset.Data.Validators
{

    public class StatusCreateRequestValidator : AbstractValidator<StatusCreateRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatusCreateRequestValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.Name).NotEmpty().NotNull()
                .WithMessage("Status name is required");
            RuleFor(x => x.Type).NotEmpty().NotNull()
           .WithMessage("Status Type is required")
           .IsInEnum();

        }

    }

}
