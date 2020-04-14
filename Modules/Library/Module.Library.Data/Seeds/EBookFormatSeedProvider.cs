using Infrastructure.Data;
using Module.Library.Entities;
using System.Collections.Generic;

using static Module.Library.Data.EBookFormatConstants;

namespace Module.Library.Data
{
    public class EBookFormatSeedProvider : ISeedProvider<EBookFormat>
    {
        public int Order => 0;
        public IEnumerable<EBookFormat> GetSeeds()
        {
            return new List<EBookFormat>
            {
                new EBookFormat(PDF, "PDF"),
                new EBookFormat(ePUB, "ePUB"),
                new EBookFormat(WordDocument, "WordDocument")
            };
        }
    }
}
