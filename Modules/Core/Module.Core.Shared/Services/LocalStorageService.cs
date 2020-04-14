using Infrastructure;
using Infrastructure.Services;
using System.IO;
using System.Threading.Tasks;

namespace Module.Core.Shared
{
    public class LocalStorageService : IStorageService
    {
        private const string MediaRootFoler = "user-content";

        public string GetMediaUrl(string fileName)
        {
            return $"/{MediaRootFoler}/{fileName}";
        }

        public async Task SaveMediaAsync(Stream mediaBinaryStream, string fileName, string mimeType = null)
        {
            var filePath = Path.Combine(ProjectManager.WebRootPath, MediaRootFoler, fileName);
            using (var output = new FileStream(filePath, FileMode.Create))
            {
                await mediaBinaryStream.CopyToAsync(output);
            }
        }

        public async Task DeleteMediaAsync(string fileName)
        {
            var filePath = Path.Combine(ProjectManager.WebRootPath, MediaRootFoler, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }
    }
}
