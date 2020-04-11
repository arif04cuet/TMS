using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Entities;
using Msi.UtilityKit.Pagination;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Core.Data
{
    public class PermissionService : IPermissionService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Permission> _permissionRepository;

        public PermissionService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _permissionRepository = _unitOfWork.GetRepository<Permission>();
        }

        public async Task<PagedCollection<IdNameViewModel>> ListAsync(IPagingOptions pagingOptions, CancellationToken cancellationToken = default)
        {
            var items = await _permissionRepository
                .AsReadOnly()
                .Select(x => new IdNameViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ApplyPagination(pagingOptions)
                .ToListAsync();

            int total = await _permissionRepository.AsReadOnly().CountAsync();

            var result = new PagedCollection<IdNameViewModel>(items, total, pagingOptions);
            return result;

        }
    }
}
