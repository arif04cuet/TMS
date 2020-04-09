using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Data.EFCore
{
    public static class SeedProviderExtensions
    {

        public static void AddSeeds(this ModelBuilder modelBuilder, ISeedProvider<IEntity> seed)
        {
            var interfaces = seed.GetType().GetInterfaces();
            if (interfaces.Count() > 0)
            {
                var args = interfaces[0].GetGenericArguments();
                if (args.Count() > 0)
                {
                    var type = args[0];
                    modelBuilder.Entity(type).HasData(seed.GetSeeds());
                }
            }
        }

    }
}
