using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Msi.UtilityKit.Pagination;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Core.Data
{
    public class IdNameServiceBase<T> where T : class, IIdNameEntity
    {

        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IRepository<T> _repository;

        public IdNameServiceBase(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<T>();
        }

        public async Task<IdNameViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var result = await _repository
                .AsReadOnly()
                .Select(x => new IdNameViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("Not found");

            return result;
        }

        public async Task<PagedCollection<IdNameViewModel>> ListAsync(IPagingOptions pagingOptions, CancellationToken cancellationToken = default)
        {
            var items = await _repository
                .AsReadOnly()
                .Select(x => new IdNameViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ApplyPagination(pagingOptions)
                .ToListAsync();

            int total = await _repository.AsReadOnly().CountAsync();

            var result = new PagedCollection<IdNameViewModel>(items, total, pagingOptions);
            return result;
        }

    }
}
