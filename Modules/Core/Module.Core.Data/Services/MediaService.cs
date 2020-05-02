using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Services;
using Module.Core.Entities;
using Module.Core.Shared;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Module.Core.Data.Services
{
    public class MediaService : IMediaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Media> _mediaRepository;
        private readonly IStorageService _storageService;
        private readonly IAppService _appService;

        public MediaService(
            IUnitOfWork unitOfWork,
            IStorageService storageService,
            IAppService appService)
        {
            _appService = appService;
            _unitOfWork = unitOfWork;
            _mediaRepository = _unitOfWork.GetRepository<Media>();
            _storageService = storageService;
        }

        public string GetMediaUrl(Media media)
        {
            if (media == null)
            {
                return GetMediaUrl("no-image.png");
            }

            return GetMediaUrl(media.FileName);
        }

        public string GetMediaUrl(string fileName)
        {
            return _storageService.GetMediaUrl(fileName);
        }

        public string GetFullUrl(Media media)
        {
            if (media == null)
                return string.Empty;

            string fullUrl = GetFullUrl(media.FileName);
            return fullUrl;
        }

        public string GetFullUrl(string fileName)
        {
            string fullUrl = Path.Combine(_appService.GetServerUrl(), MediaConstants.Path, fileName);
            return fullUrl;
        }

        public string GetThumbnailUrl(Media media)
        {
            return GetMediaUrl(media);
        }

        public async Task<long> SaveMediaAsync(Stream mediaBinaryStream, string fileName, string mimeType = null)
        {
            await _storageService.SaveMediaAsync(mediaBinaryStream, fileName, mimeType);
            var media = new Media
            {
                FileName = fileName,
                Extension = Path.GetExtension(fileName)
            };
            await _mediaRepository.AddAsync(media);
            var result = await _unitOfWork.SaveChangesAsync();
            return media.Id;
        }

        public Task DeleteMediaAsync(Media media)
        {
            _mediaRepository.Remove(media);
            return DeleteMediaAsync(media.FileName);
        }

        public Task DeleteMediaAsync(long? mediaId)
        {
            if(mediaId.HasValue)
            {
                var media = _mediaRepository
                    .Where(x => x.Id == mediaId.Value && !x.IsDeleted)
                    .FirstOrDefault();
                if(media != null)
                {
                    _mediaRepository.Remove(media);
                    return DeleteMediaAsync(media.FileName);
                }
            }
            return Task.CompletedTask;
        }

        public Task DeleteMediaAsync(string fileName)
        {
            return _storageService.DeleteMediaAsync(fileName);
        }

        public async Task<bool> UseAsync(long mediaId, bool value = true)
        {
            var media = await _mediaRepository.FirstOrDefaultAsync(x => x.Id == mediaId);
            if (media != null)
                media.IsInUse = value;

            return false;
        }
    }
}
