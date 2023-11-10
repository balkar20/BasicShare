using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: true),
                    AmountOfPoints = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    UserEntityId = table.Column<string>(type: "text", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    UserEntityId = table.Column<string>(type: "text", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "Poopers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    AmountOfPoops = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    UserEntityId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poopers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poopers_AspNetUsers_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", null, "IdentityRole", "Pooper", "POOPER" },
                    { "45775a85-8a62-48d0-a79a-d396f82cc551", null, "IdentityRole", "Viewer", "VIEWER" },
                    { "69b07d0b-8b37-43c8-91de-7a487def5118", null, "IdentityRole", "Maker", "MAKER" },
                    { "a96bf07e-3a0f-4599-985e-5040d3e0c974", null, "IdentityRole", "Reviwer", "REVIWER" },
                    { "ede0e41a-7e0c-4eb8-aaba-85bb2872dd63", null, "IdentityRole", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AmountOfPoints", "ConcurrencyStamp", "Description", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName", "Year" },
                values: new object[,]
                {
                    { "0c1df73d-271f-4785-9a9a-ce8534d96dc1", 0, 0, "7bc574dd-9b97-4014-a370-4e8d10306640", "I am a pooper! Poo poo poo!!!", "VladBlack-2120@mail.ru", true, null, false, null, "VLADBLACK-2120@MAIL.RU", "VLADBLACK-21", "AQAAAAIAAYagAAAAEMp4NbJ5SE0mkKfqAhediyfwaH47LFzKAHwHf4Wm9TnztAMzoWGa0ws6lsGowqFWug==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "1bef70bc-e5c1-4666-b158-66ea808e8e3a", false, "VladBlack-21", null },
                    { "0f71294b-6eed-4555-a993-17ec66922612", 0, 0, "b7c78510-4a68-4492-8231-7150349be61d", "I am a pooper! Poo poo poo!!!", "SanchoLeaver-1020@mail.ru", true, null, false, null, "SANCHOLEAVER-1020@MAIL.RU", "SANCHOLEAVER-10", "AQAAAAIAAYagAAAAEGeSj+DB0wGc3AO+HfgIs4HbxJA5mK/ta4uJ67naTE4y+vbRfJ+u2gLolPTD72FlsQ==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "98b2bc09-cccf-4702-96e7-7877bff5642b", false, "SanchoLeaver-10", null },
                    { "14ac3876-cdfe-421e-87f5-7e25049290a7", 0, 0, "8ceec6f2-c53e-41d0-8d26-487d201cbf49", "I am a pooper! Poo poo poo!!!", "GregorPiha-520@mail.ru", true, null, false, null, "GREGORPIHA-520@MAIL.RU", "GREGORPIHA-5", "AQAAAAIAAYagAAAAEBqGnNrfLtJoezWEWgbs0mET7rRESUlD4v075ahphpfPAYj028AlqB2AHAOTOtWKnQ==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "eefb0c4a-385f-4fb0-81ba-457c8c6c1144", false, "GregorPiha-5", null },
                    { "17904617-974d-42ec-acb7-8bbf97fc0b93", 0, 0, "68a5dfbc-c9c3-4e8c-b66b-9bfe31e4e0f5", "I am a pooper! Poo poo poo!!!", "SanchoLeaver-2920@mail.ru", true, null, false, null, "SANCHOLEAVER-2920@MAIL.RU", "SANCHOLEAVER-29", "AQAAAAIAAYagAAAAEHFVuUmO9BFwwEUcNWiVxzmrDnfa5Z3yID31ZYbcE2odm8aOe9Lh5UWNZp/vW02ZAw==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "ce70e521-b371-4a2c-8d5a-258449f093e2", false, "SanchoLeaver-29", null },
                    { "31213f3b-9ff2-46ab-a055-c1b10c0ab680", 0, 0, "bbdaea35-7da8-4dbc-9bee-db282743f3e5", "I am a pooper! Poo poo poo!!!", "GregorPiha-2520@mail.ru", true, null, false, null, "GREGORPIHA-2520@MAIL.RU", "GREGORPIHA-25", "AQAAAAIAAYagAAAAEKJIy96vZZm+47M5ym8o+O5BSdCK8/VBhRaaYJum6572m/9aqMh7zaFgBvmg+hLH4Q==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "f7c90aae-5cef-4de2-a11d-d94a5bb984c7", false, "GregorPiha-25", null },
                    { "4067d998-9b4f-4941-97c4-7cc3984731fe", 0, 0, "66df3360-1ea4-4821-a72b-a5c222e41a82", "I am a pooper! Poo poo poo!!!", "AdrewRojer-1720@mail.ru", true, null, false, null, "ADREWROJER-1720@MAIL.RU", "ADREWROJER-17", "AQAAAAIAAYagAAAAEJVq2RzwtNk+r+2JMLCJpSBxupPm0WgmcK8ElaAb3gke2pomuGx/pvWNhhylUOIyHA==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "330b26ff-8526-497e-b660-bea45206f1e5", false, "AdrewRojer-17", null },
                    { "52ab31cf-0a12-46e8-8e76-dceb4e314ed8", 0, 0, "ca982971-cddc-46e7-8f49-0e5d0ab0ba79", "I am a pooper! Poo poo poo!!!", "AdrewRojer-1520@mail.ru", true, null, false, null, "ADREWROJER-1520@MAIL.RU", "ADREWROJER-15", "AQAAAAIAAYagAAAAEPV5vK2woMpz2DOcK2rDeRrfI7EXc1KfgPl2bAfprbGvxjniqs2h9ko96h0wJqBk/g==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "ee06167c-d728-408d-ac8d-298147d5350c", false, "AdrewRojer-15", null },
                    { "5b5fd5c5-f70d-4eb7-97bb-7012f5239636", 0, 0, "c632c02a-400f-4878-bd8a-c5e15a3c14f5", "I am a pooper! Poo poo poo!!!", "NastyaKareva-320@mail.ru", true, null, false, null, "NASTYAKAREVA-320@MAIL.RU", "NASTYAKAREVA-3", "AQAAAAIAAYagAAAAEDoOMdyQifwZ+wvF6/XH/E2XfsBzeCidhEIZTD6iVy8LKCgE05rNpJe/PkUmp95VXw==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "a4d9e2c0-6d41-4590-a5ad-ec5227c464cb", false, "NastyaKareva-3", null },
                    { "5e4676c9-5751-46a8-9194-1d5411648228", 0, 0, "042e02f3-2047-465f-ab6d-66207c1979c5", "I am a pooper! Poo poo poo!!!", "NastyaBocharnikova-1420@mail.ru", true, null, false, null, "NASTYABOCHARNIKOVA-1420@MAIL.RU", "NASTYABOCHARNIKOVA-14", "AQAAAAIAAYagAAAAELVpVlSv0H3jj+u0xM5WP5h3Qut/BROFgkmM4Se0ewVJRbe25P/MDDucdCCiDJ3rHA==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "ffd74e00-398b-4563-a71f-0e59647da65e", false, "NastyaBocharnikova-14", null },
                    { "60b78d95-67f6-43ea-958c-ba3acf3f9267", 0, 0, "f959d1e9-f226-4b53-854b-98ca565e68ba", "I am a pooper! Poo poo poo!!!", "AdrewRojer-2220@mail.ru", true, null, false, null, "ADREWROJER-2220@MAIL.RU", "ADREWROJER-22", "AQAAAAIAAYagAAAAEFv2E3VzP91qSeDYBofIWEeNRoKmjlbXc+fBOklu7X4sDM+jhoVxy5pmqUnuTbLKhQ==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "3378d89e-6688-4588-9dfc-d3d5dd8fc5be", false, "AdrewRojer-22", null },
                    { "6eae61a9-18c4-4fa7-83e1-98c2bfb5c0b1", 0, 0, "637f8732-89a8-496a-a01d-ddef5a665ecb", "I am a pooper! Poo poo poo!!!", "AdrewRojer-2820@mail.ru", true, null, false, null, "ADREWROJER-2820@MAIL.RU", "ADREWROJER-28", "AQAAAAIAAYagAAAAEGJ9yH5T7rPi+7NjP5+nWnyJ/HoBLAsN3M2Rs3T4NQWE1UakEZeC3Zv9pLcVAXXI/w==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "6b18fef7-6ae5-4b1d-84a8-398b9dc49ea2", false, "AdrewRojer-28", null },
                    { "73231bcc-029a-403e-933d-d13277a16ce7", 0, 0, "220ae0f6-9b50-4e37-80d8-4c647408f3f7", "I am a pooper! Poo poo poo!!!", "NastyaBocharnikova-2720@mail.ru", true, null, false, null, "NASTYABOCHARNIKOVA-2720@MAIL.RU", "NASTYABOCHARNIKOVA-27", "AQAAAAIAAYagAAAAECbajo5eSlyjEjHP4x0WEQMyTLVGKht2tNFnrS47P6AiPBNUU1hPia35x7hpfDC0WA==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "7dc8df43-84f7-4520-ae92-8c786e065673", false, "NastyaBocharnikova-27", null },
                    { "74fc2a57-1944-46e3-888f-916c50ea5a47", 0, 0, "a40d6852-ce26-44b5-bf56-cbb926cd42b5", "I am a pooper! Poo poo poo!!!", "GregorPiha-720@mail.ru", true, null, false, null, "GREGORPIHA-720@MAIL.RU", "GREGORPIHA-7", "AQAAAAIAAYagAAAAEF7jdHBO9YYNtL7DJha/L0scAFieblvxfJQQcXtSR5DkEiWropT0i6HvVRL98WkqSA==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "52af036b-1fa7-49d3-a633-393663b28674", false, "GregorPiha-7", null },
                    { "763379f8-0e23-4ce5-b43a-cec33eac5a32", 0, 0, "779695b8-d8e3-4b4b-80e2-bca934e4b5dc", "I am a pooper! Poo poo poo!!!", "VladBlack-120@mail.ru", true, null, false, null, "VLADBLACK-120@MAIL.RU", "VLADBLACK-1", "AQAAAAIAAYagAAAAEB8qJ1cNNGCp4UsTHp0IfCwtH1OK12Ny2Eo5mwAvH0wX/EFXgFu5fFY6shV4OQIgSw==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "b21e3721-c4ab-49fa-ad8e-f0e1d1fb2d50", false, "VladBlack-1", null },
                    { "78ab86e4-ff9d-41ca-ab0a-94867253bffd", 0, 0, "a94c2891-a0f0-4031-91dc-567b24795396", "I am a pooper! Poo poo poo!!!", "SanchoLeaver-2320@mail.ru", true, null, false, null, "SANCHOLEAVER-2320@MAIL.RU", "SANCHOLEAVER-23", "AQAAAAIAAYagAAAAEKem9XbEfoTOZ+9LhpiGBkrL7xoc5AS5DEoFNvhX1xzLs0vHuRvmRqzx3KxK0WyE7g==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "c8b8ea71-2c90-40aa-a6f5-fda4793cb0b0", false, "SanchoLeaver-23", null },
                    { "79277431-92a5-4134-80dc-5dcdb7e4d969", 0, 0, "13ba7c5b-9801-44a7-8535-cc438776e557", "I am the admin! Call me the Boss!!!", "VladBalkar20@mail.ru", true, null, false, null, "VLADBALKAR20@MAIL.RU", "VLADBALKAR", "AQAAAAIAAYagAAAAEKJ8WpcvkLWG1R1lrtwLfKy7jFDL7Y8pL0B1xinFWD6THsHCVNfGVfvzTxsZjAsiJA==", "", true, "ede0e41a-7e0c-4eb8-aaba-85bb2872dd63", "930c655b-2eba-4dc3-917a-b0365ebe6ff9", false, "VladBalkar", null },
                    { "7b56b797-10e7-4642-8c56-7d00fa89f265", 0, 0, "2feb0619-5727-48e7-94a1-4828822b69f6", "I am a pooper! Poo poo poo!!!", "VladBlack-1120@mail.ru", true, null, false, null, "VLADBLACK-1120@MAIL.RU", "VLADBLACK-11", "AQAAAAIAAYagAAAAEENlE/Yj7VIEUeo4W+VriWKDrTsLhM950XlvAhfntOwrUGqWBrxwFNvH5AzfLW1g6w==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "6b867312-86dc-40ce-b3c9-c471c6c65d7a", false, "VladBlack-11", null },
                    { "8678ad5a-b93d-4220-8914-2958a96fe643", 0, 0, "c05ac265-79d4-4a7e-91fd-d9dd779c2386", "I am a pooper! Poo poo poo!!!", "SanchoLeaver-1920@mail.ru", true, null, false, null, "SANCHOLEAVER-1920@MAIL.RU", "SANCHOLEAVER-19", "AQAAAAIAAYagAAAAEEgNcUR0SuVinvQgauy3MW9r/DUgYpytts6gqj/dmEVW6OhANwyawbzChmKpSkgPCA==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "c43f9d5f-72e8-4650-8a1a-013e3033632c", false, "SanchoLeaver-19", null },
                    { "91529783-f59f-46e6-a909-e7019b5c7008", 0, 0, "50e20e45-e130-4654-a631-f64dfd3d174c", "I am a pooper! Poo poo poo!!!", "NastyaBocharnikova-020@mail.ru", true, null, false, null, "NASTYABOCHARNIKOVA-020@MAIL.RU", "NASTYABOCHARNIKOVA-0", "AQAAAAIAAYagAAAAEPjoTfNd/m9NeX+P3+S1nIAGXyvQOmbTW5RqMMeuvjMFlnjB9ZShlDbarlNXDgbMxQ==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "3949a3ca-624f-4d47-81b6-62fa6ef917e8", false, "NastyaBocharnikova-0", null },
                    { "a95a9af9-1f67-4c79-b559-c87ec054ff60", 0, 0, "bb8b1f41-d4d0-4874-8c67-3937ce36c034", "I am a pooper! Poo poo poo!!!", "SanchoLeaver-2420@mail.ru", true, null, false, null, "SANCHOLEAVER-2420@MAIL.RU", "SANCHOLEAVER-24", "AQAAAAIAAYagAAAAENwZ1bAWfNbQ0Lner+oZLeD6IjAPSl+LOBn3CB9qNJZpbQ5fwJ3mbqKQjHFrGq5H6A==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "760b0f97-5526-4ce7-b3b2-c2e3f243ad40", false, "SanchoLeaver-24", null },
                    { "ad9178c0-e81b-49d4-98f9-b51cfeb6c2af", 0, 0, "eeb055ac-aa14-490d-8764-9bc0acea0545", "I am a pooper! Poo poo poo!!!", "GregorPiha-920@mail.ru", true, null, false, null, "GREGORPIHA-920@MAIL.RU", "GREGORPIHA-9", "AQAAAAIAAYagAAAAEI09FoEE1IP1iDUfdh2VtzML4ApRXBRr4uTpjaYzjOBA/5+ydK8TPsnWSHkhT0Bw9Q==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "9e9d08a4-866e-440c-827c-488ddcfde151", false, "GregorPiha-9", null },
                    { "b20de05d-fd8b-4215-9f59-909ab9bf653b", 0, 0, "e0f0bb1d-59c1-4c50-a121-986819a096c8", "I am a pooper! Poo poo poo!!!", "VladBlack-1220@mail.ru", true, null, false, null, "VLADBLACK-1220@MAIL.RU", "VLADBLACK-12", "AQAAAAIAAYagAAAAEGbxsNlfAtMKWBUo2Se1SzxM6AKikSKpWOGhjsbwrKjQItmIh2mjzo/Ky36fDDBAaw==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "bc254010-3469-49b4-8943-f784d399b98b", false, "VladBlack-12", null },
                    { "b745f30f-098c-4fc4-80ed-350c9e86e281", 0, 0, "ad8469bd-5ed0-4c80-bb42-6fcdfbcbf0ce", "I am a pooper! Poo poo poo!!!", "AdrewRojer-420@mail.ru", true, null, false, null, "ADREWROJER-420@MAIL.RU", "ADREWROJER-4", "AQAAAAIAAYagAAAAEFH2C0mdMejXFBo0JwNDFUqfjdOGTHYziwV5ZXWOecWcKL0esUtEA1r4zBFV9bhfmQ==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "b242c69f-f801-4ec7-9862-fb3bfeae0c21", false, "AdrewRojer-4", null },
                    { "c7a156dc-7994-4782-91b7-4eb67587fe6f", 0, 0, "3e7d9ef2-6174-4e42-9262-783be1a12e12", "I am a pooper! Poo poo poo!!!", "NastyaKareva-2620@mail.ru", true, null, false, null, "NASTYAKAREVA-2620@MAIL.RU", "NASTYAKAREVA-26", "AQAAAAIAAYagAAAAEOu8lf7B/VDX95eUrKivgbdirR6HWo2iTTjL/2Ea41ClDyoxIavlGbgkhZ2irGBwGg==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "2d9f1f72-d086-439b-9c7c-3ac917993439", false, "NastyaKareva-26", null },
                    { "cb428034-74ac-489f-a6d1-62c48e6328a7", 0, 0, "28c0830e-0b77-4426-9a3b-53cb2f80d382", "I am a pooper! Poo poo poo!!!", "GregorPiha-2020@mail.ru", true, null, false, null, "GREGORPIHA-2020@MAIL.RU", "GREGORPIHA-20", "AQAAAAIAAYagAAAAEOZ1zGh45zRBvdWWV+ihQ2BVPt7EIvicS+XuHRdBHh2iCTjb9PZelB9dPsSxURXIeQ==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "080c8f67-42f4-4fe3-bfa9-eaca88928c31", false, "GregorPiha-20", null },
                    { "d51c0cb1-016f-4573-93bb-9e4a25a51042", 0, 0, "cbb4929e-71b7-4ac0-9b4c-5eb49baf579e", "I am a pooper! Poo poo poo!!!", "VladBlack-1820@mail.ru", true, null, false, null, "VLADBLACK-1820@MAIL.RU", "VLADBLACK-18", "AQAAAAIAAYagAAAAEMpufXoRVSvVG4SmzMtnUKvtYh5T/xCvM47Nk4i+XFhTrUVhhl/e6SEsdVlbQ7/wbQ==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "6c8ca6e8-429a-456b-8594-78afba846ad3", false, "VladBlack-18", null },
                    { "dd68aa51-d250-4c9d-9b3f-ec857abfefb1", 0, 0, "2f371f38-cf51-4895-a3f3-4b9d33bfccee", "I am a pooper! Poo poo poo!!!", "NastyaKareva-820@mail.ru", true, null, false, null, "NASTYAKAREVA-820@MAIL.RU", "NASTYAKAREVA-8", "AQAAAAIAAYagAAAAEIONuwk6bYj2UbBg+D2BxLjKUOBd0GxnUyQghGZHPExZPmBiY/1/lTWP8EOWZXSiPw==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "2ab71807-bb39-447d-a283-88985475a85f", false, "NastyaKareva-8", null },
                    { "df55044b-3e70-4914-9b12-a789938eb7d9", 0, 0, "515672b7-3eb8-4770-976c-27a0d14cb3ec", "I am a pooper! Poo poo poo!!!", "VladBlack-220@mail.ru", true, null, false, null, "VLADBLACK-220@MAIL.RU", "VLADBLACK-2", "AQAAAAIAAYagAAAAEAgV5Fcua9CTutvnY94kI6xSNgmaCUreE7dzC+Sv1NNwrUx0YpTwxVRpR6N1zQGnwQ==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "be46f58b-3b56-457b-8ece-8dc16d6a0843", false, "VladBlack-2", null },
                    { "e152e4c7-cec2-4160-9103-d0622d4b5ab5", 0, 0, "a621b009-7bcc-41e5-8c24-6cb802cabd1d", "I am a pooper! Poo poo poo!!!", "SanchoLeaver-1620@mail.ru", true, null, false, null, "SANCHOLEAVER-1620@MAIL.RU", "SANCHOLEAVER-16", "AQAAAAIAAYagAAAAENmonczxItGWJLPX4VIs5m5jLKDbKX1TZEw3MaHr8WYb4ia+flRKfewQoz3tUdbFtw==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "008b2a03-b13c-47fd-9928-941f81732270", false, "SanchoLeaver-16", null },
                    { "fa85c792-8b69-4d03-ade7-1800fcf5aa55", 0, 0, "29e50205-6b98-4b4e-98a7-d99da5f1793d", "I am a pooper! Poo poo poo!!!", "AdrewRojer-620@mail.ru", true, null, false, null, "ADREWROJER-620@MAIL.RU", "ADREWROJER-6", "AQAAAAIAAYagAAAAEKgcL5zjBeu6RHwyRJfDrKOR2yzOZZ2OixymYKSP/OEinYu6AVRECKKgSo4Og9W7mg==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "1adcd8fb-c11b-44ab-97c4-d45e21438bc4", false, "AdrewRojer-6", null },
                    { "fef98756-111e-4405-b117-4d39fce23d0a", 0, 0, "c9be83f9-d011-46f9-b3a9-88f290822081", "I am a pooper! Poo poo poo!!!", "AdrewRojer-1320@mail.ru", true, null, false, null, "ADREWROJER-1320@MAIL.RU", "ADREWROJER-13", "AQAAAAIAAYagAAAAEMdaKNc9gwwpA9ROfdNoTBBnxBMNPEkiyEFbpE6tSu3LAZXrgiMD8vdkvF9AmTSnpA==", "", true, "141e0978-3c9e-4074-92e5-abecffe0d99c", "572f4d6b-b79a-49f9-a389-8b55a3f8629f", false, "AdrewRojer-13", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 799583, "SharerClaim", "Back", "d51c0cb1-016f-4573-93bb-9e4a25a51042" },
                    { 2951150, "SharerClaim", "Lead", "7b56b797-10e7-4642-8c56-7d00fa89f265" },
                    { 28092540, "SharerClaim", "Lol", "7b56b797-10e7-4642-8c56-7d00fa89f265" },
                    { 35959751, "SharerClaim", "Front", "14ac3876-cdfe-421e-87f5-7e25049290a7" },
                    { 41823720, "SharerClaim", "Back", "a95a9af9-1f67-4c79-b559-c87ec054ff60" },
                    { 55888542, "SharerClaim", "Dev", "5e4676c9-5751-46a8-9194-1d5411648228" },
                    { 56732682, "SharerClaim", "Dev", "5b5fd5c5-f70d-4eb7-97bb-7012f5239636" },
                    { 57688462, "SharerClaim", "Dev", "d51c0cb1-016f-4573-93bb-9e4a25a51042" },
                    { 66443067, "SharerClaim", "Stinky", "4067d998-9b4f-4941-97c4-7cc3984731fe" },
                    { 78062952, "SharerClaim", "Lol", "60b78d95-67f6-43ea-958c-ba3acf3f9267" },
                    { 92369021, "SharerClaim", "Stinky", "d51c0cb1-016f-4573-93bb-9e4a25a51042" },
                    { 131332613, "SharerClaim", "Lead", "a95a9af9-1f67-4c79-b559-c87ec054ff60" },
                    { 159488245, "SharerClaim", "Lead", "e152e4c7-cec2-4160-9103-d0622d4b5ab5" },
                    { 165542149, "SharerClaim", "Dba", "52ab31cf-0a12-46e8-8e76-dceb4e314ed8" },
                    { 197992319, "SharerClaim", "Dba", "17904617-974d-42ec-acb7-8bbf97fc0b93" },
                    { 210120708, "SharerClaim", "Lead", "31213f3b-9ff2-46ab-a055-c1b10c0ab680" },
                    { 221733946, "SharerClaim", "Lol", "dd68aa51-d250-4c9d-9b3f-ec857abfefb1" },
                    { 283851094, "SharerClaim", "Lead", "b20de05d-fd8b-4215-9f59-909ab9bf653b" },
                    { 287040200, "SharerClaim", "Back", "5b5fd5c5-f70d-4eb7-97bb-7012f5239636" },
                    { 298020144, "SharerClaim", "Lead", "c7a156dc-7994-4782-91b7-4eb67587fe6f" },
                    { 298528646, "SharerClaim", "Back", "dd68aa51-d250-4c9d-9b3f-ec857abfefb1" },
                    { 299806558, "SharerClaim", "Stinky", "a95a9af9-1f67-4c79-b559-c87ec054ff60" },
                    { 304008610, "SharerClaim", "Dev", "c7a156dc-7994-4782-91b7-4eb67587fe6f" },
                    { 329027892, "SharerClaim", "Stinky", "e152e4c7-cec2-4160-9103-d0622d4b5ab5" },
                    { 337426543, "SharerClaim", "Lol", "74fc2a57-1944-46e3-888f-916c50ea5a47" },
                    { 356832734, "SharerClaim", "Lol", "fef98756-111e-4405-b117-4d39fce23d0a" },
                    { 408252702, "SharerClaim", "Front", "a95a9af9-1f67-4c79-b559-c87ec054ff60" },
                    { 420847719, "SharerClaim", "Front", "0c1df73d-271f-4785-9a9a-ce8534d96dc1" },
                    { 460319820, "SharerClaim", "Dev", "df55044b-3e70-4914-9b12-a789938eb7d9" },
                    { 465842678, "SharerClaim", "Back", "78ab86e4-ff9d-41ca-ab0a-94867253bffd" },
                    { 483033475, "SharerClaim", "Back", "60b78d95-67f6-43ea-958c-ba3acf3f9267" },
                    { 489030695, "SharerClaim", "Stinky", "5e4676c9-5751-46a8-9194-1d5411648228" },
                    { 493361568, "SharerClaim", "Dba", "763379f8-0e23-4ce5-b43a-cec33eac5a32" },
                    { 493886181, "SharerClaim", "Back", "17904617-974d-42ec-acb7-8bbf97fc0b93" },
                    { 518038319, "SharerClaim", "Dev", "4067d998-9b4f-4941-97c4-7cc3984731fe" },
                    { 518746848, "SharerClaim", "Dev", "8678ad5a-b93d-4220-8914-2958a96fe643" },
                    { 588757362, "SharerClaim", "Dev", "31213f3b-9ff2-46ab-a055-c1b10c0ab680" },
                    { 602634309, "BossClaim", "BossClaim", "79277431-92a5-4134-80dc-5dcdb7e4d969" },
                    { 639298895, "SharerClaim", "Lead", "91529783-f59f-46e6-a909-e7019b5c7008" },
                    { 658819874, "SharerClaim", "Dev", "74fc2a57-1944-46e3-888f-916c50ea5a47" },
                    { 672190182, "SharerClaim", "Front", "4067d998-9b4f-4941-97c4-7cc3984731fe" },
                    { 675636236, "SharerClaim", "Dba", "0f71294b-6eed-4555-a993-17ec66922612" },
                    { 678219776, "SharerClaim", "Dev", "14ac3876-cdfe-421e-87f5-7e25049290a7" },
                    { 678754087, "SharerClaim", "Dev", "e152e4c7-cec2-4160-9103-d0622d4b5ab5" },
                    { 704618941, "SharerClaim", "Dev", "17904617-974d-42ec-acb7-8bbf97fc0b93" },
                    { 763827891, "SharerClaim", "Dba", "fa85c792-8b69-4d03-ade7-1800fcf5aa55" },
                    { 780428214, "SharerClaim", "Back", "0f71294b-6eed-4555-a993-17ec66922612" },
                    { 795873939, "SharerClaim", "Lead", "78ab86e4-ff9d-41ca-ab0a-94867253bffd" },
                    { 825907669, "SharerClaim", "Dba", "31213f3b-9ff2-46ab-a055-c1b10c0ab680" },
                    { 829634256, "SharerClaim", "Lead", "4067d998-9b4f-4941-97c4-7cc3984731fe" },
                    { 861744320, "SharerClaim", "Stinky", "73231bcc-029a-403e-933d-d13277a16ce7" },
                    { 863353732, "SharerClaim", "Lol", "91529783-f59f-46e6-a909-e7019b5c7008" },
                    { 901439219, "SharerClaim", "Dev", "60b78d95-67f6-43ea-958c-ba3acf3f9267" },
                    { 924208317, "SharerClaim", "Dba", "5b5fd5c5-f70d-4eb7-97bb-7012f5239636" },
                    { 927060055, "SharerClaim", "Lol", "17904617-974d-42ec-acb7-8bbf97fc0b93" },
                    { 951977103, "SharerClaim", "Stinky", "ad9178c0-e81b-49d4-98f9-b51cfeb6c2af" },
                    { 977441889, "SharerClaim", "Lol", "14ac3876-cdfe-421e-87f5-7e25049290a7" },
                    { 998515681, "SharerClaim", "Back", "5e4676c9-5751-46a8-9194-1d5411648228" },
                    { 1031210755, "SharerClaim", "Dba", "73231bcc-029a-403e-933d-d13277a16ce7" },
                    { 1052346715, "SharerClaim", "Dba", "4067d998-9b4f-4941-97c4-7cc3984731fe" },
                    { 1052781288, "SharerClaim", "Lead", "5b5fd5c5-f70d-4eb7-97bb-7012f5239636" },
                    { 1053484248, "SharerClaim", "Lol", "ad9178c0-e81b-49d4-98f9-b51cfeb6c2af" },
                    { 1058339145, "SharerClaim", "Stinky", "c7a156dc-7994-4782-91b7-4eb67587fe6f" },
                    { 1071981067, "SharerClaim", "Lead", "b745f30f-098c-4fc4-80ed-350c9e86e281" },
                    { 1072440820, "SharerClaim", "Back", "91529783-f59f-46e6-a909-e7019b5c7008" },
                    { 1077780533, "SharerClaim", "Dba", "dd68aa51-d250-4c9d-9b3f-ec857abfefb1" },
                    { 1081868784, "SharerClaim", "Stinky", "dd68aa51-d250-4c9d-9b3f-ec857abfefb1" },
                    { 1108320132, "SharerClaim", "Front", "0f71294b-6eed-4555-a993-17ec66922612" },
                    { 1114354845, "SharerClaim", "Lol", "5b5fd5c5-f70d-4eb7-97bb-7012f5239636" },
                    { 1117231971, "SharerClaim", "Dba", "78ab86e4-ff9d-41ca-ab0a-94867253bffd" },
                    { 1136414074, "SharerClaim", "Lead", "df55044b-3e70-4914-9b12-a789938eb7d9" },
                    { 1140129437, "SharerClaim", "Stinky", "52ab31cf-0a12-46e8-8e76-dceb4e314ed8" },
                    { 1153635371, "SharerClaim", "Dba", "e152e4c7-cec2-4160-9103-d0622d4b5ab5" },
                    { 1185580400, "SharerClaim", "Stinky", "6eae61a9-18c4-4fa7-83e1-98c2bfb5c0b1" },
                    { 1188009155, "SharerClaim", "Dba", "ad9178c0-e81b-49d4-98f9-b51cfeb6c2af" },
                    { 1214045480, "SharerClaim", "Lol", "5e4676c9-5751-46a8-9194-1d5411648228" },
                    { 1225004237, "SharerClaim", "Front", "fa85c792-8b69-4d03-ade7-1800fcf5aa55" },
                    { 1227787672, "SharerClaim", "Front", "cb428034-74ac-489f-a6d1-62c48e6328a7" },
                    { 1237514953, "SharerClaim", "Dev", "6eae61a9-18c4-4fa7-83e1-98c2bfb5c0b1" },
                    { 1241273842, "SharerClaim", "Back", "52ab31cf-0a12-46e8-8e76-dceb4e314ed8" },
                    { 1269278859, "SharerClaim", "Lead", "fef98756-111e-4405-b117-4d39fce23d0a" },
                    { 1275438208, "SharerClaim", "Dev", "fef98756-111e-4405-b117-4d39fce23d0a" },
                    { 1293413404, "SharerClaim", "Lol", "31213f3b-9ff2-46ab-a055-c1b10c0ab680" },
                    { 1334859437, "SharerClaim", "Dba", "0c1df73d-271f-4785-9a9a-ce8534d96dc1" },
                    { 1396078129, "SharerClaim", "Front", "ad9178c0-e81b-49d4-98f9-b51cfeb6c2af" },
                    { 1409977444, "SharerClaim", "Back", "ad9178c0-e81b-49d4-98f9-b51cfeb6c2af" },
                    { 1410894884, "SharerClaim", "Front", "dd68aa51-d250-4c9d-9b3f-ec857abfefb1" },
                    { 1460432596, "SharerClaim", "Dev", "a95a9af9-1f67-4c79-b559-c87ec054ff60" },
                    { 1475130206, "SharerClaim", "Dba", "74fc2a57-1944-46e3-888f-916c50ea5a47" },
                    { 1508281739, "SharerClaim", "Front", "df55044b-3e70-4914-9b12-a789938eb7d9" },
                    { 1519554160, "SharerClaim", "Lol", "b745f30f-098c-4fc4-80ed-350c9e86e281" },
                    { 1533929501, "SharerClaim", "Front", "e152e4c7-cec2-4160-9103-d0622d4b5ab5" },
                    { 1537633819, "SharerClaim", "Front", "fef98756-111e-4405-b117-4d39fce23d0a" },
                    { 1581011563, "SharerClaim", "Front", "74fc2a57-1944-46e3-888f-916c50ea5a47" },
                    { 1591382127, "SharerClaim", "Dev", "52ab31cf-0a12-46e8-8e76-dceb4e314ed8" },
                    { 1623712431, "SharerClaim", "Front", "c7a156dc-7994-4782-91b7-4eb67587fe6f" },
                    { 1626049072, "SharerClaim", "Front", "73231bcc-029a-403e-933d-d13277a16ce7" },
                    { 1626784383, "SharerClaim", "Front", "78ab86e4-ff9d-41ca-ab0a-94867253bffd" },
                    { 1649631468, "SharerClaim", "Front", "b745f30f-098c-4fc4-80ed-350c9e86e281" },
                    { 1656952277, "SharerClaim", "Front", "5e4676c9-5751-46a8-9194-1d5411648228" },
                    { 1661539475, "SharerClaim", "Lead", "5e4676c9-5751-46a8-9194-1d5411648228" },
                    { 1675213763, "SharerClaim", "Front", "52ab31cf-0a12-46e8-8e76-dceb4e314ed8" },
                    { 1709567218, "SharerClaim", "Stinky", "0f71294b-6eed-4555-a993-17ec66922612" },
                    { 1751906625, "SharerClaim", "Front", "b20de05d-fd8b-4215-9f59-909ab9bf653b" },
                    { 1777956039, "SharerClaim", "Lol", "df55044b-3e70-4914-9b12-a789938eb7d9" },
                    { 1785933454, "SharerClaim", "Back", "fa85c792-8b69-4d03-ade7-1800fcf5aa55" },
                    { 1787481124, "SharerClaim", "Dba", "c7a156dc-7994-4782-91b7-4eb67587fe6f" },
                    { 1787781713, "SharerClaim", "Lead", "dd68aa51-d250-4c9d-9b3f-ec857abfefb1" },
                    { 1843385702, "SharerClaim", "Lol", "0f71294b-6eed-4555-a993-17ec66922612" },
                    { 1863288295, "SharerClaim", "Front", "91529783-f59f-46e6-a909-e7019b5c7008" },
                    { 1869681260, "SharerClaim", "Dev", "0c1df73d-271f-4785-9a9a-ce8534d96dc1" },
                    { 1871744435, "SharerClaim", "Lol", "c7a156dc-7994-4782-91b7-4eb67587fe6f" },
                    { 1878142988, "SharerClaim", "Dba", "91529783-f59f-46e6-a909-e7019b5c7008" },
                    { 1879190156, "SharerClaim", "Lol", "763379f8-0e23-4ce5-b43a-cec33eac5a32" },
                    { 1887565804, "SharerClaim", "Back", "31213f3b-9ff2-46ab-a055-c1b10c0ab680" },
                    { 1913763672, "SharerClaim", "Stinky", "b20de05d-fd8b-4215-9f59-909ab9bf653b" },
                    { 1916608198, "SharerClaim", "Stinky", "17904617-974d-42ec-acb7-8bbf97fc0b93" },
                    { 1951422034, "SharerClaim", "Stinky", "fa85c792-8b69-4d03-ade7-1800fcf5aa55" },
                    { 1964216306, "SharerClaim", "Lead", "6eae61a9-18c4-4fa7-83e1-98c2bfb5c0b1" },
                    { 1990055372, "SharerClaim", "Lead", "cb428034-74ac-489f-a6d1-62c48e6328a7" },
                    { 1997342579, "SharerClaim", "Stinky", "60b78d95-67f6-43ea-958c-ba3acf3f9267" },
                    { 2005939682, "SharerClaim", "Front", "d51c0cb1-016f-4573-93bb-9e4a25a51042" },
                    { 2010922972, "SharerClaim", "Stinky", "78ab86e4-ff9d-41ca-ab0a-94867253bffd" },
                    { 2024970530, "SharerClaim", "Stinky", "31213f3b-9ff2-46ab-a055-c1b10c0ab680" },
                    { 2032718909, "SharerClaim", "Lol", "fa85c792-8b69-4d03-ade7-1800fcf5aa55" },
                    { 2039971813, "SharerClaim", "Lead", "ad9178c0-e81b-49d4-98f9-b51cfeb6c2af" },
                    { 2069931733, "SharerClaim", "Lead", "fa85c792-8b69-4d03-ade7-1800fcf5aa55" },
                    { 2098895574, "SharerClaim", "Lol", "73231bcc-029a-403e-933d-d13277a16ce7" },
                    { 2115245597, "SharerClaim", "Stinky", "14ac3876-cdfe-421e-87f5-7e25049290a7" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "0c1df73d-271f-4785-9a9a-ce8534d96dc1" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "0f71294b-6eed-4555-a993-17ec66922612" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "14ac3876-cdfe-421e-87f5-7e25049290a7" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "17904617-974d-42ec-acb7-8bbf97fc0b93" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "31213f3b-9ff2-46ab-a055-c1b10c0ab680" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "4067d998-9b4f-4941-97c4-7cc3984731fe" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "52ab31cf-0a12-46e8-8e76-dceb4e314ed8" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "5b5fd5c5-f70d-4eb7-97bb-7012f5239636" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "5e4676c9-5751-46a8-9194-1d5411648228" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "60b78d95-67f6-43ea-958c-ba3acf3f9267" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "6eae61a9-18c4-4fa7-83e1-98c2bfb5c0b1" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "73231bcc-029a-403e-933d-d13277a16ce7" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "74fc2a57-1944-46e3-888f-916c50ea5a47" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "763379f8-0e23-4ce5-b43a-cec33eac5a32" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "78ab86e4-ff9d-41ca-ab0a-94867253bffd" },
                    { "ede0e41a-7e0c-4eb8-aaba-85bb2872dd63", "79277431-92a5-4134-80dc-5dcdb7e4d969" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "7b56b797-10e7-4642-8c56-7d00fa89f265" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "8678ad5a-b93d-4220-8914-2958a96fe643" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "91529783-f59f-46e6-a909-e7019b5c7008" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "a95a9af9-1f67-4c79-b559-c87ec054ff60" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "ad9178c0-e81b-49d4-98f9-b51cfeb6c2af" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "b20de05d-fd8b-4215-9f59-909ab9bf653b" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "b745f30f-098c-4fc4-80ed-350c9e86e281" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "c7a156dc-7994-4782-91b7-4eb67587fe6f" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "cb428034-74ac-489f-a6d1-62c48e6328a7" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "d51c0cb1-016f-4573-93bb-9e4a25a51042" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "dd68aa51-d250-4c9d-9b3f-ec857abfefb1" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "df55044b-3e70-4914-9b12-a789938eb7d9" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "e152e4c7-cec2-4160-9103-d0622d4b5ab5" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "fa85c792-8b69-4d03-ade7-1800fcf5aa55" },
                    { "141e0978-3c9e-4074-92e5-abecffe0d99c", "fef98756-111e-4405-b117-4d39fce23d0a" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Poopers_UserEntityId",
                table: "Poopers",
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
                name: "Poopers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
