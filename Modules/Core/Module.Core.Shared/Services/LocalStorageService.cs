using Infrastructure;
using Infrastructure.Services;
using System.IO;
using System.Threading.Tasks;

namespace Module.Core.Shared
{
    public class LocalStorageService : IStorageService
    {

        public string GetMediaUrl(string fileName)
        {
            return GetFilePath(fileName);
        }

        public async Task SaveMediaAsync(Stream mediaBinaryStream, string fileName, string mimeType = null)
        {
            var filePath = GetFilePath(fileName);
            using (var output = new FileStream(filePath, FileMode.Create))
            {
                await mediaBinaryStream.CopyToAsync(output);
            }
        }

        public async Task DeleteMediaAsync(string fileName)
        {
            var filePath = GetFilePath(fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }

        public string GetFilePath(string fileName)
        {
            return Path.Combine(ProjectManager.StoragePath, fileName);
        }
    }
}
