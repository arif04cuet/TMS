using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infrastructure.Data.EFCore
{
    public class DataContext : DataContextBase
    {

        private readonly static ILoggerFactory _loggerFacroty = LoggerFactory.Create(builder => builder.AddConsole());

        public DataContext(IOptions<DataContextOptions> options) : base(options)
        {

        }

        public DataContext(DataContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var env = ProjectManager.Env;
            if (env.Equals("Development"))
            {
                optionsBuilder.EnableSensitiveDataLogging();
                if(_loggerFacroty != null)
                {
                    optionsBuilder.UseLoggerFactory(_loggerFacroty);
                }
            }

            if (string.IsNullOrEmpty(MigrationsAssembly))
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
            else
            {
                optionsBuilder.UseSqlServer(ConnectionString, options =>
                {
                    options.MigrationsAssembly(MigrationsAssembly);
                });
            }
        }
    }
}
