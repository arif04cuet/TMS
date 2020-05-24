using Infrastructure.Data;
using Module.Core.Data;
using Module.Training.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public class BedService : IBedService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Bed> _bedRepository;

        public BedService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _bedRepository = _unitOfWork.GetRepository<Bed>();
        }

        public async Task<BedViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _bedRepository.GetAsync(x => x.Id == id, BedViewModel.Select(), cancellationToken);

            return item;
        }

        public async Task<PagedCollection<BedViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _bedRepository.ListAsync(null, BedViewModel.Select(), pagingOptions, searchOptions, cancellationToken);

            return result;
        }

    }
}
