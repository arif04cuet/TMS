using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Core.Shared
{
    public class NameService<T> : INameService<T> where T : class, IIdNameEntity
    {

        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IRepository<T> _repository;

        public NameService(
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

        public async Task<PagedCollection<IdNameViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions, CancellationToken cancellationToken = default)
        {
            var query = _repository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await query
                .ApplyPagination(pagingOptions)
                .Select(x => new IdNameViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();

            int total = await query.Select(x => x.Id).CountAsync();

            var result = new PagedCollection<IdNameViewModel>(items, total, pagingOptions);
            return result;
        }

    }
}
