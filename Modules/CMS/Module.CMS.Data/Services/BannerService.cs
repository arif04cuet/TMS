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
    public class BannerService : IBannerService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediaService _mediaService;
        private readonly IRepository<Banner> _bannerRepository;

        public BannerService(
            IUnitOfWork unitOfWork,
            IMediaService mediaService
            )
        {
            _unitOfWork = unitOfWork;
            _mediaService = mediaService;
            _bannerRepository = _unitOfWork.GetRepository<Banner>();
        }

        public async Task<long> CreateAsync(BannerCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            entity.MediaId = request.Media;


            await _bannerRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (result > 0)
                await _mediaService.UseAsync(request.Media);


            return entity.Id;
        }

        public async Task<bool> UpdateAsync(BannerUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _bannerRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Banner not found");

            entity = request.Map(entity);
            entity.MediaId = request.Media;



            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (result > 0)
            {

                await _mediaService.UseAsync(request.Media);

            }


            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _bannerRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Banner not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<BannerViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            return await _bannerRepository.GetAsync(x => x.Id == id, BannerViewModel.Select(), cancellationToken);
        }

        public async Task<PagedCollection<BannerViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _bannerRepository.ListAsync(BannerViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }


    }
}
