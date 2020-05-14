using Infrastructure.Data;
using Module.Asset.Entities;
using System.Collections.Generic;

namespace Module.Core.Data
{
    public class CategorySeedProvider : ISeedProvider<Category>
    {
        public int Order => 0;
        public IEnumerable<Category> GetSeeds()
        {
            return new List<Category>
            {
                new Category(1, "Asset"),
                new Category(2, "Consumable"),
                new Category(3, "License")
            };
        }
    }
}
