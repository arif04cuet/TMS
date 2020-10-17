using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Module.Core.Shared;
using Module.Library.Data;
using Module.Library.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public class BookReturnScheduleCronJob : CronJobService
    {
        private readonly IServiceProvider _serviceProvider;

        public BookReturnScheduleCronJob(IScheduleConfig<BookReturnScheduleCronJob> config, IServiceProvider serviceProvider) : base(config.CronExpression, config.TimeZoneInfo)
        {
            _serviceProvider = serviceProvider;
        }

        public override async Task DoWork(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var _emailSender = scope.ServiceProvider.GetRequiredService<IEmailSender>();
                var _viewRenderer = scope.ServiceProvider.GetRequiredService<IRazorViewRenderer>();
                var smsSender = scope.ServiceProvider.GetRequiredService<ISmsSender>();

                var towDaysAfter = DateTime.Now.AddDays(2);
                var items = await unitOfWork.GetRepository<BookIssue>()
                    .AsReadOnly()
                    .Where(x => x.ActualReturnDate == null && x.ReturnDate != null && x.ReturnDate.Value.Date == towDaysAfter.Date && !x.IsDeleted)
                    .Select(x => new
                    {
                        Book = x.Book.Title,
                        Name = x.Member.FullName,
                        Email = x.Member.Email,
                        Mobile = x.Member.Mobile
                    })
                    .ToListAsync();

                foreach (var item in items)
                {
                    var date = DateTime.Now.AddDays(2).Date.ToString();
                    var htmlContent = await _viewRenderer.RenderViewToStringAsync("/Views/book-return-reminder.cshtml", new BookReturnReminderModel
                    {
                        Book = item.Book,
                        Date = date,
                        Name = item.Name
                    });
                    _ = _emailSender.SendAsync(item.Email, "Return book reminder", htmlContent);

                    if(string.IsNullOrEmpty(item.Mobile))
                    {
                        _ = smsSender.SendAsync(item.Mobile, $"Return your book at {date}");
                    }
                }
            }
        }

    }
}
