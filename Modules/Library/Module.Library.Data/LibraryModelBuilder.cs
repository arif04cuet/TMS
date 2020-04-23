using Infrastructure.Data.EFCore;
using Microsoft.EntityFrameworkCore;
using Module.Library.Entities;

namespace Module.Library.Data
{
    public class LibraryModelBuilder : IModelBuilder
    {
        public void Build(ModelBuilder modelbuilder)
        {
            //modelbuilder.Entity<BookIssue>()
            //    .HasOne(x => x.BookItem)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
