using Infrastructure.Data;
using Infrastructure.Services;
using Module.Core.Entities;
using System.IO;
using System.Threading.Tasks;

namespace Module.Core.Data.Services
{
    public class MediaService : IMediaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Media> _mediaRepository;
        private readonly IStorageService _storageService;

        public MediaService(
            IUnitOfWork unitOfWork,
            IStorageService storageService)
        {
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

        public Task DeleteMediaAsync(string fileName)
        {
            return _storageService.DeleteMediaAsync(fileName);
        }
    }
}
