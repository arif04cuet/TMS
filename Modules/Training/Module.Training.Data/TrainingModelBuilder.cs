using Infrastructure.Data.EFCore;
using Microsoft.EntityFrameworkCore;
using Module.Training.Entities;

namespace Module.Training.Data
{
    public class TrainingModelBuilder : IModelBuilder
    {
        public void Build(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Floor>()
                .HasOne(x => x.Hostel)
                .WithMany(x => x.Floors)
                .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Room>()
                .HasOne(x => x.Floor)
                .WithMany(x => x.Rooms)
                .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Room>()
                .HasOne(x => x.Hostel)
                .WithMany(x => x.Rooms)
                .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Bed>()
                .HasOne(x => x.Floor)
                .WithMany(x => x.Beds)
                .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Bed>()
                .HasOne(x => x.Hostel)
                .WithMany(x => x.Beds)
                .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Bed>()
                .HasOne(x => x.Room)
                .WithMany(x => x.Beds)
                .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Allocation>()
                .HasOne(x => x.Floor)
                .WithMany(x => x.Allocations)
                .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Allocation>()
                .HasOne(x => x.Hostel)
                .WithMany(x => x.Allocations)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
