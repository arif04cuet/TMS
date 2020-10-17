using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ISmsSender : ITransientService
    {
        Task SendAsync(string to, string message);
    }
}
