using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Entities;
using Module.Core.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using static Module.Core.Shared.MessageConstants;

namespace Module.Core.Data
{
    public class RoleService : NameCrudService<Role>, IRoleService
    {

        private readonly IPermissionService _permissionService;

        public RoleService(
            IUnitOfWork unitOfWork,
            IPermissionService permissionService) : base(unitOfWork)
        {
            _permissionService = permissionService;
        }

        public async Task<bool> UpdateRoleAsync(RoleUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var item = await _repository.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (item == null)
                throw new NotFoundException(ROLE_NOT_FOUND);

            item.Name = request.Name;

            if(request.Permissions != null)
            {
                await _permissionService.AssignRolePermission(item.Id, request.Permissions);
            }

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
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
