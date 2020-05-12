using Infrastructure;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public interface IAssetEmailService : IScopedService
    {
        Task SendEULAEmailAsync(long userId, long categoryId);
    }
}
