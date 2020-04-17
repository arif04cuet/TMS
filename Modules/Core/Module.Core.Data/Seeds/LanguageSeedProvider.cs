using Infrastructure.Data;
using Module.Core.Entities;
using System.Collections.Generic;

namespace Module.Core.Data
{
    public class LanguageSeedProvider : ISeedProvider<Language>
    {
        public int Order => 0;
        public IEnumerable<Language> GetSeeds()
        {
            return new List<Language>
            {
                new Language(1, "Bangla"),
                new Language(2, "English"),
                new Language(3, "Arabic"),
                new Language(4, "Hindi")
            };
        }
    }
}
