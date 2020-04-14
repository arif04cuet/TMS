using Infrastructure;
using Module.Core.Entities;
using System.IO;
using System.Threading.Tasks;

namespace Module.Core.Data.Services
{
    public interface IMediaService : IScopedService
    {
        string GetMediaUrl(Media media);

        string GetMediaUrl(string fileName);

        string GetThumbnailUrl(Media media);

        Task SaveMediaAsync(Stream mediaBinaryStream, string fileName, string mimeType = null);

        Task DeleteMediaAsync(Media media);

        Task DeleteMediaAsync(string fileName);
    }
}
