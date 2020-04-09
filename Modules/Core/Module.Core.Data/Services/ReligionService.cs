using Infrastructure.Data;
using Module.Core.Entities;

namespace Module.Core.Data
{
    public class ReligionService : IdNameServiceBase<Religion>, IReligionService
    {

        public ReligionService(
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}
