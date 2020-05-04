using Infrastructure.Data;
using Module.Core.Entities;
using System.Collections.Generic;

namespace Module.Core.Data
{
    public class DivisionSeedProvider : ISeedProvider<Division>
    {
        public int Order => 0;
        public IEnumerable<Division> GetSeeds()
        {
            return new List<Division>
            {
                new Division(1, "Chattagram", "চট্টগ্রাম"),
                new Division(2, "Rajshahi", "রাজশাহী"),
                new Division(3, "Khulna", "খুলনা"),
                new Division(4, "Barisal", "বরিশাল"),
                new Division(5, "Sylhet", "সিলেট"),
                new Division(6, "Dhaka", "ঢাকা"),
                new Division(7, "Rangpur", "রংপুর"),
                new Division(8, "Mymensingh", "ময়মনসিংহ")
            };
        }
    }
}
