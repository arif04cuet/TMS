using Infrastructure.Data;
using Module.Core.Entities;

namespace Module.Core.Data
{
    public class MatiralStatusService : IdNameServiceBase<MaritalStatus>, IMatiralStatusService
    {

        public MatiralStatusService(
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}
