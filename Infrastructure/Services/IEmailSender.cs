using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IEmailSender : ITransientService
    {
        Task SendAsync(string to, string subject, string message, bool isHtml = true);
    }
}
