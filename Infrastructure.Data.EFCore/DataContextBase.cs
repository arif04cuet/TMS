using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Data.EFCore
{
    public abstract class DataContextBase : DbContext, IDataContext
    {

        public string ConnectionString { get; private set; }
        public string MigrationsAssembly { get; private set; }

        public DataContextBase(IOptions<DataContextOptions> options)
        {
            ConnectionString = options.Value.ConnectionString;
            MigrationsAssembly = options.Value.MigrationsAssembly;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var item in ProjectManager.Entities)
            {
                modelBuilder.Entity(item);
            }

            foreach (var item in ProjectManager.SeedProviders)
            {
                modelBuilder.AddSeeds(item);
            }

            var modelBuilders = ProjectManager.GetInstances<IModelBuilder>();
            foreach (var item in modelBuilders)
            {
                item.Build(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}
