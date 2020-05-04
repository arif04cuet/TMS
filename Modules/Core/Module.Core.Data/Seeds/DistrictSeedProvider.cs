using Infrastructure.Data;
using Module.Core.Entities;
using System.Collections.Generic;

namespace Module.Core.Data
{
    public class DistrictSeedProvider : ISeedProvider<District>
    {
        public int Order => 1;
        public IEnumerable<District> GetSeeds()
        {
            return new List<District>
            {
                new District(1, 1, "Comilla", "কুমিল্লা"),
                new District(2, 1, "Feni", "ফেনী"),
                new District(3, 1, "Brahmanbaria", "ব্রাহ্মণবাড়িয়া"),
                new District(4, 1, "Rangamati", "রাঙ্গামাটি"),
                new District(5, 1, "Noakhali", "নোয়াখালী"),
                new District(6, 1, "Chandpur", "চাঁদপুর"),
                new District(7, 1, "Lakshmipur", "লক্ষ্মীপুর"),
                new District(8, 1, "Chattogram", "চট্টগ্রাম"),
                new District(9, 1, "Coxsbazar", "কক্সবাজার"),
                new District(10, 1, "Khagrachhari", "খাগড়াছড়ি"),
                new District(11, 1, "Bandarban", "বান্দরবান"),
                new District(12, 2, "Sirajganj", "সিরাজগঞ্জ"),
                new District(13, 2, "Pabna", "পাবনা"),
                new District(14, 2, "Bogura", "বগুড়া"),
                new District(15, 2, "Rajshahi", "রাজশাহী"),
                new District(16, 2, "Natore", "নাটোর"),
                new District(17, 2, "Joypurhat", "জয়পুরহাট"),
                new District(18, 2, "Chapainawabganj", "চাঁপাইনবাবগঞ্জ"),
                new District(19, 2, "Naogaon", "নওগাঁ"),
                new District(20, 3, "Jashore", "যশোর"),
                new District(21, 3, "Satkhira", "সাতক্ষীরা"),
                new District(22, 3, "Meherpur", "মেহেরপুর"),
                new District(23, 3, "Narail", "নড়াইল"),
                new District(24, 3, "Chuadanga", "চুয়াডাঙ্গা"),
                new District(25, 3, "Kushtia", "কুষ্টিয়া"),
                new District(26, 3, "Magura", "মাগুরা"),
                new District(27, 3, "Khulna", "খুলনা"),
                new District(28, 3, "Bagerhat", "বাগেরহাট"),
                new District(29, 3, "Jhenaidah", "ঝিনাইদহ"),
                new District(30, 4, "Jhalakathi", "ঝালকাঠি"),
                new District(31, 4, "Patuakhali", "পটুয়াখালী"),
                new District(32, 4, "Pirojpur", "পিরোজপুর"),
                new District(33, 4, "Barisal", "বরিশাল"),
                new District(34, 4, "Bhola", "ভোলা"),
                new District(35, 4, "Barguna", "বরগুনা"),
                new District(36, 5, "Sylhet", "সিলেট"),
                new District(37, 5, "Moulvibazar", "মৌলভীবাজার"),
                new District(38, 5, "Habiganj", "হবিগঞ্জ"),
                new District(39, 5, "Sunamganj", "সুনামগঞ্জ"),
                new District(40, 6, "Narsingdi", "নরসিংদী"),
                new District(41, 6, "Gazipur", "গাজীপুর"),
                new District(42, 6, "Shariatpur", "শরীয়তপুর"),
                new District(43, 6, "Narayanganj", "নারায়ণগঞ্জ"),
                new District(44, 6, "Tangail", "টাঙ্গাইল"),
                new District(45, 6, "Kishoreganj", "কিশোরগঞ্জ"),
                new District(46, 6, "Manikganj", "মানিকগঞ্জ"),
                new District(47, 6, "Dhaka", "ঢাকা"),
                new District(48, 6, "Munshiganj", "মুন্সিগঞ্জ"),
                new District(49, 6, "Rajbari", "রাজবাড়ী"),
                new District(50, 6, "Madaripur", "মাদারীপুর"),
                new District(51, 6, "Gopalganj", "গোপালগঞ্জ"),
                new District(52, 6, "Faridpur", "ফরিদপুর"),
                new District(53, 7, "Panchagarh", "পঞ্চগড়"),
                new District(54, 7, "Dinajpur", "দিনাজপুর"),
                new District(55, 7, "Lalmonirhat", "লালমনিরহাট"),
                new District(56, 7, "Nilphamari", "নীলফামারী"),
                new District(57, 7, "Gaibandha", "গাইবান্ধা"),
                new District(58, 7, "Thakurgaon", "ঠাকুরগাঁও"),
                new District(59, 7, "Rangpur", "রংপুর"),
                new District(60, 7, "Kurigram", "কুড়িগ্রাম"),
                new District(61, 8, "Sherpur", "শেরপুর"),
                new District(62, 8, "Mymensingh", "ময়মনসিংহ"),
                new District(63, 8, "Jamalpur", "জামালপুর"),
                new District(64, 8, "Netrokona", "নেত্রকোণা")
            };
        }
    }
}
