using Infrastructure.Data;
using Module.Core.Entities;

namespace Module.Core.Data
{
    public class StatusService : IdNameServiceBase<Status>, IStatusService
    {

        public StatusService(
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}
