using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IEmailSender : ITransientService
    {
        Task SendEmailAsync(string email, string subject, string message, bool isHtml = true);
    }
}
