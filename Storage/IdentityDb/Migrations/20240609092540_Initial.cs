using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityDb.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Year = table.Column<int>(type: "int", nullable: true),
                    AmountOfPoints = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserEntityId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserEntityId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ba08ca6-f67a-4193-a58c-2f9174b5a320", null, "IdentityRole", "Reviwer", "REVIWER" },
                    { "6ec98da5-faaf-4e8f-971a-7036e011a2b2", null, "IdentityRole", "Viewer", "VIEWER" },
                    { "7ca63ccf-40c1-4dad-8566-cf655ad0276f", null, "IdentityRole", "Administrator", "ADMINISTRATOR" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", null, "IdentityRole", "Pooper", "POOPER" },
                    { "94a29c58-e3e1-4677-a2ae-7ae380198e23", null, "IdentityRole", "Maker", "MAKER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AmountOfPoints", "ConcurrencyStamp", "Description", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName", "Year" },
                values: new object[,]
                {
                    { "0334e077-1844-4f18-ab57-a853f5e03533", 0, 0, "9cf61533-7df6-4de2-a595-c95bc8478abc", "I am a pooper! Poo poo poo!!!", "AdrewRojer-1820@mail.ru", true, null, false, null, "ADREWROJER-1820@MAIL.RU", "ADREWROJER-18", "AQAAAAIAAYagAAAAENhoQvvlYy+1kTy929GnVhbL4tJRl+Awo7b7fyVGYpo2gzk8VfdccQPE8nk++IVNXw==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "d6a64c25-5e99-4fd1-a068-d2dabba1979d", false, "AdrewRojer-18", null },
                    { "0d1fc5f5-e9d5-4388-b416-5738bcc32b8e", 0, 0, "4ddd8642-7cc2-4860-abc5-0f5d84068f9a", "I am a pooper! Poo poo poo!!!", "AdrewRojer-1120@mail.ru", true, null, false, null, "ADREWROJER-1120@MAIL.RU", "ADREWROJER-11", "AQAAAAIAAYagAAAAEPAkL7inPXw56Ze4rb4t2J4S3VU5sdEn3TScUHfCjdk8ng3NVyJqdu1Q4lvtdN6dDQ==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "17801a42-96cd-4fc0-9e4b-5c64078e62f1", false, "AdrewRojer-11", null },
                    { "0fb877f6-604c-4c1c-ab43-03c97a1dd596", 0, 0, "9e7ccdb9-f580-4c4a-9fcc-ec0c6954adb5", "I am a pooper! Poo poo poo!!!", "SanchoLeaver-2920@mail.ru", true, null, false, null, "SANCHOLEAVER-2920@MAIL.RU", "SANCHOLEAVER-29", "AQAAAAIAAYagAAAAEJhkNxJ1Z1vbAARnErejn10U/2F6Qm6WkPMVSFyA9YKfWqba3L/kQYsIWCGmNm/C7g==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "008e6847-0825-43b3-b269-49249a4cd274", false, "SanchoLeaver-29", null },
                    { "1281817d-a915-4a2b-823f-54f566386052", 0, 0, "11a0a614-b907-4650-91fb-a447d1ebde21", "I am a pooper! Poo poo poo!!!", "VladBlack-720@mail.ru", true, null, false, null, "VLADBLACK-720@MAIL.RU", "VLADBLACK-7", "AQAAAAIAAYagAAAAELyuvgkj6YO0Sz5i1E3xpesVaJclahg3FwPNAdevDimWzT6/Zbm58vb4527NF9zMRA==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "37c07a7d-6362-47d9-98d6-9c0b218eb158", false, "VladBlack-7", null },
                    { "18523064-eb41-4a03-9400-70ff589137de", 0, 0, "65cecb2f-c64b-4a50-83f2-597ae50b07f9", "I am a pooper! Poo poo poo!!!", "NastyaBocharnikova-520@mail.ru", true, null, false, null, "NASTYABOCHARNIKOVA-520@MAIL.RU", "NASTYABOCHARNIKOVA-5", "AQAAAAIAAYagAAAAECd/ezvuvJcOKGSB1v3oi7g453Khl2h761dXdDIjJp4iwrKoF/d7pgZec45rMF8QoQ==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "be968591-f8d6-4d10-bc90-2928902b4e68", false, "NastyaBocharnikova-5", null },
                    { "1b5fc552-7ea9-41f8-a79d-81a41a8ddabe", 0, 0, "aadaf7f5-56b0-471b-98b1-22625f1b58fc", "I am a pooper! Poo poo poo!!!", "SanchoLeaver-2220@mail.ru", true, null, false, null, "SANCHOLEAVER-2220@MAIL.RU", "SANCHOLEAVER-22", "AQAAAAIAAYagAAAAEFem7cIVlfAYOHj1Iao9kmXFEl3FB+GiysFP10oD3NLHmOfBF9x91xd9m2PjPWycKQ==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "11076068-39d6-4733-87ac-8375d1f969e6", false, "SanchoLeaver-22", null },
                    { "29050854-c148-46a5-99ae-0a105386ea01", 0, 0, "b92acf12-a355-4fbb-86b9-9b28a392c819", "I am a pooper! Poo poo poo!!!", "VladBlack-2620@mail.ru", true, null, false, null, "VLADBLACK-2620@MAIL.RU", "VLADBLACK-26", "AQAAAAIAAYagAAAAEEo4FFBFCb1trSJirZqg5Q4D3iOa3/DH1G7E12fu0lJUdQFqk1LD4lpdOHecsnlTMQ==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "6647e04c-d0ba-483f-83c4-c570c2da9864", false, "VladBlack-26", null },
                    { "2acde688-494b-4956-9182-5d1fed4dfaf3", 0, 0, "5c74f3e4-c067-4903-bf0f-e3b1a22c4978", "I am the admin! Call me the Boss!!!", "VladBalkar20@mail.ru", true, null, false, null, "VLADBALKAR20@MAIL.RU", "VLADBALKAR", "AQAAAAIAAYagAAAAEFuXKaUPapHDjgot+lJ3lgl0z1hs1oz3RppADP/5TEh2GbkJlyWp5aepKpNMd3zh2Q==", "", true, "7ca63ccf-40c1-4dad-8566-cf655ad0276f", "81c2f5eb-8a6f-412e-9acb-1f6a96420eaf", false, "VladBalkar", null },
                    { "3e43fb1f-0f56-4495-8d4c-25e2afe44b53", 0, 0, "7ee35819-fb1b-4e44-8d85-b6b7fa628586", "I am a pooper! Poo poo poo!!!", "GregorPiha-620@mail.ru", true, null, false, null, "GREGORPIHA-620@MAIL.RU", "GREGORPIHA-6", "AQAAAAIAAYagAAAAEMZ7hVw0K91UvDqmlk4M3WrY1ULsKadwp0RIomgcd76PF+DFCFt9/2YrNegeR5sO9g==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "e3398ca4-0a98-41b2-85c6-253cf3fd59ae", false, "GregorPiha-6", null },
                    { "3ed8231c-9dca-4371-b091-a40ab198492d", 0, 0, "2b712b3b-039a-4b56-b8cb-d14e608ac3ed", "I am a pooper! Poo poo poo!!!", "SanchoLeaver-920@mail.ru", true, null, false, null, "SANCHOLEAVER-920@MAIL.RU", "SANCHOLEAVER-9", "AQAAAAIAAYagAAAAEBw/6bthp2KQha6LHruPkUmqpbTP9sOI2vckZMTJdJnGXzc37TfHcOZdFJRy3zudqw==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "08882391-880b-473e-91ae-1a5737cde76f", false, "SanchoLeaver-9", null },
                    { "40677c08-c27d-45ee-8c11-2887d7bc13b7", 0, 0, "55d5d266-d4c8-4978-8ee2-9d8ce34e6f4e", "I am a pooper! Poo poo poo!!!", "NastyaBocharnikova-420@mail.ru", true, null, false, null, "NASTYABOCHARNIKOVA-420@MAIL.RU", "NASTYABOCHARNIKOVA-4", "AQAAAAIAAYagAAAAEAeqgM75UI1ncUgP7A0RkIQlAT2psLr+d1JQqJLQPjJOVhOqYSW6eiDlwomriSCL0g==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "791c3f03-9363-48ef-8819-80c59d784650", false, "NastyaBocharnikova-4", null },
                    { "46d2ec69-1b80-4268-816d-91a9cd5c6d45", 0, 0, "63a068f4-1bba-4256-964e-46961459a931", "I am a pooper! Poo poo poo!!!", "VladBlack-1320@mail.ru", true, null, false, null, "VLADBLACK-1320@MAIL.RU", "VLADBLACK-13", "AQAAAAIAAYagAAAAEIhtbZmj057Q0IspHOZv+tWrT+SdFW5yXXi6AiEfELlwj85GUHhBPWXJUJizZbC9yA==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "93fa638f-ec88-4d3b-878b-3e87da01caa8", false, "VladBlack-13", null },
                    { "497879a0-53c2-4d2a-8dcb-85cd97feda70", 0, 0, "9d882081-0183-49f4-b6eb-96ad593dee43", "I am a pooper! Poo poo poo!!!", "AdrewRojer-2020@mail.ru", true, null, false, null, "ADREWROJER-2020@MAIL.RU", "ADREWROJER-20", "AQAAAAIAAYagAAAAENYSLQYW4PjNfLNWJxd25OBqrN/fKlEXtA+VdgkrI34XVZDcnG/Chx77T7ON0vMfiQ==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "aa0496d6-f877-4da4-89af-d77b7f5da359", false, "AdrewRojer-20", null },
                    { "504c7528-d470-43e1-ae41-a2490c4bee68", 0, 0, "7f14b07f-b8b0-474b-9d54-424534e5eea6", "I am a pooper! Poo poo poo!!!", "AdrewRojer-2420@mail.ru", true, null, false, null, "ADREWROJER-2420@MAIL.RU", "ADREWROJER-24", "AQAAAAIAAYagAAAAEPE0o63ViUdUhEGQLFGyULD/E2MDy4RBz2Ju+rtjAriDh2jjnuhQF/COVKBbMzSgUA==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "c343289b-96e5-4d0d-8e55-e47eaad68363", false, "AdrewRojer-24", null },
                    { "603ba261-67a4-4531-a01f-5b511f01ea87", 0, 0, "7a945f89-4c02-4719-bb52-5fbb7f47cbcc", "I am a pooper! Poo poo poo!!!", "NastyaKareva-2320@mail.ru", true, null, false, null, "NASTYAKAREVA-2320@MAIL.RU", "NASTYAKAREVA-23", "AQAAAAIAAYagAAAAEGc93aeIPIAq2gf87JyIAAixbr8s6w3FugHhSxphKGtTs1kwPnzVuGvU8fZXrC6hag==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "5cc1e42f-e54b-4f0e-a0fe-902352707eb1", false, "NastyaKareva-23", null },
                    { "63ad0649-553f-4056-9706-45469314585b", 0, 0, "d493ab85-3293-46c1-a028-bda4b34ce62f", "I am a pooper! Poo poo poo!!!", "NastyaBocharnikova-1720@mail.ru", true, null, false, null, "NASTYABOCHARNIKOVA-1720@MAIL.RU", "NASTYABOCHARNIKOVA-17", "AQAAAAIAAYagAAAAEEuxrVHFexwNUmxgP3LAHPwlss94tqkx98foC3mr2RpAAk9MyTL9uudpeEsE7AxNKQ==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "690fedfd-f5d2-4236-8068-79445dd955ff", false, "NastyaBocharnikova-17", null },
                    { "696d4813-0633-4d12-b9c2-d18c013c66ff", 0, 0, "1863d7f6-88d2-47d7-aec4-8ef8e9adbd32", "I am a pooper! Poo poo poo!!!", "NastyaBocharnikova-020@mail.ru", true, null, false, null, "NASTYABOCHARNIKOVA-020@MAIL.RU", "NASTYABOCHARNIKOVA-0", "AQAAAAIAAYagAAAAEIvIoI4x15GZ8vTBji0CoVcKHrslfHzOIp57PbZRbyAn46aoj+N5KwDVnkFPPmyqZQ==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "397921cf-9d3c-4aa6-abb8-ff2f216118a3", false, "NastyaBocharnikova-0", null },
                    { "7232a042-1047-42fd-96ba-c72aed57e2ae", 0, 0, "093a374e-26ef-4834-8224-80c08fa1dd73", "I am a pooper! Poo poo poo!!!", "NastyaKareva-320@mail.ru", true, null, false, null, "NASTYAKAREVA-320@MAIL.RU", "NASTYAKAREVA-3", "AQAAAAIAAYagAAAAEHVmbp7zOTFCuRTcmKTswrC77ixLt0MCDyIbnhubzpvvu9HAba+bDHKkkvBriPuwWQ==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "ef368dba-be4d-4a4c-a011-d2ae0bb7948f", false, "NastyaKareva-3", null },
                    { "7c834c1a-63c2-49d6-8950-16b112a99a88", 0, 0, "630a69df-3a46-4f51-b555-1ac6bb49a2a7", "I am a pooper! Poo poo poo!!!", "VladBlack-2520@mail.ru", true, null, false, null, "VLADBLACK-2520@MAIL.RU", "VLADBLACK-25", "AQAAAAIAAYagAAAAEJdaTNPil6DjlXfnX3pjbIIdZC52YpeeK8pH1nkojatJCkr0Q6JIyWRUxulqIdVBEg==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "b30ded24-54c4-4c17-912d-88027d691d63", false, "VladBlack-25", null },
                    { "7dd506f9-90d1-442f-bc9b-9c38fef8a2b6", 0, 0, "f964d5d5-e00d-4f7e-9472-bc7b51e7b32e", "I am a pooper! Poo poo poo!!!", "SanchoLeaver-120@mail.ru", true, null, false, null, "SANCHOLEAVER-120@MAIL.RU", "SANCHOLEAVER-1", "AQAAAAIAAYagAAAAEJ5bt8m2maoCL7Win3VbRctC3Tj255MiBUNSdILGspt7NSFn8OVk1uxV+15WMUJM4A==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "2256e0f7-bbea-46c5-a6f3-a9d2a21565a4", false, "SanchoLeaver-1", null },
                    { "83e22dfe-e470-44aa-9502-6925be3633f2", 0, 0, "c318e59e-5a51-40bf-b364-a3e9ca95a8f3", "I am a pooper! Poo poo poo!!!", "NastyaBocharnikova-820@mail.ru", true, null, false, null, "NASTYABOCHARNIKOVA-820@MAIL.RU", "NASTYABOCHARNIKOVA-8", "AQAAAAIAAYagAAAAEFuxenj2WiKBfoBvkyqo6xFWc/COjptwB44hYX+UnHaMGh50r16qCNbVNScbb9ZRtg==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "5a856ad0-06ee-4dbd-9736-cdd4f876ed75", false, "NastyaBocharnikova-8", null },
                    { "91af8243-3c52-4469-95de-8c204f6d2587", 0, 0, "77584270-4969-4333-809b-47416565ee33", "I am a pooper! Poo poo poo!!!", "NastyaKareva-2820@mail.ru", true, null, false, null, "NASTYAKAREVA-2820@MAIL.RU", "NASTYAKAREVA-28", "AQAAAAIAAYagAAAAEJORdXqLUV2HU/e5bFc4sWAmTW4BAk01TMXBDA7f8ar39ECoQoR64IUhk0B9tIRzvg==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "ababb8c5-0e9e-4795-86a3-12c880a24964", false, "NastyaKareva-28", null },
                    { "922646cd-85e6-4a66-ad60-b8ca7f529c95", 0, 0, "75e0a619-afb4-4cff-ac54-6bf6297080e0", "I am a pooper! Poo poo poo!!!", "NastyaKareva-1620@mail.ru", true, null, false, null, "NASTYAKAREVA-1620@MAIL.RU", "NASTYAKAREVA-16", "AQAAAAIAAYagAAAAELq6U5Rzr7GZH3Qfkm/te3XFMUKrL23NGITY2rfwgz2hxBziR4WRLgsY+ooL7QWmkA==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "bd7f435a-3960-49a5-88f9-1ae75b7f119b", false, "NastyaKareva-16", null },
                    { "af1133a3-3442-4fa3-8803-38676761dae2", 0, 0, "db3ca98e-ea53-4277-9b3a-6e83bed7c385", "I am a pooper! Poo poo poo!!!", "NastyaBocharnikova-1520@mail.ru", true, null, false, null, "NASTYABOCHARNIKOVA-1520@MAIL.RU", "NASTYABOCHARNIKOVA-15", "AQAAAAIAAYagAAAAEJU0hIEslUI9TYbRMJLUSjf+AhAxWsOZz+IVshUB6OI9BNvqvzhLfIlrlDQKz6Opyg==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "492dbccd-1ceb-4942-8218-788b510d9de5", false, "NastyaBocharnikova-15", null },
                    { "b2867a00-80e0-4e01-91ee-e62a4c4fd57f", 0, 0, "52e3baf6-824a-4869-85c5-259c06208b3a", "I am a pooper! Poo poo poo!!!", "NastyaKareva-2120@mail.ru", true, null, false, null, "NASTYAKAREVA-2120@MAIL.RU", "NASTYAKAREVA-21", "AQAAAAIAAYagAAAAEH+QofXyg2YsxfzyvneBnICNk8eKAPElbcqcgWl/fz/RhuvIkvmZE7S2iTUOPsC6kQ==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "dd2423f5-de83-48af-9535-78671de920cb", false, "NastyaKareva-21", null },
                    { "bdc4cbd4-6592-4700-b731-15d28f998f7d", 0, 0, "b5651476-7cb2-4d65-87fd-17baae56cebc", "I am a pooper! Poo poo poo!!!", "NastyaBocharnikova-220@mail.ru", true, null, false, null, "NASTYABOCHARNIKOVA-220@MAIL.RU", "NASTYABOCHARNIKOVA-2", "AQAAAAIAAYagAAAAEBEH/hqM3PtSAjdh6250S/9ZpRp9rAOXdf3tndJA9m/Luhe5/ujMg+VB18+l1KbSuw==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "3700f1ed-c011-462f-8976-9efabb01fd58", false, "NastyaBocharnikova-2", null },
                    { "beec5833-451a-4368-9ea9-a97c39abd83c", 0, 0, "367aa953-f9be-49c1-99f6-b12362849da5", "I am a pooper! Poo poo poo!!!", "NastyaKareva-1020@mail.ru", true, null, false, null, "NASTYAKAREVA-1020@MAIL.RU", "NASTYAKAREVA-10", "AQAAAAIAAYagAAAAEDjMkTyTP5KudIQCrPuOmj4i8yJPBkuUK6icX5uQPcFu4OrzQKTOMKaaH5HVqEqBSg==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "329fe26b-cf66-4b97-8464-279f9b281d21", false, "NastyaKareva-10", null },
                    { "cf90959d-9b41-4096-9043-6916e6020132", 0, 0, "2c9e9da5-d42d-49f9-87fe-7c910839c592", "I am a pooper! Poo poo poo!!!", "AdrewRojer-1920@mail.ru", true, null, false, null, "ADREWROJER-1920@MAIL.RU", "ADREWROJER-19", "AQAAAAIAAYagAAAAEF+gdbHsEa2sCsEiFx++c4U60O6YQ42Ykkjth/m7h1FhRNqQrdQCT84yg9y/WP0Akg==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "b6455faf-4002-490f-8d37-cc70dd72d770", false, "AdrewRojer-19", null },
                    { "d7814207-b301-4088-9d15-3020554c46b5", 0, 0, "d4bf48f6-fbd5-460d-8f5f-780825e549f8", "I am a pooper! Poo poo poo!!!", "GregorPiha-2720@mail.ru", true, null, false, null, "GREGORPIHA-2720@MAIL.RU", "GREGORPIHA-27", "AQAAAAIAAYagAAAAEOdl2elNkcNVXQuc89E0hKuGwIR/bOU/YulxdK1n/hJoCVaNmC3dRsSAg+uy2QEpSQ==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "db70bec7-c943-4822-871a-58b326e5acf4", false, "GregorPiha-27", null },
                    { "e03b40ff-5aaa-4e14-965e-13ff111dba28", 0, 0, "e2562827-9107-46a1-b103-9d9d268101bd", "I am a pooper! Poo poo poo!!!", "GregorPiha-1220@mail.ru", true, null, false, null, "GREGORPIHA-1220@MAIL.RU", "GREGORPIHA-12", "AQAAAAIAAYagAAAAEK/hNdP8yFlCVnYK6Y9yqoox7t5VsiWtHT1Goyh/+NtDYXmZ/yfiPhTBeM32zl1kqg==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "d8de1500-aa74-43e7-95f0-637cac51b375", false, "GregorPiha-12", null },
                    { "ffb887aa-9a30-4546-96b7-e1ee88ca531b", 0, 0, "cd3f15f6-baa6-465d-95c0-c2bd26f0fafd", "I am a pooper! Poo poo poo!!!", "NastyaKareva-1420@mail.ru", true, null, false, null, "NASTYAKAREVA-1420@MAIL.RU", "NASTYAKAREVA-14", "AQAAAAIAAYagAAAAEFWaaiY0/GGYnqskQYCKGhjSHl1upcVewbDIc0bUanFTr+FaOgQVpOl+NpCE/ILjwQ==", "", true, "891f612b-164b-4c9c-b8a9-d76f59ad5389", "0cf39dfe-90d0-42fd-a897-ab56cfaa874e", false, "NastyaKareva-14", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 28280268, "SharerClaim", "Front", "1281817d-a915-4a2b-823f-54f566386052" },
                    { 36686087, "SharerClaim", "Stinky", "cf90959d-9b41-4096-9043-6916e6020132" },
                    { 48428737, "SharerClaim", "Lol", "504c7528-d470-43e1-ae41-a2490c4bee68" },
                    { 54145799, "SharerClaim", "Front", "91af8243-3c52-4469-95de-8c204f6d2587" },
                    { 73342606, "SharerClaim", "Back", "63ad0649-553f-4056-9706-45469314585b" },
                    { 103478178, "SharerClaim", "Back", "696d4813-0633-4d12-b9c2-d18c013c66ff" },
                    { 136726156, "SharerClaim", "Back", "83e22dfe-e470-44aa-9502-6925be3633f2" },
                    { 140589574, "SharerClaim", "Dev", "7dd506f9-90d1-442f-bc9b-9c38fef8a2b6" },
                    { 157667743, "SharerClaim", "Dba", "ffb887aa-9a30-4546-96b7-e1ee88ca531b" },
                    { 190173174, "SharerClaim", "Lead", "af1133a3-3442-4fa3-8803-38676761dae2" },
                    { 216984146, "SharerClaim", "Dev", "7232a042-1047-42fd-96ba-c72aed57e2ae" },
                    { 233677579, "SharerClaim", "Stinky", "504c7528-d470-43e1-ae41-a2490c4bee68" },
                    { 235441390, "SharerClaim", "Dev", "922646cd-85e6-4a66-ad60-b8ca7f529c95" },
                    { 236843860, "SharerClaim", "Dba", "7c834c1a-63c2-49d6-8950-16b112a99a88" },
                    { 263368951, "SharerClaim", "Lol", "0334e077-1844-4f18-ab57-a853f5e03533" },
                    { 435195674, "SharerClaim", "Dba", "0d1fc5f5-e9d5-4388-b416-5738bcc32b8e" },
                    { 443021833, "SharerClaim", "Lol", "40677c08-c27d-45ee-8c11-2887d7bc13b7" },
                    { 447914785, "SharerClaim", "Lead", "504c7528-d470-43e1-ae41-a2490c4bee68" },
                    { 474645019, "SharerClaim", "Lol", "e03b40ff-5aaa-4e14-965e-13ff111dba28" },
                    { 492421820, "SharerClaim", "Stinky", "b2867a00-80e0-4e01-91ee-e62a4c4fd57f" },
                    { 503428532, "SharerClaim", "Back", "bdc4cbd4-6592-4700-b731-15d28f998f7d" },
                    { 508393440, "SharerClaim", "Dba", "1281817d-a915-4a2b-823f-54f566386052" },
                    { 524400016, "SharerClaim", "Stinky", "922646cd-85e6-4a66-ad60-b8ca7f529c95" },
                    { 582404597, "SharerClaim", "Lead", "7dd506f9-90d1-442f-bc9b-9c38fef8a2b6" },
                    { 603739166, "SharerClaim", "Dev", "63ad0649-553f-4056-9706-45469314585b" },
                    { 624838868, "SharerClaim", "Dba", "cf90959d-9b41-4096-9043-6916e6020132" },
                    { 669358589, "SharerClaim", "Dba", "7dd506f9-90d1-442f-bc9b-9c38fef8a2b6" },
                    { 684380882, "SharerClaim", "Dev", "1281817d-a915-4a2b-823f-54f566386052" },
                    { 695260558, "SharerClaim", "Lol", "0d1fc5f5-e9d5-4388-b416-5738bcc32b8e" },
                    { 726836865, "SharerClaim", "Lol", "7c834c1a-63c2-49d6-8950-16b112a99a88" },
                    { 753208947, "SharerClaim", "Front", "e03b40ff-5aaa-4e14-965e-13ff111dba28" },
                    { 786499965, "SharerClaim", "Dba", "40677c08-c27d-45ee-8c11-2887d7bc13b7" },
                    { 790956864, "SharerClaim", "Dev", "ffb887aa-9a30-4546-96b7-e1ee88ca531b" },
                    { 791501061, "SharerClaim", "Back", "1281817d-a915-4a2b-823f-54f566386052" },
                    { 796010034, "SharerClaim", "Front", "7c834c1a-63c2-49d6-8950-16b112a99a88" },
                    { 819325692, "SharerClaim", "Lol", "603ba261-67a4-4531-a01f-5b511f01ea87" },
                    { 832144667, "SharerClaim", "Stinky", "46d2ec69-1b80-4268-816d-91a9cd5c6d45" },
                    { 851572518, "SharerClaim", "Lead", "bdc4cbd4-6592-4700-b731-15d28f998f7d" },
                    { 884436642, "SharerClaim", "Front", "7232a042-1047-42fd-96ba-c72aed57e2ae" },
                    { 897621355, "SharerClaim", "Front", "603ba261-67a4-4531-a01f-5b511f01ea87" },
                    { 906022073, "SharerClaim", "Stinky", "63ad0649-553f-4056-9706-45469314585b" },
                    { 924376833, "SharerClaim", "Stinky", "83e22dfe-e470-44aa-9502-6925be3633f2" },
                    { 953299337, "SharerClaim", "Lead", "0334e077-1844-4f18-ab57-a853f5e03533" },
                    { 985042060, "SharerClaim", "Dba", "0fb877f6-604c-4c1c-ab43-03c97a1dd596" },
                    { 1005861021, "SharerClaim", "Lol", "83e22dfe-e470-44aa-9502-6925be3633f2" },
                    { 1022844598, "SharerClaim", "Lol", "63ad0649-553f-4056-9706-45469314585b" },
                    { 1072259701, "SharerClaim", "Lead", "0fb877f6-604c-4c1c-ab43-03c97a1dd596" },
                    { 1105441914, "SharerClaim", "Lol", "0fb877f6-604c-4c1c-ab43-03c97a1dd596" },
                    { 1120622573, "SharerClaim", "Lol", "cf90959d-9b41-4096-9043-6916e6020132" },
                    { 1137717189, "SharerClaim", "Back", "0d1fc5f5-e9d5-4388-b416-5738bcc32b8e" },
                    { 1142017555, "SharerClaim", "Lead", "3e43fb1f-0f56-4495-8d4c-25e2afe44b53" },
                    { 1187437816, "BossClaim", "BossClaim", "2acde688-494b-4956-9182-5d1fed4dfaf3" },
                    { 1191604108, "SharerClaim", "Back", "603ba261-67a4-4531-a01f-5b511f01ea87" },
                    { 1196765189, "SharerClaim", "Back", "922646cd-85e6-4a66-ad60-b8ca7f529c95" },
                    { 1241752126, "SharerClaim", "Stinky", "ffb887aa-9a30-4546-96b7-e1ee88ca531b" },
                    { 1254691601, "SharerClaim", "Dba", "beec5833-451a-4368-9ea9-a97c39abd83c" },
                    { 1270070260, "SharerClaim", "Back", "ffb887aa-9a30-4546-96b7-e1ee88ca531b" },
                    { 1297880112, "SharerClaim", "Back", "0fb877f6-604c-4c1c-ab43-03c97a1dd596" },
                    { 1313409634, "SharerClaim", "Front", "18523064-eb41-4a03-9400-70ff589137de" },
                    { 1324986701, "SharerClaim", "Back", "7dd506f9-90d1-442f-bc9b-9c38fef8a2b6" },
                    { 1335075547, "SharerClaim", "Stinky", "d7814207-b301-4088-9d15-3020554c46b5" },
                    { 1360857629, "SharerClaim", "Lol", "922646cd-85e6-4a66-ad60-b8ca7f529c95" },
                    { 1363474163, "SharerClaim", "Back", "29050854-c148-46a5-99ae-0a105386ea01" },
                    { 1367896135, "SharerClaim", "Dba", "922646cd-85e6-4a66-ad60-b8ca7f529c95" },
                    { 1371681697, "SharerClaim", "Dba", "63ad0649-553f-4056-9706-45469314585b" },
                    { 1432732510, "SharerClaim", "Back", "d7814207-b301-4088-9d15-3020554c46b5" },
                    { 1455843256, "SharerClaim", "Dev", "0334e077-1844-4f18-ab57-a853f5e03533" },
                    { 1456073085, "SharerClaim", "Dev", "0d1fc5f5-e9d5-4388-b416-5738bcc32b8e" },
                    { 1493193349, "SharerClaim", "Dev", "beec5833-451a-4368-9ea9-a97c39abd83c" },
                    { 1525646343, "SharerClaim", "Dev", "497879a0-53c2-4d2a-8dcb-85cd97feda70" },
                    { 1526090571, "SharerClaim", "Stinky", "7c834c1a-63c2-49d6-8950-16b112a99a88" },
                    { 1529357621, "SharerClaim", "Front", "497879a0-53c2-4d2a-8dcb-85cd97feda70" },
                    { 1547917724, "SharerClaim", "Front", "46d2ec69-1b80-4268-816d-91a9cd5c6d45" },
                    { 1557487273, "SharerClaim", "Lol", "ffb887aa-9a30-4546-96b7-e1ee88ca531b" },
                    { 1558509429, "SharerClaim", "Front", "d7814207-b301-4088-9d15-3020554c46b5" },
                    { 1565671680, "SharerClaim", "Back", "beec5833-451a-4368-9ea9-a97c39abd83c" },
                    { 1570932909, "SharerClaim", "Lol", "af1133a3-3442-4fa3-8803-38676761dae2" },
                    { 1594042342, "SharerClaim", "Front", "696d4813-0633-4d12-b9c2-d18c013c66ff" },
                    { 1597596680, "SharerClaim", "Lead", "1b5fc552-7ea9-41f8-a79d-81a41a8ddabe" },
                    { 1655760898, "SharerClaim", "Front", "504c7528-d470-43e1-ae41-a2490c4bee68" },
                    { 1667988718, "SharerClaim", "Lead", "ffb887aa-9a30-4546-96b7-e1ee88ca531b" },
                    { 1669245676, "SharerClaim", "Lol", "d7814207-b301-4088-9d15-3020554c46b5" },
                    { 1709967383, "SharerClaim", "Stinky", "bdc4cbd4-6592-4700-b731-15d28f998f7d" },
                    { 1745679526, "SharerClaim", "Lead", "beec5833-451a-4368-9ea9-a97c39abd83c" },
                    { 1748867176, "SharerClaim", "Lead", "29050854-c148-46a5-99ae-0a105386ea01" },
                    { 1779907796, "SharerClaim", "Dba", "af1133a3-3442-4fa3-8803-38676761dae2" },
                    { 1797463786, "SharerClaim", "Front", "3ed8231c-9dca-4371-b091-a40ab198492d" },
                    { 1798489050, "SharerClaim", "Lead", "7c834c1a-63c2-49d6-8950-16b112a99a88" },
                    { 1810752983, "SharerClaim", "Dba", "0334e077-1844-4f18-ab57-a853f5e03533" },
                    { 1811878617, "SharerClaim", "Lead", "91af8243-3c52-4469-95de-8c204f6d2587" },
                    { 1823615461, "SharerClaim", "Dba", "696d4813-0633-4d12-b9c2-d18c013c66ff" },
                    { 1850413661, "SharerClaim", "Dba", "504c7528-d470-43e1-ae41-a2490c4bee68" },
                    { 1851930881, "SharerClaim", "Front", "0334e077-1844-4f18-ab57-a853f5e03533" },
                    { 1857690244, "SharerClaim", "Lead", "63ad0649-553f-4056-9706-45469314585b" },
                    { 1900669603, "SharerClaim", "Lol", "beec5833-451a-4368-9ea9-a97c39abd83c" },
                    { 1929172809, "SharerClaim", "Dba", "e03b40ff-5aaa-4e14-965e-13ff111dba28" },
                    { 1955055517, "SharerClaim", "Back", "7c834c1a-63c2-49d6-8950-16b112a99a88" },
                    { 1979850641, "SharerClaim", "Dev", "0fb877f6-604c-4c1c-ab43-03c97a1dd596" },
                    { 1982031131, "SharerClaim", "Lead", "18523064-eb41-4a03-9400-70ff589137de" },
                    { 1983575816, "SharerClaim", "Lead", "1281817d-a915-4a2b-823f-54f566386052" },
                    { 1988306730, "SharerClaim", "Back", "504c7528-d470-43e1-ae41-a2490c4bee68" },
                    { 2008160269, "SharerClaim", "Back", "40677c08-c27d-45ee-8c11-2887d7bc13b7" },
                    { 2061595474, "SharerClaim", "Lol", "29050854-c148-46a5-99ae-0a105386ea01" },
                    { 2080081263, "SharerClaim", "Lol", "1281817d-a915-4a2b-823f-54f566386052" },
                    { 2086782098, "SharerClaim", "Lead", "497879a0-53c2-4d2a-8dcb-85cd97feda70" },
                    { 2093930736, "SharerClaim", "Front", "beec5833-451a-4368-9ea9-a97c39abd83c" },
                    { 2128971394, "SharerClaim", "Stinky", "0334e077-1844-4f18-ab57-a853f5e03533" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "0334e077-1844-4f18-ab57-a853f5e03533" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "0d1fc5f5-e9d5-4388-b416-5738bcc32b8e" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "0fb877f6-604c-4c1c-ab43-03c97a1dd596" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "1281817d-a915-4a2b-823f-54f566386052" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "18523064-eb41-4a03-9400-70ff589137de" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "1b5fc552-7ea9-41f8-a79d-81a41a8ddabe" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "29050854-c148-46a5-99ae-0a105386ea01" },
                    { "7ca63ccf-40c1-4dad-8566-cf655ad0276f", "2acde688-494b-4956-9182-5d1fed4dfaf3" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "3e43fb1f-0f56-4495-8d4c-25e2afe44b53" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "3ed8231c-9dca-4371-b091-a40ab198492d" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "40677c08-c27d-45ee-8c11-2887d7bc13b7" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "46d2ec69-1b80-4268-816d-91a9cd5c6d45" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "497879a0-53c2-4d2a-8dcb-85cd97feda70" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "504c7528-d470-43e1-ae41-a2490c4bee68" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "603ba261-67a4-4531-a01f-5b511f01ea87" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "63ad0649-553f-4056-9706-45469314585b" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "696d4813-0633-4d12-b9c2-d18c013c66ff" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "7232a042-1047-42fd-96ba-c72aed57e2ae" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "7c834c1a-63c2-49d6-8950-16b112a99a88" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "7dd506f9-90d1-442f-bc9b-9c38fef8a2b6" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "83e22dfe-e470-44aa-9502-6925be3633f2" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "91af8243-3c52-4469-95de-8c204f6d2587" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "922646cd-85e6-4a66-ad60-b8ca7f529c95" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "af1133a3-3442-4fa3-8803-38676761dae2" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "b2867a00-80e0-4e01-91ee-e62a4c4fd57f" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "bdc4cbd4-6592-4700-b731-15d28f998f7d" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "beec5833-451a-4368-9ea9-a97c39abd83c" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "cf90959d-9b41-4096-9043-6916e6020132" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "d7814207-b301-4088-9d15-3020554c46b5" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "e03b40ff-5aaa-4e14-965e-13ff111dba28" },
                    { "891f612b-164b-4c9c-b8a9-d76f59ad5389", "ffb887aa-9a30-4546-96b7-e1ee88ca531b" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserEntityId",
                table: "AspNetUserLogins",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserTokens_UserEntityId",
                table: "AspNetUserTokens",
                column: "UserEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
