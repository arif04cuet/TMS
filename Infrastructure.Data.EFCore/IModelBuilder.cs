using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.EFCore
{
    public interface IModelBuilder
    {
        void Build(ModelBuilder modelbuilder);
    }
}
