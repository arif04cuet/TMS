using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OTMS.Migrations
{
    public partial class M4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BnName",
                schema: "core",
                table: "Upazila",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BnName",
                schema: "core",
                table: "Division",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BnName",
                schema: "core",
                table: "District",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DivisionId",
                schema: "core",
                table: "District",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CheckoutHistory",
                schema: "asset",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionById = table.Column<long>(nullable: true),
                    TargetId = table.Column<long>(nullable: true),
                    TargetType = table.Column<byte>(nullable: false),
                    ItemId = table.Column<long>(nullable: true),
                    ItemType = table.Column<byte>(nullable: false),
                    Action = table.Column<byte>(nullable: false),
                    IssueDate = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckoutHistory_User_ActionById",
                        column: x => x.ActionById,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Division",
                columns: new[] { "Id", "BnName", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 1L, "চট্টগ্রাম", null, null, true, false, "Chattagram", null, null, 0L },
                    { 2L, "রাজশাহী", null, null, true, false, "Rajshahi", null, null, 0L },
                    { 3L, "খুলনা", null, null, true, false, "Khulna", null, null, 0L },
                    { 4L, "বরিশাল", null, null, true, false, "Barisal", null, null, 0L },
                    { 5L, "সিলেট", null, null, true, false, "Sylhet", null, null, 0L },
                    { 6L, "ঢাকা", null, null, true, false, "Dhaka", null, null, 0L },
                    { 7L, "রংপুর", null, null, true, false, "Rangpur", null, null, 0L },
                    { 8L, "ময়মনসিংহ", null, null, true, false, "Mymensingh", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Upazila",
                columns: new[] { "Id", "BnName", "CreatedAt", "CreatedBy", "DistrictId", "DivisionId", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 325L, "গোসাইরহাট", null, null, 42L, null, true, false, "Gosairhat", null, null, 0L },
                    { 326L, "ভেদরগঞ্জ", null, null, 42L, null, true, false, "Bhedarganj", null, null, 0L },
                    { 327L, "ডামুড্যা", null, null, 42L, null, true, false, "Damudya", null, null, 0L },
                    { 328L, "আড়াইহাজার", null, null, 43L, null, true, false, "Araihazar", null, null, 0L },
                    { 329L, "বন্দর", null, null, 43L, null, true, false, "Bandar", null, null, 0L },
                    { 333L, "বাসাইল", null, null, 44L, null, true, false, "Basail", null, null, 0L },
                    { 331L, "রূপগঞ্জ", null, null, 43L, null, true, false, "Rupganj", null, null, 0L },
                    { 332L, "সোনারগাঁ", null, null, 43L, null, true, false, "Sonargaon", null, null, 0L },
                    { 324L, "জাজিরা", null, null, 42L, null, true, false, "Zajira", null, null, 0L },
                    { 334L, "ভুয়াপুর", null, null, 44L, null, true, false, "Bhuapur", null, null, 0L },
                    { 335L, "দেলদুয়ার", null, null, 44L, null, true, false, "Delduar", null, null, 0L },
                    { 330L, "নারায়নগঞ্জ সদর", null, null, 43L, null, true, false, "Narayanganj Sadar", null, null, 0L },
                    { 323L, "নড়িয়া", null, null, 42L, null, true, false, "Naria", null, null, 0L },
                    { 319L, "কাপাসিয়া", null, null, 41L, null, true, false, "Kapasia", null, null, 0L },
                    { 321L, "শ্রীপুর", null, null, 41L, null, true, false, "Sreepur", null, null, 0L },
                    { 320L, "গাজীপুর সদর", null, null, 41L, null, true, false, "Gazipur Sadar", null, null, 0L },
                    { 336L, "ঘাটাইল", null, null, 44L, null, true, false, "Ghatail", null, null, 0L },
                    { 318L, "কালিয়াকৈর", null, null, 41L, null, true, false, "Kaliakair", null, null, 0L },
                    { 317L, "কালীগঞ্জ", null, null, 41L, null, true, false, "Kaliganj", null, null, 0L },
                    { 316L, "শিবপুর", null, null, 40L, null, true, false, "Shibpur", null, null, 0L },
                    { 315L, "রায়পুরা", null, null, 40L, null, true, false, "Raipura", null, null, 0L },
                    { 314L, "পলাশ", null, null, 40L, null, true, false, "Palash", null, null, 0L },
                    { 313L, "নরসিংদী সদর", null, null, 40L, null, true, false, "Narsingdi Sadar", null, null, 0L },
                    { 312L, "মনোহরদী", null, null, 40L, null, true, false, "Monohardi", null, null, 0L },
                    { 311L, "বেলাবো", null, null, 40L, null, true, false, "Belabo", null, null, 0L },
                    { 310L, "দিরাই", null, null, 39L, null, true, false, "Derai", null, null, 0L },
                    { 322L, "শরিয়তপুর সদর", null, null, 42L, null, true, false, "Shariatpur Sadar", null, null, 0L },
                    { 337L, "গোপালপুর", null, null, 44L, null, true, false, "Gopalpur", null, null, 0L },
                    { 341L, "সখিপুর", null, null, 44L, null, true, false, "Sakhipur", null, null, 0L },
                    { 339L, "মির্জাপুর", null, null, 44L, null, true, false, "Mirzapur", null, null, 0L },
                    { 366L, "ধামরাই", null, null, 47L, null, true, false, "Dhamrai", null, null, 0L },
                    { 365L, "সাভার", null, null, 47L, null, true, false, "Savar", null, null, 0L },
                    { 364L, "সিংগাইর", null, null, 46L, null, true, false, "Singiar", null, null, 0L },
                    { 363L, "দৌলতপুর", null, null, 46L, null, true, false, "Doulatpur", null, null, 0L },
                    { 362L, "শিবালয়", null, null, 46L, null, true, false, "Shibaloy", null, null, 0L },
                    { 361L, "ঘিওর", null, null, 46L, null, true, false, "Gior", null, null, 0L },
                    { 360L, "মানিকগঞ্জ সদর", null, null, 46L, null, true, false, "Manikganj Sadar", null, null, 0L },
                    { 359L, "সাটুরিয়া", null, null, 46L, null, true, false, "Saturia", null, null, 0L },
                    { 358L, "হরিরামপুর", null, null, 46L, null, true, false, "Harirampur", null, null, 0L },
                    { 357L, "নিকলী", null, null, 45L, null, true, false, "Nikli", null, null, 0L },
                    { 356L, "মিঠামইন", null, null, 45L, null, true, false, "Mithamoin", null, null, 0L },
                    { 355L, "অষ্টগ্রাম", null, null, 45L, null, true, false, "Austagram", null, null, 0L },
                    { 354L, "বাজিতপুর", null, null, 45L, null, true, false, "Bajitpur", null, null, 0L },
                    { 353L, "করিমগঞ্জ", null, null, 45L, null, true, false, "Karimgonj", null, null, 0L },
                    { 352L, "কিশোরগঞ্জ সদর", null, null, 45L, null, true, false, "Kishoreganj Sadar", null, null, 0L },
                    { 351L, "কুলিয়ারচর", null, null, 45L, null, true, false, "Kuliarchar", null, null, 0L },
                    { 350L, "পাকুন্দিয়া", null, null, 45L, null, true, false, "Pakundia", null, null, 0L },
                    { 349L, "হোসেনপুর", null, null, 45L, null, true, false, "Hossainpur", null, null, 0L },
                    { 348L, "তাড়াইল", null, null, 45L, null, true, false, "Tarail", null, null, 0L },
                    { 347L, "ভৈরব", null, null, 45L, null, true, false, "Bhairab", null, null, 0L },
                    { 346L, "কটিয়াদী", null, null, 45L, null, true, false, "Katiadi", null, null, 0L },
                    { 345L, "ইটনা", null, null, 45L, null, true, false, "Itna", null, null, 0L },
                    { 344L, "ধনবাড়ী", null, null, 44L, null, true, false, "Dhanbari", null, null, 0L },
                    { 343L, "কালিহাতী", null, null, 44L, null, true, false, "Kalihati", null, null, 0L },
                    { 342L, "টাঙ্গাইল সদর", null, null, 44L, null, true, false, "Tangail Sadar", null, null, 0L },
                    { 309L, "শাল্লা", null, null, 39L, null, true, false, "Shalla", null, null, 0L },
                    { 340L, "নাগরপুর", null, null, 44L, null, true, false, "Nagarpur", null, null, 0L },
                    { 338L, "মধুপুর", null, null, 44L, null, true, false, "Madhupur", null, null, 0L },
                    { 308L, "জামালগঞ্জ", null, null, 39L, null, true, false, "Jamalganj", null, null, 0L },
                    { 304L, "জগন্নাথপুর", null, null, 39L, null, true, false, "Jagannathpur", null, null, 0L },
                    { 306L, "তাহিরপুর", null, null, 39L, null, true, false, "Tahirpur", null, null, 0L },
                    { 274L, "বিশ্বনাথ", null, null, 36L, null, true, false, "Bishwanath", null, null, 0L },
                    { 273L, "বিয়ানীবাজার", null, null, 36L, null, true, false, "Beanibazar", null, null, 0L },
                    { 272L, "বালাগঞ্জ", null, null, 36L, null, true, false, "Balaganj", null, null, 0L },
                    { 271L, "তালতলি", null, null, 35L, null, true, false, "Taltali", null, null, 0L },
                    { 270L, "পাথরঘাটা", null, null, 35L, null, true, false, "Pathorghata", null, null, 0L },
                    { 269L, "বামনা", null, null, 35L, null, true, false, "Bamna", null, null, 0L },
                    { 268L, "বেতাগী", null, null, 35L, null, true, false, "Betagi", null, null, 0L },
                    { 267L, "বরগুনা সদর", null, null, 35L, null, true, false, "Barguna Sadar", null, null, 0L },
                    { 266L, "আমতলী", null, null, 35L, null, true, false, "Amtali", null, null, 0L },
                    { 265L, "লালমোহন", null, null, 34L, null, true, false, "Lalmohan", null, null, 0L },
                    { 264L, "তজুমদ্দিন", null, null, 34L, null, true, false, "Tazumuddin", null, null, 0L },
                    { 263L, "মনপুরা", null, null, 34L, null, true, false, "Monpura", null, null, 0L },
                    { 262L, "দৌলতখান", null, null, 34L, null, true, false, "Doulatkhan", null, null, 0L },
                    { 261L, "চরফ্যাশন", null, null, 34L, null, true, false, "Charfesson", null, null, 0L },
                    { 260L, "বোরহান উদ্দিন", null, null, 34L, null, true, false, "Borhan Sddin", null, null, 0L },
                    { 259L, "ভোলা সদর", null, null, 34L, null, true, false, "Bhola Sadar", null, null, 0L },
                    { 258L, "হিজলা", null, null, 33L, null, true, false, "Hizla", null, null, 0L },
                    { 257L, "মুলাদী", null, null, 33L, null, true, false, "Muladi", null, null, 0L },
                    { 256L, "মেহেন্দিগঞ্জ", null, null, 33L, null, true, false, "Mehendiganj", null, null, 0L },
                    { 255L, "আগৈলঝাড়া", null, null, 33L, null, true, false, "Agailjhara", null, null, 0L },
                    { 254L, "গৌরনদী", null, null, 33L, null, true, false, "Gournadi", null, null, 0L },
                    { 253L, "বানারীপাড়া", null, null, 33L, null, true, false, "Banaripara", null, null, 0L },
                    { 252L, "উজিরপুর", null, null, 33L, null, true, false, "Wazirpur", null, null, 0L },
                    { 251L, "বাবুগঞ্জ", null, null, 33L, null, true, false, "Babuganj", null, null, 0L },
                    { 250L, "বাকেরগঞ্জ", null, null, 33L, null, true, false, "Bakerganj", null, null, 0L },
                    { 249L, "বরিশাল সদর", null, null, 33L, null, true, false, "Barisal Sadar", null, null, 0L },
                    { 248L, "নেছারাবাদ", null, null, 32L, null, true, false, "Nesarabad", null, null, 0L },
                    { 275L, "কোম্পানীগঞ্জ", null, null, 36L, null, true, false, "Companiganj", null, null, 0L },
                    { 307L, "ধর্মপাশা", null, null, 39L, null, true, false, "Dharmapasha", null, null, 0L },
                    { 276L, "ফেঞ্চুগঞ্জ", null, null, 36L, null, true, false, "Fenchuganj", null, null, 0L },
                    { 278L, "গোয়াইনঘাট", null, null, 36L, null, true, false, "Gowainghat", null, null, 0L },
                    { 305L, "দোয়ারাবাজার", null, null, 39L, null, true, false, "Dowarabazar", null, null, 0L },
                    { 367L, "কেরাণীগঞ্জ", null, null, 47L, null, true, false, "Keraniganj", null, null, 0L },
                    { 303L, "ছাতক", null, null, 39L, null, true, false, "Chhatak", null, null, 0L },
                    { 302L, "বিশ্বম্ভরপুর", null, null, 39L, null, true, false, "Bishwambarpur", null, null, 0L },
                    { 301L, "দক্ষিণ সুনামগঞ্জ", null, null, 39L, null, true, false, "South Sunamganj", null, null, 0L },
                    { 300L, "সুনামগঞ্জ সদর", null, null, 39L, null, true, false, "Sunamganj Sadar", null, null, 0L },
                    { 299L, "মাধবপুর", null, null, 38L, null, true, false, "Madhabpur", null, null, 0L },
                    { 298L, "হবিগঞ্জ সদর", null, null, 38L, null, true, false, "Habiganj Sadar", null, null, 0L },
                    { 297L, "চুনারুঘাট", null, null, 38L, null, true, false, "Chunarughat", null, null, 0L },
                    { 296L, "লাখাই", null, null, 38L, null, true, false, "Lakhai", null, null, 0L },
                    { 295L, "বানিয়াচং", null, null, 38L, null, true, false, "Baniachong", null, null, 0L },
                    { 294L, "আজমিরীগঞ্জ", null, null, 38L, null, true, false, "Ajmiriganj", null, null, 0L },
                    { 293L, "বাহুবল", null, null, 38L, null, true, false, "Bahubal", null, null, 0L },
                    { 292L, "নবীগঞ্জ", null, null, 38L, null, true, false, "Nabiganj", null, null, 0L },
                    { 291L, "জুড়ী", null, null, 37L, null, true, false, "Juri", null, null, 0L },
                    { 290L, "শ্রীমঙ্গল", null, null, 37L, null, true, false, "Sreemangal", null, null, 0L },
                    { 289L, "রাজনগর", null, null, 37L, null, true, false, "Rajnagar", null, null, 0L },
                    { 288L, "মৌলভীবাজার সদর", null, null, 37L, null, true, false, "Moulvibazar Sadar", null, null, 0L },
                    { 287L, "কুলাউড়া", null, null, 37L, null, true, false, "Kulaura", null, null, 0L },
                    { 286L, "কমলগঞ্জ", null, null, 37L, null, true, false, "Kamolganj", null, null, 0L },
                    { 285L, "বড়লেখা", null, null, 37L, null, true, false, "Barlekha", null, null, 0L },
                    { 284L, "ওসমানী নগর", null, null, 36L, null, true, false, "Osmaninagar", null, null, 0L },
                    { 283L, "দক্ষিণ সুরমা", null, null, 36L, null, true, false, "Dakshinsurma", null, null, 0L },
                    { 282L, "জকিগঞ্জ", null, null, 36L, null, true, false, "Zakiganj", null, null, 0L },
                    { 281L, "সিলেট সদর", null, null, 36L, null, true, false, "Sylhet Sadar", null, null, 0L },
                    { 280L, "কানাইঘাট", null, null, 36L, null, true, false, "Kanaighat", null, null, 0L },
                    { 279L, "জৈন্তাপুর", null, null, 36L, null, true, false, "Jaintiapur", null, null, 0L },
                    { 277L, "গোলাপগঞ্জ", null, null, 36L, null, true, false, "Golapganj", null, null, 0L },
                    { 368L, "নবাবগঞ্জ", null, null, 47L, null, true, false, "Nawabganj", null, null, 0L },
                    { 372L, "সিরাজদিখান", null, null, 48L, null, true, false, "Sirajdikhan", null, null, 0L },
                    { 370L, "মুন্সিগঞ্জ সদর", null, null, 48L, null, true, false, "Munshiganj Sadar", null, null, 0L },
                    { 458L, "নালিতাবাড়ী", null, null, 61L, null, true, false, "Nalitabari", null, null, 0L },
                    { 457L, "শেরপুর সদর", null, null, 61L, null, true, false, "Sherpur Sadar", null, null, 0L },
                    { 456L, "চর রাজিবপুর", null, null, 60L, null, true, false, "Charrajibpur", null, null, 0L },
                    { 455L, "রৌমারী", null, null, 60L, null, true, false, "Rowmari", null, null, 0L },
                    { 454L, "চিলমারী", null, null, 60L, null, true, false, "Chilmari", null, null, 0L },
                    { 453L, "উলিপুর", null, null, 60L, null, true, false, "Ulipur", null, null, 0L },
                    { 452L, "রাজারহাট", null, null, 60L, null, true, false, "Rajarhat", null, null, 0L },
                    { 451L, "ফুলবাড়ী", null, null, 60L, null, true, false, "Phulbari", null, null, 0L },
                    { 450L, "ভুরুঙ্গামারী", null, null, 60L, null, true, false, "Bhurungamari", null, null, 0L },
                    { 449L, "নাগেশ্বরী", null, null, 60L, null, true, false, "Nageshwari", null, null, 0L },
                    { 448L, "কুড়িগ্রাম সদর", null, null, 60L, null, true, false, "Kurigram Sadar", null, null, 0L },
                    { 447L, "পীরগাছা", null, null, 59L, null, true, false, "Pirgacha", null, null, 0L },
                    { 459L, "শ্রীবরদী", null, null, 61L, null, true, false, "Sreebordi", null, null, 0L },
                    { 446L, "কাউনিয়া", null, null, 59L, null, true, false, "Kaunia", null, null, 0L },
                    { 444L, "মিঠাপুকুর", null, null, 59L, null, true, false, "Mithapukur", null, null, 0L },
                    { 443L, "বদরগঞ্জ", null, null, 59L, null, true, false, "Badargonj", null, null, 0L },
                    { 442L, "তারাগঞ্জ", null, null, 59L, null, true, false, "Taragonj", null, null, 0L },
                    { 441L, "গংগাচড়া", null, null, 59L, null, true, false, "Gangachara", null, null, 0L },
                    { 440L, "রংপুর সদর", null, null, 59L, null, true, false, "Rangpur Sadar", null, null, 0L },
                    { 439L, "বালিয়াডাঙ্গী", null, null, 58L, null, true, false, "Baliadangi", null, null, 0L },
                    { 438L, "হরিপুর", null, null, 58L, null, true, false, "Haripur", null, null, 0L },
                    { 437L, "রাণীশংকৈল", null, null, 58L, null, true, false, "Ranisankail", null, null, 0L },
                    { 436L, "পীরগঞ্জ", null, null, 58L, null, true, false, "Pirganj", null, null, 0L },
                    { 435L, "ঠাকুরগাঁও সদর", null, null, 58L, null, true, false, "Thakurgaon Sadar", null, null, 0L },
                    { 434L, "ফুলছড়ি", null, null, 57L, null, true, false, "Phulchari", null, null, 0L },
                    { 433L, "সুন্দরগঞ্জ", null, null, 57L, null, true, false, "Sundarganj", null, null, 0L },
                    { 445L, "পীরগঞ্জ", null, null, 59L, null, true, false, "Pirgonj", null, null, 0L },
                    { 460L, "নকলা", null, null, 61L, null, true, false, "Nokla", null, null, 0L },
                    { 461L, "ঝিনাইগাতী", null, null, 61L, null, true, false, "Jhenaigati", null, null, 0L },
                    { 462L, "ফুলবাড়ীয়া", null, null, 62L, null, true, false, "Fulbaria", null, null, 0L },
                    { 489L, "মোহনগঞ্জ", null, null, 64L, null, true, false, "Mohongonj", null, null, 0L },
                    { 488L, "কলমাকান্দা", null, null, 64L, null, true, false, "Kalmakanda", null, null, 0L },
                    { 487L, "খালিয়াজুরী", null, null, 64L, null, true, false, "Khaliajuri", null, null, 0L },
                    { 486L, "মদন", null, null, 64L, null, true, false, "Madan", null, null, 0L },
                    { 485L, "আটপাড়া", null, null, 64L, null, true, false, "Atpara", null, null, 0L },
                    { 484L, "কেন্দুয়া", null, null, 64L, null, true, false, "Kendua", null, null, 0L },
                    { 483L, "দুর্গাপুর", null, null, 64L, null, true, false, "Durgapur", null, null, 0L },
                    { 482L, "বারহাট্টা", null, null, 64L, null, true, false, "Barhatta", null, null, 0L },
                    { 481L, "বকশীগঞ্জ", null, null, 63L, null, true, false, "Bokshiganj", null, null, 0L },
                    { 480L, "মাদারগঞ্জ", null, null, 63L, null, true, false, "Madarganj", null, null, 0L },
                    { 479L, "সরিষাবাড়ী", null, null, 63L, null, true, false, "Sarishabari", null, null, 0L },
                    { 478L, "দেওয়ানগঞ্জ", null, null, 63L, null, true, false, "Dewangonj", null, null, 0L },
                    { 477L, "ইসলামপুর", null, null, 63L, null, true, false, "Islampur", null, null, 0L },
                    { 476L, "মেলান্দহ", null, null, 63L, null, true, false, "Melandah", null, null, 0L },
                    { 475L, "জামালপুর সদর", null, null, 63L, null, true, false, "Jamalpur Sadar", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Upazila",
                columns: new[] { "Id", "BnName", "CreatedAt", "CreatedBy", "DistrictId", "DivisionId", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 474L, "তারাকান্দা", null, null, 62L, null, true, false, "Tarakanda", null, null, 0L },
                    { 473L, "নান্দাইল", null, null, 62L, null, true, false, "Nandail", null, null, 0L },
                    { 472L, "ঈশ্বরগঞ্জ", null, null, 62L, null, true, false, "Iswarganj", null, null, 0L },
                    { 471L, "গফরগাঁও", null, null, 62L, null, true, false, "Gafargaon", null, null, 0L },
                    { 470L, "গৌরীপুর", null, null, 62L, null, true, false, "Gouripur", null, null, 0L },
                    { 469L, "হালুয়াঘাট", null, null, 62L, null, true, false, "Haluaghat", null, null, 0L },
                    { 468L, "ফুলপুর", null, null, 62L, null, true, false, "Phulpur", null, null, 0L },
                    { 467L, "ধোবাউড়া", null, null, 62L, null, true, false, "Dhobaura", null, null, 0L },
                    { 466L, "ময়মনসিংহ সদর", null, null, 62L, null, true, false, "Mymensingh Sadar", null, null, 0L },
                    { 465L, "মুক্তাগাছা", null, null, 62L, null, true, false, "Muktagacha", null, null, 0L },
                    { 464L, "ভালুকা", null, null, 62L, null, true, false, "Bhaluka", null, null, 0L },
                    { 463L, "ত্রিশাল", null, null, 62L, null, true, false, "Trishal", null, null, 0L },
                    { 432L, "গোবিন্দগঞ্জ", null, null, 57L, null, true, false, "Gobindaganj", null, null, 0L },
                    { 431L, "সাঘাটা", null, null, 57L, null, true, false, "Saghata", null, null, 0L },
                    { 430L, "পলাশবাড়ী", null, null, 57L, null, true, false, "Palashbari", null, null, 0L },
                    { 429L, "গাইবান্ধা সদর", null, null, 57L, null, true, false, "Gaibandha Sadar", null, null, 0L },
                    { 397L, "মধুখালী", null, null, 52L, null, true, false, "Madhukhali", null, null, 0L },
                    { 396L, "চরভদ্রাসন", null, null, 52L, null, true, false, "Charbhadrasan", null, null, 0L },
                    { 395L, "ভাঙ্গা", null, null, 52L, null, true, false, "Bhanga", null, null, 0L },
                    { 394L, "নগরকান্দা", null, null, 52L, null, true, false, "Nagarkanda", null, null, 0L },
                    { 393L, "সদরপুর", null, null, 52L, null, true, false, "Sadarpur", null, null, 0L },
                    { 392L, "বোয়ালমারী", null, null, 52L, null, true, false, "Boalmari", null, null, 0L },
                    { 391L, "আলফাডাঙ্গা", null, null, 52L, null, true, false, "Alfadanga", null, null, 0L },
                    { 390L, "ফরিদপুর সদর", null, null, 52L, null, true, false, "Faridpur Sadar", null, null, 0L },
                    { 389L, "মুকসুদপুর", null, null, 51L, null, true, false, "Muksudpur", null, null, 0L },
                    { 388L, "কোটালীপাড়া", null, null, 51L, null, true, false, "Kotalipara", null, null, 0L },
                    { 387L, "টুংগীপাড়া", null, null, 51L, null, true, false, "Tungipara", null, null, 0L },
                    { 386L, "কাশিয়ানী", null, null, 51L, null, true, false, "Kashiani", null, null, 0L },
                    { 385L, "গোপালগঞ্জ সদর", null, null, 51L, null, true, false, "Gopalganj Sadar", null, null, 0L },
                    { 384L, "রাজৈর", null, null, 50L, null, true, false, "Rajoir", null, null, 0L },
                    { 383L, "কালকিনি", null, null, 50L, null, true, false, "Kalkini", null, null, 0L },
                    { 382L, "শিবচর", null, null, 50L, null, true, false, "Shibchar", null, null, 0L },
                    { 381L, "মাদারীপুর সদর", null, null, 50L, null, true, false, "Madaripur Sadar", null, null, 0L },
                    { 380L, "কালুখালী", null, null, 49L, null, true, false, "Kalukhali", null, null, 0L },
                    { 379L, "বালিয়াকান্দি", null, null, 49L, null, true, false, "Baliakandi", null, null, 0L },
                    { 378L, "পাংশা", null, null, 49L, null, true, false, "Pangsa", null, null, 0L },
                    { 377L, "গোয়ালন্দ", null, null, 49L, null, true, false, "Goalanda", null, null, 0L },
                    { 376L, "রাজবাড়ী সদর", null, null, 49L, null, true, false, "Rajbari Sadar", null, null, 0L },
                    { 375L, "টংগীবাড়ি", null, null, 48L, null, true, false, "Tongibari", null, null, 0L },
                    { 374L, "গজারিয়া", null, null, 48L, null, true, false, "Gajaria", null, null, 0L },
                    { 373L, "লৌহজং", null, null, 48L, null, true, false, "Louhajanj", null, null, 0L },
                    { 247L, "মঠবাড়ীয়া", null, null, 32L, null, true, false, "Mathbaria", null, null, 0L },
                    { 371L, "শ্রীনগর", null, null, 48L, null, true, false, "Sreenagar", null, null, 0L },
                    { 398L, "সালথা", null, null, 52L, null, true, false, "Saltha", null, null, 0L },
                    { 369L, "দোহার", null, null, 47L, null, true, false, "Dohar", null, null, 0L },
                    { 399L, "পঞ্চগড় সদর", null, null, 53L, null, true, false, "Panchagarh Sadar", null, null, 0L },
                    { 401L, "বোদা", null, null, 53L, null, true, false, "Boda", null, null, 0L },
                    { 428L, "সাদুল্লাপুর", null, null, 57L, null, true, false, "Sadullapur", null, null, 0L },
                    { 427L, "নীলফামারী সদর", null, null, 56L, null, true, false, "Nilphamari Sadar", null, null, 0L },
                    { 426L, "কিশোরগঞ্জ", null, null, 56L, null, true, false, "Kishorganj", null, null, 0L },
                    { 425L, "জলঢাকা", null, null, 56L, null, true, false, "Jaldhaka", null, null, 0L },
                    { 424L, "ডিমলা", null, null, 56L, null, true, false, "Dimla", null, null, 0L },
                    { 423L, "ডোমার", null, null, 56L, null, true, false, "Domar", null, null, 0L },
                    { 422L, "সৈয়দপুর", null, null, 56L, null, true, false, "Syedpur", null, null, 0L },
                    { 421L, "আদিতমারী", null, null, 55L, null, true, false, "Aditmari", null, null, 0L },
                    { 420L, "পাটগ্রাম", null, null, 55L, null, true, false, "Patgram", null, null, 0L },
                    { 419L, "হাতীবান্ধা", null, null, 55L, null, true, false, "Hatibandha", null, null, 0L },
                    { 418L, "কালীগঞ্জ", null, null, 55L, null, true, false, "Kaliganj", null, null, 0L },
                    { 417L, "লালমনিরহাট সদর", null, null, 55L, null, true, false, "Lalmonirhat Sadar", null, null, 0L },
                    { 416L, "চিরিরবন্দর", null, null, 54L, null, true, false, "Chirirbandar", null, null, 0L },
                    { 415L, "বিরল", null, null, 54L, null, true, false, "Birol", null, null, 0L },
                    { 414L, "খানসামা", null, null, 54L, null, true, false, "Khansama", null, null, 0L },
                    { 413L, "হাকিমপুর", null, null, 54L, null, true, false, "Hakimpur", null, null, 0L },
                    { 412L, "দিনাজপুর সদর", null, null, 54L, null, true, false, "Dinajpur Sadar", null, null, 0L },
                    { 411L, "ফুলবাড়ী", null, null, 54L, null, true, false, "Fulbari", null, null, 0L },
                    { 410L, "কাহারোল", null, null, 54L, null, true, false, "Kaharol", null, null, 0L },
                    { 409L, "বোচাগঞ্জ", null, null, 54L, null, true, false, "Bochaganj", null, null, 0L },
                    { 408L, "পার্বতীপুর", null, null, 54L, null, true, false, "Parbatipur", null, null, 0L },
                    { 407L, "বিরামপুর", null, null, 54L, null, true, false, "Birampur", null, null, 0L },
                    { 406L, "ঘোড়াঘাট", null, null, 54L, null, true, false, "Ghoraghat", null, null, 0L },
                    { 405L, "বীরগঞ্জ", null, null, 54L, null, true, false, "Birganj", null, null, 0L },
                    { 404L, "নবাবগঞ্জ", null, null, 54L, null, true, false, "Nawabganj", null, null, 0L },
                    { 403L, "তেতুলিয়া", null, null, 53L, null, true, false, "Tetulia", null, null, 0L },
                    { 402L, "আটোয়ারী", null, null, 53L, null, true, false, "Atwari", null, null, 0L },
                    { 400L, "দেবীগঞ্জ", null, null, 53L, null, true, false, "Debiganj", null, null, 0L },
                    { 246L, "ভান্ডারিয়া", null, null, 32L, null, true, false, "Bhandaria", null, null, 0L },
                    { 242L, "পিরোজপুর সদর", null, null, 32L, null, true, false, "Pirojpur Sadar", null, null, 0L },
                    { 244L, "কাউখালী", null, null, 32L, null, true, false, "Kawkhali", null, null, 0L },
                    { 88L, "খাগড়াছড়ি সদর", null, null, 10L, null, true, false, "Khagrachhari Sadar", null, null, 0L },
                    { 87L, "টেকনাফ", null, null, 9L, null, true, false, "Teknaf", null, null, 0L },
                    { 86L, "রামু", null, null, 9L, null, true, false, "Ramu", null, null, 0L },
                    { 85L, "পেকুয়া", null, null, 9L, null, true, false, "Pekua", null, null, 0L },
                    { 84L, "মহেশখালী", null, null, 9L, null, true, false, "Moheshkhali", null, null, 0L },
                    { 83L, "উখিয়া", null, null, 9L, null, true, false, "Ukhiya", null, null, 0L },
                    { 82L, "কুতুবদিয়া", null, null, 9L, null, true, false, "Kutubdia", null, null, 0L },
                    { 81L, "চকরিয়া", null, null, 9L, null, true, false, "Chakaria", null, null, 0L },
                    { 80L, "কক্সবাজার সদর", null, null, 9L, null, true, false, "Coxsbazar Sadar", null, null, 0L },
                    { 79L, "কর্ণফুলী", null, null, 8L, null, true, false, "Karnafuli", null, null, 0L },
                    { 78L, "রাউজান", null, null, 8L, null, true, false, "Raozan", null, null, 0L },
                    { 77L, "ফটিকছড়ি", null, null, 8L, null, true, false, "Fatikchhari", null, null, 0L },
                    { 89L, "দিঘীনালা", null, null, 10L, null, true, false, "Dighinala", null, null, 0L },
                    { 76L, "হাটহাজারী", null, null, 8L, null, true, false, "Hathazari", null, null, 0L },
                    { 74L, "সাতকানিয়া", null, null, 8L, null, true, false, "Satkania", null, null, 0L },
                    { 73L, "চন্দনাইশ", null, null, 8L, null, true, false, "Chandanaish", null, null, 0L },
                    { 72L, "আনোয়ারা", null, null, 8L, null, true, false, "Anwara", null, null, 0L },
                    { 71L, "বোয়ালখালী", null, null, 8L, null, true, false, "Boalkhali", null, null, 0L },
                    { 70L, "বাঁশখালী", null, null, 8L, null, true, false, "Banshkhali", null, null, 0L },
                    { 69L, "সন্দ্বীপ", null, null, 8L, null, true, false, "Sandwip", null, null, 0L },
                    { 68L, "পটিয়া", null, null, 8L, null, true, false, "Patiya", null, null, 0L },
                    { 67L, "মীরসরাই", null, null, 8L, null, true, false, "Mirsharai", null, null, 0L },
                    { 66L, "সীতাকুন্ড", null, null, 8L, null, true, false, "Sitakunda", null, null, 0L },
                    { 65L, "রাঙ্গুনিয়া", null, null, 8L, null, true, false, "Rangunia", null, null, 0L },
                    { 64L, "রামগঞ্জ", null, null, 7L, null, true, false, "Ramganj", null, null, 0L },
                    { 63L, "রামগতি", null, null, 7L, null, true, false, "Ramgati", null, null, 0L },
                    { 75L, "লোহাগাড়া", null, null, 8L, null, true, false, "Lohagara", null, null, 0L },
                    { 90L, "পানছড়ি", null, null, 10L, null, true, false, "Panchari", null, null, 0L },
                    { 91L, "লক্ষীছড়ি", null, null, 10L, null, true, false, "Laxmichhari", null, null, 0L },
                    { 92L, "মহালছড়ি", null, null, 10L, null, true, false, "Mohalchari", null, null, 0L },
                    { 119L, "চাটমোহর", null, null, 13L, null, true, false, "Chatmohar", null, null, 0L },
                    { 118L, "আটঘরিয়া", null, null, 13L, null, true, false, "Atghoria", null, null, 0L },
                    { 117L, "বেড়া", null, null, 13L, null, true, false, "Bera", null, null, 0L },
                    { 116L, "পাবনা সদর", null, null, 13L, null, true, false, "Pabna Sadar", null, null, 0L },
                    { 115L, "ভাঙ্গুড়া", null, null, 13L, null, true, false, "Bhangura", null, null, 0L },
                    { 114L, "ঈশ্বরদী", null, null, 13L, null, true, false, "Ishurdi", null, null, 0L },
                    { 113L, "সুজানগর", null, null, 13L, null, true, false, "Sujanagar", null, null, 0L },
                    { 112L, "উল্লাপাড়া", null, null, 12L, null, true, false, "Ullapara", null, null, 0L },
                    { 111L, "তাড়াশ", null, null, 12L, null, true, false, "Tarash", null, null, 0L },
                    { 110L, "সিরাজগঞ্জ সদর", null, null, 12L, null, true, false, "Sirajganj Sadar", null, null, 0L },
                    { 109L, "শাহজাদপুর", null, null, 12L, null, true, false, "Shahjadpur", null, null, 0L },
                    { 108L, "রায়গঞ্জ", null, null, 12L, null, true, false, "Raigonj", null, null, 0L },
                    { 107L, "কাজীপুর", null, null, 12L, null, true, false, "Kazipur", null, null, 0L },
                    { 106L, "কামারখন্দ", null, null, 12L, null, true, false, "Kamarkhand", null, null, 0L },
                    { 105L, "চৌহালি", null, null, 12L, null, true, false, "Chauhali", null, null, 0L },
                    { 104L, "বেলকুচি", null, null, 12L, null, true, false, "Belkuchi", null, null, 0L },
                    { 103L, "থানচি", null, null, 11L, null, true, false, "Thanchi", null, null, 0L },
                    { 102L, "রুমা", null, null, 11L, null, true, false, "Ruma", null, null, 0L },
                    { 101L, "লামা", null, null, 11L, null, true, false, "Lama", null, null, 0L },
                    { 100L, "রোয়াংছড়ি", null, null, 11L, null, true, false, "Rowangchhari", null, null, 0L },
                    { 99L, "নাইক্ষ্যংছড়ি", null, null, 11L, null, true, false, "Naikhongchhari", null, null, 0L },
                    { 98L, "আলীকদম", null, null, 11L, null, true, false, "Alikadam", null, null, 0L },
                    { 97L, "বান্দরবান সদর", null, null, 11L, null, true, false, "Bandarban Sadar", null, null, 0L },
                    { 96L, "গুইমারা", null, null, 10L, null, true, false, "Guimara", null, null, 0L },
                    { 95L, "মাটিরাঙ্গা", null, null, 10L, null, true, false, "Matiranga", null, null, 0L },
                    { 94L, "রামগড়", null, null, 10L, null, true, false, "Ramgarh", null, null, 0L },
                    { 93L, "মানিকছড়ি", null, null, 10L, null, true, false, "Manikchari", null, null, 0L },
                    { 62L, "রায়পুর", null, null, 7L, null, true, false, "Raipur", null, null, 0L },
                    { 61L, "কমলনগর", null, null, 7L, null, true, false, "Kamalnagar", null, null, 0L },
                    { 60L, "লক্ষ্মীপুর সদর", null, null, 7L, null, true, false, "Lakshmipur Sadar", null, null, 0L },
                    { 59L, "ফরিদগঞ্জ", null, null, 6L, null, true, false, "Faridgonj", null, null, 0L },
                    { 27L, "সরাইল", null, null, 3L, null, true, false, "Sarail", null, null, 0L },
                    { 26L, "নাসিরনগর", null, null, 3L, null, true, false, "Nasirnagar", null, null, 0L },
                    { 25L, "কসবা", null, null, 3L, null, true, false, "Kasba", null, null, 0L },
                    { 24L, "ব্রাহ্মণবাড়িয়া সদর", null, null, 3L, null, true, false, "Brahmanbaria Sadar", null, null, 0L },
                    { 23L, "দাগনভূঞা", null, null, 2L, null, true, false, "Daganbhuiyan", null, null, 0L },
                    { 22L, "পরশুরাম", null, null, 2L, null, true, false, "Parshuram", null, null, 0L },
                    { 21L, "ফুলগাজী", null, null, 2L, null, true, false, "Fulgazi", null, null, 0L },
                    { 20L, "সোনাগাজী", null, null, 2L, null, true, false, "Sonagazi", null, null, 0L },
                    { 19L, "ফেনী সদর", null, null, 2L, null, true, false, "Feni Sadar", null, null, 0L },
                    { 18L, "ছাগলনাইয়া", null, null, 2L, null, true, false, "Chhagalnaiya", null, null, 0L },
                    { 17L, "লালমাই", null, null, 1L, null, true, false, "Lalmai", null, null, 0L },
                    { 16L, "বুড়িচং", null, null, 1L, null, true, false, "Burichang", null, null, 0L },
                    { 15L, "তিতাস", null, null, 1L, null, true, false, "Titas", null, null, 0L },
                    { 14L, "সদর দক্ষিণ", null, null, 1L, null, true, false, "Sadarsouth", null, null, 0L },
                    { 13L, "মনোহরগঞ্জ", null, null, 1L, null, true, false, "Monohargonj", null, null, 0L },
                    { 12L, "মেঘনা", null, null, 1L, null, true, false, "Meghna", null, null, 0L },
                    { 11L, "কুমিল্লা সদর", null, null, 1L, null, true, false, "Comilla Sadar", null, null, 0L },
                    { 10L, "নাঙ্গলকোট", null, null, 1L, null, true, false, "Nangalkot", null, null, 0L },
                    { 9L, "মুরাদনগর", null, null, 1L, null, true, false, "Muradnagar", null, null, 0L },
                    { 8L, "লাকসাম", null, null, 1L, null, true, false, "Laksam", null, null, 0L },
                    { 7L, "হোমনা", null, null, 1L, null, true, false, "Homna", null, null, 0L },
                    { 6L, "দাউদকান্দি", null, null, 1L, null, true, false, "Daudkandi", null, null, 0L },
                    { 5L, "চৌদ্দগ্রাম", null, null, 1L, null, true, false, "Chauddagram", null, null, 0L },
                    { 4L, "চান্দিনা", null, null, 1L, null, true, false, "Chandina", null, null, 0L },
                    { 3L, "ব্রাহ্মণপাড়া", null, null, 1L, null, true, false, "Brahmanpara", null, null, 0L },
                    { 2L, "বরুড়া", null, null, 1L, null, true, false, "Barura", null, null, 0L },
                    { 1L, "দেবিদ্বার", null, null, 1L, null, true, false, "Debidwar", null, null, 0L },
                    { 28L, "আশুগঞ্জ", null, null, 3L, null, true, false, "Ashuganj", null, null, 0L },
                    { 120L, "সাঁথিয়া", null, null, 13L, null, true, false, "Santhia", null, null, 0L },
                    { 29L, "আখাউড়া", null, null, 3L, null, true, false, "Akhaura", null, null, 0L },
                    { 31L, "বাঞ্ছারামপুর", null, null, 3L, null, true, false, "Bancharampur", null, null, 0L },
                    { 58L, "মতলব উত্তর", null, null, 6L, null, true, false, "Matlab North", null, null, 0L },
                    { 57L, "হাজীগঞ্জ", null, null, 6L, null, true, false, "Hajiganj", null, null, 0L },
                    { 56L, "মতলব দক্ষিণ", null, null, 6L, null, true, false, "Matlab South", null, null, 0L },
                    { 55L, "চাঁদপুর সদর", null, null, 6L, null, true, false, "Chandpur Sadar", null, null, 0L }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Upazila",
                columns: new[] { "Id", "BnName", "CreatedAt", "CreatedBy", "DistrictId", "DivisionId", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 54L, "শাহরাস্তি", null, null, 6L, null, true, false, "Shahrasti", null, null, 0L },
                    { 53L, "কচুয়া", null, null, 6L, null, true, false, "Kachua", null, null, 0L },
                    { 52L, "হাইমচর", null, null, 6L, null, true, false, "Haimchar", null, null, 0L },
                    { 51L, "সোনাইমুড়ী", null, null, 5L, null, true, false, "Sonaimori", null, null, 0L },
                    { 50L, "চাটখিল", null, null, 5L, null, true, false, "Chatkhil", null, null, 0L },
                    { 49L, "সেনবাগ", null, null, 5L, null, true, false, "Senbug", null, null, 0L },
                    { 48L, "কবিরহাট", null, null, 5L, null, true, false, "Kabirhat", null, null, 0L },
                    { 47L, "সুবর্ণচর", null, null, 5L, null, true, false, "Subarnachar", null, null, 0L },
                    { 46L, "হাতিয়া", null, null, 5L, null, true, false, "Hatia", null, null, 0L },
                    { 45L, "বেগমগঞ্জ", null, null, 5L, null, true, false, "Begumganj", null, null, 0L },
                    { 44L, "কোম্পানীগঞ্জ", null, null, 5L, null, true, false, "Companiganj", null, null, 0L },
                    { 43L, "নোয়াখালী সদর", null, null, 5L, null, true, false, "Noakhali Sadar", null, null, 0L },
                    { 42L, "নানিয়ারচর", null, null, 4L, null, true, false, "Naniarchar", null, null, 0L },
                    { 41L, "জুরাছড়ি", null, null, 4L, null, true, false, "Juraichari", null, null, 0L },
                    { 40L, "বিলাইছড়ি", null, null, 4L, null, true, false, "Belaichari", null, null, 0L },
                    { 39L, "রাজস্থলী", null, null, 4L, null, true, false, "Rajasthali", null, null, 0L },
                    { 38L, "লংগদু", null, null, 4L, null, true, false, "Langadu", null, null, 0L },
                    { 37L, "বরকল", null, null, 4L, null, true, false, "Barkal", null, null, 0L },
                    { 36L, "বাঘাইছড়ি", null, null, 4L, null, true, false, "Baghaichari", null, null, 0L },
                    { 35L, "কাউখালী", null, null, 4L, null, true, false, "Kawkhali", null, null, 0L },
                    { 34L, "কাপ্তাই", null, null, 4L, null, true, false, "Kaptai", null, null, 0L },
                    { 33L, "রাঙ্গামাটি সদর", null, null, 4L, null, true, false, "Rangamati Sadar", null, null, 0L },
                    { 32L, "বিজয়নগর", null, null, 3L, null, true, false, "Bijoynagar", null, null, 0L },
                    { 30L, "নবীনগর", null, null, 3L, null, true, false, "Nabinagar", null, null, 0L },
                    { 121L, "ফরিদপুর", null, null, 13L, null, true, false, "Faridpur", null, null, 0L },
                    { 122L, "কাহালু", null, null, 14L, null, true, false, "Kahaloo", null, null, 0L },
                    { 123L, "বগুড়া সদর", null, null, 14L, null, true, false, "Bogra Sadar", null, null, 0L },
                    { 212L, "বটিয়াঘাটা", null, null, 27L, null, true, false, "Botiaghata", null, null, 0L },
                    { 211L, "ডুমুরিয়া", null, null, 27L, null, true, false, "Dumuria", null, null, 0L },
                    { 210L, "তেরখাদা", null, null, 27L, null, true, false, "Terokhada", null, null, 0L },
                    { 209L, "রূপসা", null, null, 27L, null, true, false, "Rupsha", null, null, 0L },
                    { 208L, "দিঘলিয়া", null, null, 27L, null, true, false, "Digholia", null, null, 0L },
                    { 207L, "ফুলতলা", null, null, 27L, null, true, false, "Fultola", null, null, 0L },
                    { 206L, "পাইকগাছা", null, null, 27L, null, true, false, "Paikgasa", null, null, 0L },
                    { 205L, "মহম্মদপুর", null, null, 26L, null, true, false, "Mohammadpur", null, null, 0L },
                    { 204L, "মাগুরা সদর", null, null, 26L, null, true, false, "Magura Sadar", null, null, 0L },
                    { 203L, "শ্রীপুর", null, null, 26L, null, true, false, "Sreepur", null, null, 0L },
                    { 202L, "শালিখা", null, null, 26L, null, true, false, "Shalikha", null, null, 0L },
                    { 201L, "ভেড়ামারা", null, null, 25L, null, true, false, "Bheramara", null, null, 0L },
                    { 200L, "দৌলতপুর", null, null, 25L, null, true, false, "Daulatpur", null, null, 0L },
                    { 199L, "মিরপুর", null, null, 25L, null, true, false, "Mirpur", null, null, 0L },
                    { 198L, "খোকসা", null, null, 25L, null, true, false, "Khoksa", null, null, 0L },
                    { 197L, "কুমারখালী", null, null, 25L, null, true, false, "Kumarkhali", null, null, 0L },
                    { 196L, "কুষ্টিয়া সদর", null, null, 25L, null, true, false, "Kushtia Sadar", null, null, 0L },
                    { 195L, "জীবননগর", null, null, 24L, null, true, false, "Jibannagar", null, null, 0L },
                    { 194L, "দামুড়হুদা", null, null, 24L, null, true, false, "Damurhuda", null, null, 0L },
                    { 193L, "আলমডাঙ্গা", null, null, 24L, null, true, false, "Alamdanga", null, null, 0L },
                    { 192L, "চুয়াডাঙ্গা সদর", null, null, 24L, null, true, false, "Chuadanga Sadar", null, null, 0L },
                    { 191L, "কালিয়া", null, null, 23L, null, true, false, "Kalia", null, null, 0L },
                    { 190L, "লোহাগড়া", null, null, 23L, null, true, false, "Lohagara", null, null, 0L },
                    { 189L, "নড়াইল সদর", null, null, 23L, null, true, false, "Narail Sadar", null, null, 0L },
                    { 188L, "গাংনী", null, null, 22L, null, true, false, "Gangni", null, null, 0L },
                    { 187L, "মেহেরপুর সদর", null, null, 22L, null, true, false, "Meherpur Sadar", null, null, 0L },
                    { 186L, "মুজিবনগর", null, null, 22L, null, true, false, "Mujibnagar", null, null, 0L },
                    { 213L, "দাকোপ", null, null, 27L, null, true, false, "Dakop", null, null, 0L },
                    { 185L, "কালিগঞ্জ", null, null, 21L, null, true, false, "Kaliganj", null, null, 0L },
                    { 214L, "কয়রা", null, null, 27L, null, true, false, "Koyra", null, null, 0L },
                    { 216L, "বাগেরহাট সদর", null, null, 28L, null, true, false, "Bagerhat Sadar", null, null, 0L },
                    { 243L, "নাজিরপুর", null, null, 32L, null, true, false, "Nazirpur", null, null, 0L },
                    { 490L, "পূর্বধলা", null, null, 64L, null, true, false, "Purbadhala", null, null, 0L },
                    { 241L, "রাঙ্গাবালী", null, null, 31L, null, true, false, "Rangabali", null, null, 0L },
                    { 240L, "গলাচিপা", null, null, 31L, null, true, false, "Galachipa", null, null, 0L },
                    { 239L, "মির্জাগঞ্জ", null, null, 31L, null, true, false, "Mirzaganj", null, null, 0L },
                    { 238L, "কলাপাড়া", null, null, 31L, null, true, false, "Kalapara", null, null, 0L },
                    { 237L, "দশমিনা", null, null, 31L, null, true, false, "Dashmina", null, null, 0L },
                    { 236L, "দুমকি", null, null, 31L, null, true, false, "Dumki", null, null, 0L },
                    { 235L, "পটুয়াখালী সদর", null, null, 31L, null, true, false, "Patuakhali Sadar", null, null, 0L },
                    { 234L, "বাউফল", null, null, 31L, null, true, false, "Bauphal", null, null, 0L },
                    { 233L, "রাজাপুর", null, null, 30L, null, true, false, "Rajapur", null, null, 0L },
                    { 232L, "নলছিটি", null, null, 30L, null, true, false, "Nalchity", null, null, 0L },
                    { 231L, "কাঠালিয়া", null, null, 30L, null, true, false, "Kathalia", null, null, 0L },
                    { 230L, "ঝালকাঠি সদর", null, null, 30L, null, true, false, "Jhalakathi Sadar", null, null, 0L },
                    { 229L, "মহেশপুর", null, null, 29L, null, true, false, "Moheshpur", null, null, 0L },
                    { 228L, "কোটচাঁদপুর", null, null, 29L, null, true, false, "Kotchandpur", null, null, 0L },
                    { 227L, "কালীগঞ্জ", null, null, 29L, null, true, false, "Kaliganj", null, null, 0L },
                    { 226L, "হরিণাকুন্ডু", null, null, 29L, null, true, false, "Harinakundu", null, null, 0L },
                    { 225L, "শৈলকুপা", null, null, 29L, null, true, false, "Shailkupa", null, null, 0L },
                    { 224L, "ঝিনাইদহ সদর", null, null, 29L, null, true, false, "Jhenaidah Sadar", null, null, 0L },
                    { 223L, "চিতলমারী", null, null, 28L, null, true, false, "Chitalmari", null, null, 0L },
                    { 222L, "মোংলা", null, null, 28L, null, true, false, "Mongla", null, null, 0L },
                    { 221L, "কচুয়া", null, null, 28L, null, true, false, "Kachua", null, null, 0L },
                    { 220L, "মোড়েলগঞ্জ", null, null, 28L, null, true, false, "Morrelganj", null, null, 0L },
                    { 219L, "রামপাল", null, null, 28L, null, true, false, "Rampal", null, null, 0L },
                    { 218L, "শরণখোলা", null, null, 28L, null, true, false, "Sarankhola", null, null, 0L },
                    { 217L, "মোল্লাহাট", null, null, 28L, null, true, false, "Mollahat", null, null, 0L },
                    { 215L, "ফকিরহাট", null, null, 28L, null, true, false, "Fakirhat", null, null, 0L },
                    { 245L, "জিয়ানগর", null, null, 32L, null, true, false, "Zianagar", null, null, 0L },
                    { 184L, "তালা", null, null, 21L, null, true, false, "Tala", null, null, 0L },
                    { 182L, "সাতক্ষীরা সদর", null, null, 21L, null, true, false, "Satkhira Sadar", null, null, 0L },
                    { 150L, "আক্কেলপুর", null, null, 17L, null, true, false, "Akkelpur", null, null, 0L },
                    { 149L, "নলডাঙ্গা", null, null, 16L, null, true, false, "Naldanga", null, null, 0L },
                    { 148L, "গুরুদাসপুর", null, null, 16L, null, true, false, "Gurudaspur", null, null, 0L },
                    { 147L, "লালপুর", null, null, 16L, null, true, false, "Lalpur", null, null, 0L },
                    { 146L, "বাগাতিপাড়া", null, null, 16L, null, true, false, "Bagatipara", null, null, 0L },
                    { 145L, "বড়াইগ্রাম", null, null, 16L, null, true, false, "Baraigram", null, null, 0L },
                    { 144L, "সিংড়া", null, null, 16L, null, true, false, "Singra", null, null, 0L },
                    { 143L, "নাটোর সদর", null, null, 16L, null, true, false, "Natore Sadar", null, null, 0L },
                    { 142L, "বাগমারা", null, null, 15L, null, true, false, "Bagmara", null, null, 0L },
                    { 141L, "তানোর", null, null, 15L, null, true, false, "Tanore", null, null, 0L },
                    { 140L, "গোদাগাড়ী", null, null, 15L, null, true, false, "Godagari", null, null, 0L },
                    { 139L, "বাঘা", null, null, 15L, null, true, false, "Bagha", null, null, 0L },
                    { 138L, "পুঠিয়া", null, null, 15L, null, true, false, "Puthia", null, null, 0L },
                    { 137L, "চারঘাট", null, null, 15L, null, true, false, "Charghat", null, null, 0L },
                    { 136L, "মোহনপুর", null, null, 15L, null, true, false, "Mohonpur", null, null, 0L },
                    { 135L, "দুর্গাপুর", null, null, 15L, null, true, false, "Durgapur", null, null, 0L },
                    { 134L, "পবা", null, null, 15L, null, true, false, "Paba", null, null, 0L },
                    { 133L, "শিবগঞ্জ", null, null, 14L, null, true, false, "Shibganj", null, null, 0L },
                    { 132L, "শেরপুর", null, null, 14L, null, true, false, "Sherpur", null, null, 0L },
                    { 131L, "গাবতলী", null, null, 14L, null, true, false, "Gabtali", null, null, 0L },
                    { 130L, "ধুনট", null, null, 14L, null, true, false, "Dhunot", null, null, 0L },
                    { 129L, "সোনাতলা", null, null, 14L, null, true, false, "Sonatala", null, null, 0L },
                    { 128L, "নন্দিগ্রাম", null, null, 14L, null, true, false, "Nondigram", null, null, 0L },
                    { 127L, "আদমদিঘি", null, null, 14L, null, true, false, "Adamdighi", null, null, 0L },
                    { 126L, "দুপচাচিঁয়া", null, null, 14L, null, true, false, "Dupchanchia", null, null, 0L },
                    { 125L, "শাজাহানপুর", null, null, 14L, null, true, false, "Shajahanpur", null, null, 0L },
                    { 124L, "সারিয়াকান্দি", null, null, 14L, null, true, false, "Shariakandi", null, null, 0L },
                    { 151L, "কালাই", null, null, 17L, null, true, false, "Kalai", null, null, 0L },
                    { 183L, "শ্যামনগর", null, null, 21L, null, true, false, "Shyamnagar", null, null, 0L },
                    { 152L, "ক্ষেতলাল", null, null, 17L, null, true, false, "Khetlal", null, null, 0L },
                    { 154L, "জয়পুরহাট সদর", null, null, 17L, null, true, false, "Joypurhat Sadar", null, null, 0L },
                    { 181L, "কলারোয়া", null, null, 21L, null, true, false, "Kalaroa", null, null, 0L },
                    { 180L, "দেবহাটা", null, null, 21L, null, true, false, "Debhata", null, null, 0L },
                    { 179L, "আশাশুনি", null, null, 21L, null, true, false, "Assasuni", null, null, 0L },
                    { 178L, "শার্শা", null, null, 20L, null, true, false, "Sharsha", null, null, 0L },
                    { 177L, "যশোর সদর", null, null, 20L, null, true, false, "Jessore Sadar", null, null, 0L },
                    { 176L, "কেশবপুর", null, null, 20L, null, true, false, "Keshabpur", null, null, 0L },
                    { 175L, "ঝিকরগাছা", null, null, 20L, null, true, false, "Jhikargacha", null, null, 0L },
                    { 174L, "চৌগাছা", null, null, 20L, null, true, false, "Chougachha", null, null, 0L },
                    { 173L, "বাঘারপাড়া", null, null, 20L, null, true, false, "Bagherpara", null, null, 0L },
                    { 172L, "অভয়নগর", null, null, 20L, null, true, false, "Abhaynagar", null, null, 0L },
                    { 171L, "মণিরামপুর", null, null, 20L, null, true, false, "Manirampur", null, null, 0L },
                    { 170L, "সাপাহার", null, null, 19L, null, true, false, "Sapahar", null, null, 0L },
                    { 169L, "পোরশা", null, null, 19L, null, true, false, "Porsha", null, null, 0L },
                    { 168L, "নওগাঁ সদর", null, null, 19L, null, true, false, "Naogaon Sadar", null, null, 0L },
                    { 167L, "রাণীনগর", null, null, 19L, null, true, false, "Raninagar", null, null, 0L },
                    { 166L, "আত্রাই", null, null, 19L, null, true, false, "Atrai", null, null, 0L },
                    { 165L, "মান্দা", null, null, 19L, null, true, false, "Manda", null, null, 0L },
                    { 164L, "নিয়ামতপুর", null, null, 19L, null, true, false, "Niamatpur", null, null, 0L },
                    { 163L, "ধামইরহাট", null, null, 19L, null, true, false, "Dhamoirhat", null, null, 0L },
                    { 162L, "পত্নিতলা", null, null, 19L, null, true, false, "Patnitala", null, null, 0L },
                    { 161L, "বদলগাছী", null, null, 19L, null, true, false, "Badalgachi", null, null, 0L },
                    { 160L, "মহাদেবপুর", null, null, 19L, null, true, false, "Mohadevpur", null, null, 0L },
                    { 159L, "শিবগঞ্জ", null, null, 18L, null, true, false, "Shibganj", null, null, 0L },
                    { 158L, "ভোলাহাট", null, null, 18L, null, true, false, "Bholahat", null, null, 0L },
                    { 157L, "নাচোল", null, null, 18L, null, true, false, "Nachol", null, null, 0L },
                    { 156L, "গোমস্তাপুর", null, null, 18L, null, true, false, "Gomostapur", null, null, 0L },
                    { 155L, "চাঁপাইনবাবগঞ্জ সদর", null, null, 18L, null, true, false, "Chapainawabganj Sadar", null, null, 0L },
                    { 153L, "পাঁচবিবি", null, null, 17L, null, true, false, "Panchbibi", null, null, 0L },
                    { 491L, "নেত্রকোণা সদর", null, null, 64L, null, true, false, "Netrokona Sadar", null, null, 0L }
                });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "কুমিল্লা", 1L, "Comilla" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "ফেনী", 1L, "Feni" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "ব্রাহ্মণবাড়িয়া", 1L, "Brahmanbaria" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "রাঙ্গামাটি", 1L, "Rangamati" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "নোয়াখালী", 1L, "Noakhali" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "চাঁদপুর", 1L, "Chandpur" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "লক্ষ্মীপুর", 1L, "Lakshmipur" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "চট্টগ্রাম", 1L, "Chattogram" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "কক্সবাজার", 1L, "Coxsbazar" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "খাগড়াছড়ি", 1L, "Khagrachhari" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "বান্দরবান", 1L, "Bandarban" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "সিরাজগঞ্জ", 2L, "Sirajganj" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "পাবনা", 2L, "Pabna" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "বগুড়া", 2L, "Bogura" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "রাজশাহী", 2L, "Rajshahi" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "নাটোর", 2L, "Natore" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "জয়পুরহাট", 2L, "Joypurhat" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "চাঁপাইনবাবগঞ্জ", 2L, "Chapainawabganj" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "নওগাঁ", 2L, "Naogaon" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "যশোর", 3L, "Jashore" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "সাতক্ষীরা", 3L, "Satkhira" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 22L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "মেহেরপুর", 3L, "Meherpur" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 23L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "নড়াইল", 3L, "Narail" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 24L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "চুয়াডাঙ্গা", 3L, "Chuadanga" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 25L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "কুষ্টিয়া", 3L, "Kushtia" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 26L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "মাগুরা", 3L, "Magura" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 27L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "খুলনা", 3L, "Khulna" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 28L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "বাগেরহাট", 3L, "Bagerhat" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 29L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "ঝিনাইদহ", 3L, "Jhenaidah" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 30L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "ঝালকাঠি", 4L, "Jhalakathi" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 31L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "পটুয়াখালী", 4L, "Patuakhali" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 32L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "পিরোজপুর", 4L, "Pirojpur" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 33L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "বরিশাল", 4L, "Barisal" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 34L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "ভোলা", 4L, "Bhola" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 35L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "বরগুনা", 4L, "Barguna" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 36L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "সিলেট", 5L, "Sylhet" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 37L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "মৌলভীবাজার", 5L, "Moulvibazar" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 38L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "হবিগঞ্জ", 5L, "Habiganj" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 39L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "সুনামগঞ্জ", 5L, "Sunamganj" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 40L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "নরসিংদী", 6L, "Narsingdi" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 41L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "গাজীপুর", 6L, "Gazipur" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 42L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "শরীয়তপুর", 6L, "Shariatpur" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 43L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "নারায়ণগঞ্জ", 6L, "Narayanganj" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 44L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "টাঙ্গাইল", 6L, "Tangail" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 45L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "কিশোরগঞ্জ", 6L, "Kishoreganj" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 46L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "মানিকগঞ্জ", 6L, "Manikganj" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 47L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "ঢাকা", 6L, "Dhaka" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 48L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "মুন্সিগঞ্জ", 6L, "Munshiganj" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 49L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "রাজবাড়ী", 6L, "Rajbari" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 50L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "মাদারীপুর", 6L, "Madaripur" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 51L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "গোপালগঞ্জ", 6L, "Gopalganj" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 52L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "ফরিদপুর", 6L, "Faridpur" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 53L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "পঞ্চগড়", 7L, "Panchagarh" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 54L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "দিনাজপুর", 7L, "Dinajpur" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 55L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "লালমনিরহাট", 7L, "Lalmonirhat" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 56L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "নীলফামারী", 7L, "Nilphamari" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 57L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "গাইবান্ধা", 7L, "Gaibandha" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 58L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "ঠাকুরগাঁও", 7L, "Thakurgaon" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 59L,
                columns: new[] { "BnName", "DivisionId" },
                values: new object[] { "রংপুর", 7L });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 60L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "কুড়িগ্রাম", 7L, "Kurigram" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 61L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "শেরপুর", 8L, "Sherpur" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 62L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "ময়মনসিংহ", 8L, "Mymensingh" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 63L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "জামালপুর", 8L, "Jamalpur" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 64L,
                columns: new[] { "BnName", "DivisionId", "Name" },
                values: new object[] { "নেত্রকোণা", 8L, "Netrokona" });

            migrationBuilder.CreateIndex(
                name: "IX_District_DivisionId",
                schema: "core",
                table: "District",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistory_ActionById",
                schema: "asset",
                table: "CheckoutHistory",
                column: "ActionById");

            migrationBuilder.AddForeignKey(
                name: "FK_District_Division_DivisionId",
                schema: "core",
                table: "District",
                column: "DivisionId",
                principalSchema: "core",
                principalTable: "Division",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_District_Division_DivisionId",
                schema: "core",
                table: "District");

            migrationBuilder.DropTable(
                name: "CheckoutHistory",
                schema: "asset");

            migrationBuilder.DropIndex(
                name: "IX_District_DivisionId",
                schema: "core",
                table: "District");

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Division",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Division",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Division",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Division",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Division",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Division",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Division",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Division",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 54L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 55L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 56L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 57L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 58L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 59L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 60L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 61L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 62L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 63L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 64L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 65L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 66L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 67L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 68L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 69L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 70L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 71L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 72L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 73L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 74L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 75L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 76L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 77L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 78L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 79L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 80L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 81L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 82L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 83L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 84L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 85L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 86L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 87L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 88L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 89L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 90L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 91L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 92L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 93L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 94L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 95L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 96L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 97L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 98L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 99L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 101L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 102L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 103L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 104L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 105L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 106L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 107L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 108L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 109L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 110L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 111L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 112L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 113L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 114L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 115L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 116L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 117L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 118L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 119L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 120L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 121L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 122L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 123L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 124L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 125L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 126L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 127L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 128L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 129L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 130L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 131L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 132L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 133L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 134L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 135L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 136L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 137L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 138L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 139L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 140L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 141L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 142L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 143L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 144L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 145L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 146L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 147L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 148L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 149L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 150L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 151L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 152L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 153L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 154L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 155L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 156L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 157L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 158L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 159L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 160L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 161L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 162L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 163L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 164L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 165L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 166L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 167L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 168L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 169L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 170L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 171L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 172L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 173L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 174L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 175L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 176L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 177L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 178L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 179L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 180L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 181L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 182L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 183L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 184L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 185L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 186L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 187L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 188L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 189L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 190L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 191L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 192L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 193L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 194L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 195L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 196L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 197L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 198L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 199L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 200L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 201L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 202L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 203L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 204L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 205L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 206L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 207L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 208L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 209L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 210L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 211L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 212L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 213L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 214L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 215L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 216L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 217L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 218L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 219L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 220L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 221L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 222L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 223L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 224L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 225L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 226L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 227L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 228L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 229L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 230L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 231L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 232L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 233L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 234L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 235L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 236L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 237L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 238L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 239L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 240L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 241L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 242L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 243L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 244L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 245L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 246L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 247L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 248L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 249L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 250L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 251L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 252L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 253L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 254L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 255L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 256L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 257L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 258L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 259L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 260L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 261L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 262L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 263L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 264L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 265L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 266L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 267L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 268L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 269L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 270L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 271L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 272L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 273L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 274L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 275L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 276L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 277L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 278L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 279L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 280L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 281L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 282L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 283L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 284L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 285L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 286L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 287L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 288L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 289L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 290L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 291L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 292L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 293L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 294L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 295L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 296L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 297L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 298L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 299L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 300L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 301L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 302L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 303L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 304L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 305L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 306L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 307L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 308L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 309L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 310L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 311L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 312L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 313L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 314L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 315L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 316L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 317L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 318L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 319L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 320L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 321L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 322L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 323L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 324L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 325L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 326L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 327L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 328L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 329L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 330L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 331L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 332L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 333L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 334L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 335L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 336L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 337L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 338L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 339L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 340L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 341L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 342L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 343L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 344L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 345L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 346L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 347L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 348L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 349L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 350L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 351L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 352L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 353L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 354L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 355L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 356L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 357L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 358L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 359L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 360L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 361L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 362L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 363L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 364L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 365L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 366L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 367L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 368L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 369L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 370L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 371L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 372L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 373L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 374L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 375L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 376L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 377L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 378L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 379L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 380L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 381L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 382L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 383L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 384L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 385L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 386L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 387L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 388L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 389L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 390L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 391L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 392L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 393L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 394L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 395L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 396L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 397L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 398L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 399L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 400L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 401L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 402L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 403L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 404L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 405L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 406L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 407L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 408L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 409L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 410L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 411L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 412L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 413L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 414L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 415L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 416L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 417L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 418L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 419L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 420L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 421L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 422L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 423L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 424L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 425L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 426L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 427L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 428L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 429L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 430L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 431L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 432L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 433L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 434L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 435L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 436L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 437L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 438L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 439L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 440L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 441L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 442L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 443L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 444L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 445L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 446L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 447L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 448L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 449L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 450L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 451L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 452L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 453L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 454L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 455L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 456L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 457L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 458L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 459L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 460L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 461L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 462L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 463L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 464L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 465L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 466L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 467L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 468L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 469L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 470L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 471L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 472L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 473L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 474L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 475L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 476L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 477L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 478L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 479L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 480L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 481L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 482L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 483L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 484L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 485L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 486L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 487L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 488L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 489L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 490L);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Upazila",
                keyColumn: "Id",
                keyValue: 491L);

            migrationBuilder.DropColumn(
                name: "BnName",
                schema: "core",
                table: "Upazila");

            migrationBuilder.DropColumn(
                name: "BnName",
                schema: "core",
                table: "Division");

            migrationBuilder.DropColumn(
                name: "BnName",
                schema: "core",
                table: "District");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                schema: "core",
                table: "District");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "Barguna");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "Barishal");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Name",
                value: "Bhola");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Name",
                value: "Jhalokathi");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Name",
                value: "Patuakhali");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Name",
                value: "Pirojpur");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Name",
                value: "Bandarban");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Name",
                value: "Brahmanbaria");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 9L,
                column: "Name",
                value: "Chandpur");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 10L,
                column: "Name",
                value: "Chattogram");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 11L,
                column: "Name",
                value: "Cumilla");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 12L,
                column: "Name",
                value: "Cox's Bazar");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 13L,
                column: "Name",
                value: "Feni");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 14L,
                column: "Name",
                value: "Khagrachhari");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 15L,
                column: "Name",
                value: "Lakshmipur");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 16L,
                column: "Name",
                value: "Noakhali");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 17L,
                column: "Name",
                value: "Rangamati");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 18L,
                column: "Name",
                value: "Dhaka");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 19L,
                column: "Name",
                value: "Faridpur");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 20L,
                column: "Name",
                value: "Gazipur");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 21L,
                column: "Name",
                value: "Gopalganj");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 22L,
                column: "Name",
                value: "Kishoreganj");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 23L,
                column: "Name",
                value: "Madaripur");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 24L,
                column: "Name",
                value: "Manikganj");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 25L,
                column: "Name",
                value: "Munshiganj");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 26L,
                column: "Name",
                value: "Narayanganj");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 27L,
                column: "Name",
                value: "Narsingdi");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 28L,
                column: "Name",
                value: "Rajbari");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 29L,
                column: "Name",
                value: "Shariatpur");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 30L,
                column: "Name",
                value: "Tangail");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 31L,
                column: "Name",
                value: "Bagerhat");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 32L,
                column: "Name",
                value: "Chuadanga");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 33L,
                column: "Name",
                value: "Jashore");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 34L,
                column: "Name",
                value: "Jhenaidah");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 35L,
                column: "Name",
                value: "Khulna");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 36L,
                column: "Name",
                value: "Kushtia");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 37L,
                column: "Name",
                value: "Magura");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 38L,
                column: "Name",
                value: "Meherpur");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 39L,
                column: "Name",
                value: "Narail");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 40L,
                column: "Name",
                value: "Satkhira");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 41L,
                column: "Name",
                value: "Jamalpur");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 42L,
                column: "Name",
                value: "Mymensingh");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 43L,
                column: "Name",
                value: "Netrokona");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 44L,
                column: "Name",
                value: "Sherpur");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 45L,
                column: "Name",
                value: "Bogura");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 46L,
                column: "Name",
                value: "Joypurhat");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 47L,
                column: "Name",
                value: "Naogaon");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 48L,
                column: "Name",
                value: "Natore");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 49L,
                column: "Name",
                value: "Chapainawabganj");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 50L,
                column: "Name",
                value: "Pabna");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 51L,
                column: "Name",
                value: "Rajshahi");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 52L,
                column: "Name",
                value: "Sirajganj");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 53L,
                column: "Name",
                value: "Dinajpur");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 54L,
                column: "Name",
                value: "Gaibandha");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 55L,
                column: "Name",
                value: "Kurigram");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 56L,
                column: "Name",
                value: "Lalmonirhat");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 57L,
                column: "Name",
                value: "Nilphamari");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 58L,
                column: "Name",
                value: "Panchagarh");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 60L,
                column: "Name",
                value: "Thakurgaon");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 61L,
                column: "Name",
                value: "Habiganj");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 62L,
                column: "Name",
                value: "Moulvibazar");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 63L,
                column: "Name",
                value: "Sunamganj");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "District",
                keyColumn: "Id",
                keyValue: 64L,
                column: "Name",
                value: "Sylhet");
        }
    }
}
