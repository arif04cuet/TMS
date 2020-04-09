using Infrastructure.Data;
using Module.Core.Entities;

namespace Module.Core.Data
{
    public class BloodGroupService : IdNameServiceBase<BloodGroup>, IBloodGroupService
    {

        public BloodGroupService(
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}
