using Infrastructure.Data;
using Module.Core.Entities;

namespace Module.Core.Data
{
    public class DepartmentService : IdNameServiceBase<Department>, IDepartmentService
    {

        public DepartmentService(
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}
