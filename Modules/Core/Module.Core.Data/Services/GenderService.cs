using Infrastructure.Data;
using Module.Core.Entities;

namespace Module.Core.Data
{
    public class GenderService : IdNameServiceBase<Gender>, IGenderService
    {

        public GenderService(
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}
