using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IStorageService : IScopedService
    {
        string GetMediaUrl(string fileName);

        Task SaveMediaAsync(Stream mediaBinaryStream, string fileName, string mimeType = null);

        Task DeleteMediaAsync(string fileName);
    }
}
