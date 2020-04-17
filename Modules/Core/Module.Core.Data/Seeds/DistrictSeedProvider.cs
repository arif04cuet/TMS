using Infrastructure.Data;
using Module.Core.Entities;
using System.Collections.Generic;

namespace Module.Core.Data
{
    public class DistrictSeedProvider : ISeedProvider<District>
    {
        public int Order => 0;
        public IEnumerable<District> GetSeeds()
        {
            return new List<District>
            {
                new District(1, "Barguna"),
                new District(2, "Barishal"),
                new District(3, "Bhola"),
                new District(4, "Jhalokathi"),
                new District(5, "Patuakhali"),
                new District(6, "Pirojpur"),
                new District(7, "Bandarban"),
                new District(8, "Brahmanbaria"),
                new District(9, "Chandpur"),
                new District(10, "Chattogram"),
                new District(11, "Cumilla"),
                new District(12, "Cox's Bazar"),
                new District(13, "Feni"),
                new District(14, "Khagrachhari"),
                new District(15, "Lakshmipur"),
                new District(16, "Noakhali"),
                new District(17, "Rangamati"),
                new District(18, "Dhaka"),
                new District(19, "Faridpur"),
                new District(20, "Gazipur"),
                new District(21, "Gopalganj"),
                new District(22, "Kishoreganj"),
                new District(23, "Madaripur"),
                new District(24, "Manikganj"),
                new District(25, "Munshiganj"),
                new District(26, "Narayanganj"),
                new District(27, "Narsingdi"),
                new District(28, "Rajbari"),
                new District(29, "Shariatpur"),
                new District(30, "Tangail"),
                new District(31, "Bagerhat"),
                new District(32, "Chuadanga"),
                new District(33, "Jashore"),
                new District(34, "Jhenaidah"),
                new District(35, "Khulna"),
                new District(36, "Kushtia"),
                new District(37, "Magura"),
                new District(38, "Meherpur"),
                new District(39, "Narail"),
                new District(40, "Satkhira"),
                new District(41, "Jamalpur"),
                new District(42, "Mymensingh"),
                new District(43, "Netrokona"),
                new District(44, "Sherpur"),
                new District(45, "Bogura"),
                new District(46, "Joypurhat"),
                new District(47, "Naogaon"),
                new District(48, "Natore"),
                new District(49, "Chapainawabganj"),
                new District(50, "Pabna"),
                new District(51, "Rajshahi"),
                new District(52, "Sirajganj"),
                new District(53, "Dinajpur"),
                new District(54, "Gaibandha"),
                new District(55, "Kurigram"),
                new District(56, "Lalmonirhat"),
                new District(57, "Nilphamari"),
                new District(58, "Panchagarh"),
                new District(59, "Rangpur"),
                new District(60, "Thakurgaon"),
                new District(61, "Habiganj"),
                new District(62, "Moulvibazar"),
                new District(63, "Sunamganj"),
                new District(64, "Sylhet")
            };
        }
    }
}
