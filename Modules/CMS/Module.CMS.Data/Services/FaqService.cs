using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.CMS.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Module.Core.Data;

namespace Module.CMS.Data
{
    public class FaqService : IFaqService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Faq> _FaqRepository;

        public FaqService(
            IUnitOfWork unitOfWork
            )
        {
            _unitOfWork = unitOfWork;
            _FaqRepository = _unitOfWork.GetRepository<Faq>();
        }

        public async Task<long> CreateAsync(FaqCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            
            await _FaqRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(FaqUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _FaqRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Faq not found");

            entity = request.Map(entity);
         
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _FaqRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Faq not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<FaqViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            return await _FaqRepository.GetAsync(x => x.Id == id, FaqViewModel.Select(), cancellationToken);
        }

        public async Task<PagedCollection<FaqViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _FaqRepository.ListAsync(FaqViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }


    }
}
