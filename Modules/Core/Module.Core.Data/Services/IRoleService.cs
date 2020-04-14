using Infrastructure;
using Module.Core.Entities;
using Module.Core.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module.Core.Data
{
    public interface IRoleService : INameCrudService<Role>, IScopedService
    {
        Task<IEnumerable<long>> GetRoleIdsAsync(long userId);
    }
}
