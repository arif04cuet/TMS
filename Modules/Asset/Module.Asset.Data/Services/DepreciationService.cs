using Infrastructure;
using Infrastructure.Data;
using Module.Asset.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;
using Module.Core.Data;

namespace Module.Asset.Data
{
    public class DepreciationService : IDepreciationService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Depreciation> _repository;


        public DepreciationService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Depreciation>();

        }

        public async Task<long> CreateAsync(DepreciationCreateRequest request, CancellationToken cancellationToken = default)
        {
            var newEntity = request.Map();
            await _repository.AddAsync(newEntity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return newEntity.Id;
        }


        public async Task<bool> UpdateAsync(DepreciationUpdateRequest request, CancellationToken cancellationToken = default)
        {
            Depreciation entity = await _repository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Depreciation not found");

            request.Map(entity);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }



        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            Depreciation entity = await _repository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Depreciation not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<DepreciationViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetAsync(x => x.Id == id, DepreciationViewModel.Select(), cancellationToken);

            return result;
        }

        public async Task<PagedCollection<DepreciationViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _repository.ListAsync(null, DepreciationViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }


    }
}
