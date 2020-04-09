using Infrastructure.Data;
using Module.Core.Entities;

namespace Module.Core.Data
{
    public class DesignationService : IdNameServiceBase<Designation>, IDesignationService
    {
        public DesignationService(
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}
