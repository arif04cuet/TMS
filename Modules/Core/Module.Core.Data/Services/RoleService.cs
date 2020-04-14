using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Entities;
using Module.Core.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module.Core.Data
{
    public class RoleService : NameCrudService<Role>, IRoleService
    {

        public RoleService(
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<long>> GetRoleIdsAsync(long userId)
        {
            var roles = await _unitOfWork.GetRepository<UserRole>()
                .AsReadOnly()
                .Where(x => x.UserId == userId)
                .Select(x => x.RoleId)
                .ToListAsync();
            return roles;
        }

    }
}
