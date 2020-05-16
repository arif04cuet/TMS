using System;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data.EFCore
{
    public class DataContextFactory<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DataContext
    {
        private string _connectionString;

        public TContext CreateDbContext(params string[] args)
        {
            if (args.Length > 0)
            {
                _connectionString = args[0];
            }
            return Create(_connectionString);
        }

        public TContext Create(string connectionString)
        {
            var options = new DataContextOptions
            {
                ConnectionString = connectionString
            };
            var context = Activator.CreateInstance(typeof(TContext), new object[] { options }) as TContext;
            return context;
        }
    }
}
