using Dapper;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
using Module.Training.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public class BatchScheduleGalleryService : IBatchScheduleGalleryService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediaService _mediaService;
        private readonly IRepository<BatchScheduleGalleryItem> _batchScheduleGalleryRepository;

        public BatchScheduleGalleryService(
            IUnitOfWork unitOfWork,
            IMediaService mediaService)
        {
            _unitOfWork = unitOfWork;
            _mediaService = mediaService;
            _batchScheduleGalleryRepository = _unitOfWork.GetRepository<BatchScheduleGalleryItem>();
        }

        public async Task<BatchScheduleGalleryItemViewModel> CreateAsync(BatchScheduleGalleryItemCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            await _batchScheduleGalleryRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if(result > 1)
            {
                await _mediaService.UseAsync(entity.MediaId);
            }

            var viewModel = new BatchScheduleGalleryItemViewModel
            {
                Id = entity.Id,
                Path = _mediaService.GetPhotoUrl(request.MediaId),
                MediaId = entity.MediaId
            };
            return viewModel;
        }

        public async Task<bool> DeleteAsync(long batchScheduleId, long galleryItemId, CancellationToken cancellationToken = default)
        {
            var entity = await _batchScheduleGalleryRepository.FirstOrDefaultAsync(x => x.BatchScheduleId == batchScheduleId && x.Id == galleryItemId && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Gallery item not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if(result > 1)
            {
                await _mediaService.DeleteMediaAsync(entity.MediaId);
            }

            return result > 0;
        }

        public async Task<BatchScheduleGalleryItemViewModel> Get(long batchScheduleId, long galleryItemId, CancellationToken cancellationToken = default)
        {
            var item = await _batchScheduleGalleryRepository
                .Where(x => x.BatchScheduleId == batchScheduleId && x.Id == galleryItemId && !x.IsDeleted)
                .Select(x => new
                {
                    Id = x.Id,
                    MediaId = x.MediaId
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (item == null)
                throw new ValidationException("Gallery item not found.");

            var galleryItem = new BatchScheduleGalleryItemViewModel
            {
                Id = item.Id,
                MediaId = item.MediaId,
                Path = _mediaService.GetPhotoUrl(item.MediaId)
            };

            return galleryItem;
        }

        public async Task<PagedCollection<BatchScheduleGalleryItemViewModel>> ListAsync(long batchScheduleId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var sql = @"select g.Id, m.Id MediaId, concat('UserContents/', m.FileName) Path
                        from [training].[BatchScheduleGalleryItem] g
                        left join [core].[Media] m on m.Id = g.MediaId
                        where g.IsDeleted = 0 and g.BatchScheduleId = @BatchScheduleId";

            var items = await _unitOfWork.GetConnection().QueryAsync<BatchScheduleGalleryItemViewModel>(sql, new { BatchScheduleId = batchScheduleId});

            var total = items.Count();
            var result = new PagedCollection<BatchScheduleGalleryItemViewModel>(items, total, new PagingOptions { Limit = total, Offset = 0 });

            return result;
        }

    }
}
