using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Core.Data
{
    public class RoleService : IdNameServiceBase<Role>, IRoleService
    {

        public RoleService(
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<long> CreateAsync(RoleCreateRequest request, CancellationToken cancellationToken = default)
        {
            Role newRole = new Role
            {
                Name = request.Name,
            };

            await _repository.AddAsync(newRole, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return newRole.Id;
        }

        public async Task<bool> DeleteAsync(long roleId, CancellationToken cancellationToken = default)
        {
            Role role = await _repository.FirstOrDefaultAsync(x => x.Id == roleId, true);

            if (role == null)
                throw new NotFoundException("Role not found");

            _repository.Remove(role);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> UpdateAsync(RoleUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var role = await _repository.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (role == null)
                throw new NotFoundException($"Role not found");

            role.Name = request.Name;

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
