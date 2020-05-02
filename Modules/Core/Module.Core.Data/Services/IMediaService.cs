using Infrastructure;
using Module.Core.Entities;
using System.IO;
using System.Threading.Tasks;

namespace Module.Core.Data
{
    public interface IMediaService : IScopedService
    {
        string GetMediaUrl(Media media);

        string GetMediaUrl(string fileName);

        string GetThumbnailUrl(Media media);

        Task<long> SaveMediaAsync(Stream mediaBinaryStream, string fileName, string mimeType = null);

        Task DeleteMediaAsync(Media media);

        Task DeleteMediaAsync(long? mediaId);

        Task DeleteMediaAsync(string fileName);

        string GetFullUrl(Media media);

        string GetFullUrl(string fileName);

        Task<bool> UseAsync(long mediaId, bool value = true);
    }
}
