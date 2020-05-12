using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Module.Asset.Entities;
using Module.Core.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public class AssetEmailService : IAssetEmailService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;

        public AssetEmailService(
            IUnitOfWork unitOfWork,
            IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
        }

        public async Task SendEULAEmailAsync(long userId, long categoryId)
        {
            var user = await _unitOfWork.GetRepository<User>()
                .AsReadOnly()
                .Where(x => x.Id == userId && !x.IsDeleted)
                .Select(x => new
                {
                    Email = x.Email
                })
                .FirstOrDefaultAsync();

            var category = await _unitOfWork.GetRepository<Category>()
                .Where(x => x.Id == categoryId && !x.IsDeleted)
                .Select(x => new
                {
                    EULA = x.EULA,
                    IsSendEmail = x.IsSendEmail
                })
                .FirstOrDefaultAsync();

            if (user != null && category != null)
            {
                if (category.IsSendEmail)
                {
                    _ = _emailSender.SendAsync(user.Email, "Subject", category.EULA);
                }
            }
            else
            {
                System.Console.WriteLine($"User({userId}) or category({categoryId}) not found for sending EULA email.");
            }
        }
    }
}
