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
    public class ContentService : IContentService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediaService _mediaService;
        private readonly IRepository<Content> _contentRepository;

        public ContentService(
            IUnitOfWork unitOfWork,
            IMediaService mediaService
            )
        {
            _unitOfWork = unitOfWork;
            _mediaService = mediaService;
            _contentRepository = _unitOfWork.GetRepository<Content>();
        }

        public async Task<long> CreateAsync(ContentCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            //uploads
            if (request.Image.HasValue)
                entity.ImageId = request.Image;
            //uploads
            if (request.Attachment.HasValue)
                entity.AttachmentId = request.Attachment;


            await _contentRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (result > 0 && request.Image.HasValue)
                await _mediaService.UseAsync(request.Image);


            return entity.Id;
        }

        public async Task<bool> UpdateAsync(ContentUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _contentRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Content not found");

            entity = request.Map(entity);

            //uploads
            if (request.Image.HasValue)
                entity.ImageId = request.Image;
            //uploads
            if (request.Attachment.HasValue)
                entity.AttachmentId = request.Attachment;



            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (result > 0)
            {
                if (request.Image.HasValue)
                    await _mediaService.UseAsync(request.Image);

                if (request.Attachment.HasValue)
                    await _mediaService.UseAsync(request.Attachment);
            }


            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _contentRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Content not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<ContentViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            return await _contentRepository.GetAsync(x => x.Id == id, ContentViewModel.Select(), cancellationToken);
        }

        public async Task<PagedCollection<ContentViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _contentRepository.ListAsync(ContentViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }


        public async Task<bool> DeleteAttachmentAsync(long imageId, long? entityId, CancellationToken cancellationToken = default)
        {
            long result = 0;
            if (entityId.HasValue)
            {
                var entity = await _contentRepository
                .FirstOrDefaultAsync(x => x.Id == entityId && !x.IsDeleted);

                if (entity == null)
                    throw new NotFoundException("Image not found");

                if (entity.AttachmentId.HasValue)
                {
                    // delete image association
                    entity.AttachmentId = null;
                    result = await _unitOfWork.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    entityId = null;
                }
            }

            // delete physical file
            if ((entityId.HasValue && result > 0) || !entityId.HasValue)
                await _mediaService.DeleteMediaAsync(imageId);

            return result > 0;
        }

        public async Task<bool> DeleteImageAsync(long imageId, long? entityId, CancellationToken cancellationToken = default)
        {
            long result = 0;
            if (entityId.HasValue)
            {
                var entity = await _contentRepository
                .FirstOrDefaultAsync(x => x.Id == entityId && !x.IsDeleted);

                if (entity == null)
                    throw new NotFoundException("Image not found");

                if (entity.ImageId.HasValue)
                {
                    // delete image association
                    entity.ImageId = null;
                    result = await _unitOfWork.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    entityId = null;
                }
            }

            // delete physical file
            if ((entityId.HasValue && result > 0) || !entityId.HasValue)
                await _mediaService.DeleteMediaAsync(imageId);

            return result > 0;
        }



    }
}
