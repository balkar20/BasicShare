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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39eb544e-2aa1-447c-8c2f-157fef66f532", null, "IdentityRole", "Reviwer", "REVIWER" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", null, "IdentityRole", "Pooper", "POOPER" },
                    { "82d36c38-b206-4709-b2e4-434599768621", null, "IdentityRole", "Maker", "MAKER" },
                    { "e08fdc8a-076a-4498-a86c-eb26bf127458", null, "IdentityRole", "Viewer", "VIEWER" },
                    { "f6ed4a0d-9d62-43dd-8b22-004a142bc227", null, "IdentityRole", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AmountOfPoints", "ConcurrencyStamp", "Description", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName", "Year" },
                values: new object[,]
                {
                    { "0034b642-85f5-4c06-bb37-a500e288c187", 0, 0, "b8909bce-52c5-4c61-9c16-ec798a5b2bac", "I am a pooper! Poo poo poo!!!", "NastyaKareva-2220@mail.ru", true, null, false, null, "NASTYAKAREVA-2220@MAIL.RU", "NASTYAKAREVA-22", "AQAAAAIAAYagAAAAEH2XGLtp3wLYacxSkcVsF6lQKcW0OzmaRdhJ97kKsu4KS/tegpJjLhXRgdYXL+cilQ==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "f1ddbd45-8fe4-4845-9504-9d6f4bc5225b", false, "NastyaKareva-22", null },
                    { "05d4176e-5516-4263-9561-750e6d07a75b", 0, 0, "31a37648-9f76-42c8-92eb-76bac3248538", "I am a pooper! Poo poo poo!!!", "SanchoLeaver-2520@mail.ru", true, null, false, null, "SANCHOLEAVER-2520@MAIL.RU", "SANCHOLEAVER-25", "AQAAAAIAAYagAAAAEHjUFWE561vV4liYt+Fh7s927hecylvtCASJPSKyjCgQR+WEdD67cm83mAaEcCKFyg==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "36aaf59e-de76-4bf6-8b86-9838a25f3150", false, "SanchoLeaver-25", null },
                    { "149a9b6c-a589-4a22-82f0-e655a84210ee", 0, 0, "7fcb1222-411c-4621-a4a2-6b857267b671", "I am a pooper! Poo poo poo!!!", "AdrewRojer-1720@mail.ru", true, null, false, null, "ADREWROJER-1720@MAIL.RU", "ADREWROJER-17", "AQAAAAIAAYagAAAAEE9JcoNt3YY0hAwMBdTlc+mJiM/DDnLgzDqVUhgfj/rxJLuTxfxSjm2JJT8a5YOODQ==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "cc9b6f19-e394-48ef-aad6-0170ef2e0604", false, "AdrewRojer-17", null },
                    { "1f809152-0401-4ab0-b80d-e61d046e7e30", 0, 0, "1dde0fe7-c656-41e4-821c-d54217d29cbb", "I am a pooper! Poo poo poo!!!", "VladBlack-2320@mail.ru", true, null, false, null, "VLADBLACK-2320@MAIL.RU", "VLADBLACK-23", "AQAAAAIAAYagAAAAEC85P8yjKup6ScJoNXTUITTE5yM6L+U3tSZ6S1YMPu93uFAW+FLtYFKVnfc15DZAIw==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "8be09681-aabc-4518-8ca5-5120aad84f1d", false, "VladBlack-23", null },
                    { "2506ad74-1604-4a0e-bfff-d434b16344ae", 0, 0, "c36508de-2286-415c-ad4d-0f58e1274bd6", "I am a pooper! Poo poo poo!!!", "NastyaKareva-2020@mail.ru", true, null, false, null, "NASTYAKAREVA-2020@MAIL.RU", "NASTYAKAREVA-20", "AQAAAAIAAYagAAAAEPS5Rlw5y6W4rHgNoPBCl5h+VUdA6dZMQ4uZFK6jTt5WtRLli5cpDQ9+hhZhcwFlsw==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "fa51c59c-82f2-428a-b9cf-09dbf11c65d1", false, "NastyaKareva-20", null },
                    { "2ae52980-9c9e-4391-adf6-0390a3f82084", 0, 0, "1abd7542-11cf-4eb8-8dda-7a70e38cf89b", "I am a pooper! Poo poo poo!!!", "GregorPiha-2920@mail.ru", true, null, false, null, "GREGORPIHA-2920@MAIL.RU", "GREGORPIHA-29", "AQAAAAIAAYagAAAAEM1te70waCZOzjGYmkA4SdHku3Sl0F6699Lxm9NIZehLdJ5leODMwaCqHogbCMBZ1w==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "f41258f1-308b-4f4e-ac39-088014563d6e", false, "GregorPiha-29", null },
                    { "3f6a3f23-4c49-4fc9-9c5c-1ec226cf3a4a", 0, 0, "bb735063-0a6d-4571-903f-614d6125ac84", "I am a pooper! Poo poo poo!!!", "SanchoLeaver-620@mail.ru", true, null, false, null, "SANCHOLEAVER-620@MAIL.RU", "SANCHOLEAVER-6", "AQAAAAIAAYagAAAAEFlA1ZhJV/sx1RXgn6mYmpiZlD0QhJnTe1F/IgBk4jwBBsSf7q9ugUQTswxPxPb9eQ==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "1800b893-1b12-4aeb-8c94-7f470d34e6a6", false, "SanchoLeaver-6", null },
                    { "40dee089-43c6-4781-b39c-b320375a0f10", 0, 0, "582c92da-d1b0-4c4b-ac0e-8c8ee70a71e4", "I am a pooper! Poo poo poo!!!", "GregorPiha-820@mail.ru", true, null, false, null, "GREGORPIHA-820@MAIL.RU", "GREGORPIHA-8", "AQAAAAIAAYagAAAAEA8kb9OXME/U7fdLPPhIdD4ImcxsYIsIe5Kyhk9KEy/ohylUNMrjPlVezkaNmEHDeA==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "cb045dbe-1069-444f-aee8-021e12473488", false, "GregorPiha-8", null },
                    { "52c7c03e-6b9c-43c8-93cd-6d0c38af2520", 0, 0, "a0d7c3bc-9f9a-43be-a381-b486f1b33c95", "I am a pooper! Poo poo poo!!!", "SanchoLeaver-1920@mail.ru", true, null, false, null, "SANCHOLEAVER-1920@MAIL.RU", "SANCHOLEAVER-19", "AQAAAAIAAYagAAAAEOLVWXnpVcH217ikfFDLqpbxNyvzQuM0Z48BmQmU4OTC8jX6kByA8x4c1AQsgJXZGg==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "231ebf6e-56f3-4ac0-908b-8f0c26ae58b9", false, "SanchoLeaver-19", null },
                    { "569e6ec9-987b-484d-bfde-b393fed2b933", 0, 0, "36291a61-2485-4ec2-bd0f-fdf1a866a038", "I am a pooper! Poo poo poo!!!", "AdrewRojer-1520@mail.ru", true, null, false, null, "ADREWROJER-1520@MAIL.RU", "ADREWROJER-15", "AQAAAAIAAYagAAAAEGTenJ/Omy0cEhqXLcf4CpKVXxVRhiR7HVSUL29vCdYvHrqwOOza2OgDZQ53BqSOFQ==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "1bf538b1-8f95-4c54-993d-b1e9c319e4c4", false, "AdrewRojer-15", null },
                    { "67b764c8-35e7-462a-95e6-b39f2291c4fe", 0, 0, "0db5944b-4d44-42d0-ad33-8da94c1b9aff", "I am a pooper! Poo poo poo!!!", "AdrewRojer-720@mail.ru", true, null, false, null, "ADREWROJER-720@MAIL.RU", "ADREWROJER-7", "AQAAAAIAAYagAAAAEGyHgBQOlq2THuSEe99uaRBuKyqxUe3nuoan+1SDqbxReII2x/gNQeQE0Ew/zdtS2w==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "08df3d38-e66f-46fc-92b2-7f47b869fb69", false, "AdrewRojer-7", null },
                    { "71827788-34d5-458b-b030-99c0fa21dd42", 0, 0, "b97efea8-acbe-4436-8931-20e2aa8d8b38", "I am a pooper! Poo poo poo!!!", "SanchoLeaver-1820@mail.ru", true, null, false, null, "SANCHOLEAVER-1820@MAIL.RU", "SANCHOLEAVER-18", "AQAAAAIAAYagAAAAEDmC55W2LE+6dcVV/cWv2C6ep1ECQzQnWt0iZXo/hRIRTX34AijfZMSP2YLpGPHLCQ==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "83397ea2-1a79-4d59-acaf-9bbb5dc7772a", false, "SanchoLeaver-18", null },
                    { "7265999d-da9d-461c-a372-a1090a8a62ec", 0, 0, "fabe3f08-65cc-4a30-8e43-74aa0a5b1ed8", "I am a pooper! Poo poo poo!!!", "SanchoLeaver-2620@mail.ru", true, null, false, null, "SANCHOLEAVER-2620@MAIL.RU", "SANCHOLEAVER-26", "AQAAAAIAAYagAAAAEEfe/LYagVty/ynbrGy80dJ8w3b9RxQYMjdfpUB6JH2oLHogdT7uElQMnPxA7C1ACQ==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "a759e3da-591b-4a26-8d7f-b28f9f5d1591", false, "SanchoLeaver-26", null },
                    { "775134f4-446d-4393-a01d-8e52bd08ff78", 0, 0, "7904308f-a49f-413e-8027-fd42904c7df0", "I am a pooper! Poo poo poo!!!", "NastyaBocharnikova-120@mail.ru", true, null, false, null, "NASTYABOCHARNIKOVA-120@MAIL.RU", "NASTYABOCHARNIKOVA-1", "AQAAAAIAAYagAAAAEB0aV205JlCYXfEodx+DCXYlsBPgxuVQUpy04BdPQ2YuYD28PiGW5GTf+I+rGh4g2Q==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "b4182e9d-770b-4b24-b134-fbf9f563064e", false, "NastyaBocharnikova-1", null },
                    { "8021b9a7-dca8-4940-b587-3fb85064c8a1", 0, 0, "88a8ad62-3a21-49bc-a5aa-977ad7673f93", "I am a pooper! Poo poo poo!!!", "SanchoLeaver-1220@mail.ru", true, null, false, null, "SANCHOLEAVER-1220@MAIL.RU", "SANCHOLEAVER-12", "AQAAAAIAAYagAAAAEI7EYo/0ZTRr6ecT7cTsRfcdDAl8MWMBNUanc/bV0gf7fmaTtmVIswpf20EZvoYAzQ==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "addced64-0274-49de-8f90-b4dd75e1eb2c", false, "SanchoLeaver-12", null },
                    { "8cef2ae9-c0d2-4ab5-8646-429c68e7cdfc", 0, 0, "61ad0ef0-34fa-48a5-b8fb-4d4312ec1a38", "I am a pooper! Poo poo poo!!!", "AdrewRojer-1120@mail.ru", true, null, false, null, "ADREWROJER-1120@MAIL.RU", "ADREWROJER-11", "AQAAAAIAAYagAAAAECEcMyIhoGwLI/6HW4ImyBmvkko++Nw+eUXcmThS5TuHBple6OTA7wmYPEewtGwL4g==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "dfd043f1-a08d-4cbb-8620-df7a78f8fca8", false, "AdrewRojer-11", null },
                    { "8de033fe-d7c2-4375-9e49-d7387fe86153", 0, 0, "f8c07008-e8ed-4085-8aec-5d8193996bed", "I am a pooper! Poo poo poo!!!", "SanchoLeaver-2820@mail.ru", true, null, false, null, "SANCHOLEAVER-2820@MAIL.RU", "SANCHOLEAVER-28", "AQAAAAIAAYagAAAAEKTg/EfkwFwUmNUq5WnOLJrcZz/atfuxGCJDk2QVutEZkZ3u47BIDkZ2YMf2RQB0ww==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "cd2ab6e5-5dc5-4cb7-9f25-710f89f866d7", false, "SanchoLeaver-28", null },
                    { "8e39a8f9-830a-4cfc-bbc1-462b84c85b71", 0, 0, "2cb0863b-c0a3-481f-bbc0-62ab0b9daa4f", "I am a pooper! Poo poo poo!!!", "VladBlack-1420@mail.ru", true, null, false, null, "VLADBLACK-1420@MAIL.RU", "VLADBLACK-14", "AQAAAAIAAYagAAAAEP3BXTcBiyTdUdFOdj6JPhKNZOXnM/PLctPgh83W7/bo+aJdI2vcYp5IGSHTymlt6g==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "a67433c3-6dee-444c-a3f4-f52c88dcb306", false, "VladBlack-14", null },
                    { "906f6fc5-68ee-431b-be2e-2545682da6bd", 0, 0, "8c5064f0-6dce-423f-a73e-f6fcb0fd5cf8", "I am a pooper! Poo poo poo!!!", "VladBlack-220@mail.ru", true, null, false, null, "VLADBLACK-220@MAIL.RU", "VLADBLACK-2", "AQAAAAIAAYagAAAAEKi63qS8xVFquS+MPaEtciG0IkPQYHK/CS4ptzMTWJ67oIaIHpq7tchiPrAJpGt6ZA==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "7d2e5590-23bc-4878-aa02-e3bf8a3d7ed4", false, "VladBlack-2", null },
                    { "97d4c05f-c0a0-475a-9ba5-7d027d193c60", 0, 0, "40865ac6-566a-44a6-a70e-38451e90f1c3", "I am a pooper! Poo poo poo!!!", "AdrewRojer-920@mail.ru", true, null, false, null, "ADREWROJER-920@MAIL.RU", "ADREWROJER-9", "AQAAAAIAAYagAAAAEE0Xf9n8q8GX4g8k+FhipxCiizt/BFQ9zvqCOxhWdB1KAfslFXwMkX2AXPsPQ9dAWg==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "2fc6960b-cc3a-419c-9b30-4440d2947dc5", false, "AdrewRojer-9", null },
                    { "aef95f03-48d8-4397-b0c3-3b5b09f8375f", 0, 0, "d51587f7-9c67-4167-ac24-c04b9d0a2636", "I am a pooper! Poo poo poo!!!", "NastyaKareva-1320@mail.ru", true, null, false, null, "NASTYAKAREVA-1320@MAIL.RU", "NASTYAKAREVA-13", "AQAAAAIAAYagAAAAEAOitqXH8QzM4EmwNrVU4gZ+tyDqKVdQT/uTu5miNSkpovukID8TWy2Ls9dEY0thlg==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "4cab2cb5-0148-4037-8552-2ffae42f228e", false, "NastyaKareva-13", null },
                    { "b3023d3d-0a25-43ac-ba10-3815be222227", 0, 0, "aab87d16-a9bb-4d75-979d-ef7bebc6a914", "I am a pooper! Poo poo poo!!!", "SanchoLeaver-020@mail.ru", true, null, false, null, "SANCHOLEAVER-020@MAIL.RU", "SANCHOLEAVER-0", "AQAAAAIAAYagAAAAELbhvlfiafcTOIVJlIdJoe6WLWPX/Cr1vySS7ULwIduQwT//dFjbqpniULn86Yecjw==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "d2e15602-19d7-48ad-9789-b24ee89a29d7", false, "SanchoLeaver-0", null },
                    { "b44a894a-7a09-4543-9f02-cbcfd40cbb8d", 0, 0, "970253c9-8d2c-4c43-8877-a3bede038ae9", "I am a pooper! Poo poo poo!!!", "VladBlack-2720@mail.ru", true, null, false, null, "VLADBLACK-2720@MAIL.RU", "VLADBLACK-27", "AQAAAAIAAYagAAAAEDr8PcaEFVoEpeB/Lc1y3E1BR3o6IddC+fbioFSTMKqfTfasyr59b9UIlI/I1nwQaA==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "c5ae7eea-d2ad-462d-a0eb-c942be25cbf4", false, "VladBlack-27", null },
                    { "bd552e5c-2adb-4974-aecc-43bfaf14fed9", 0, 0, "209c6bac-4a04-4725-9632-12eed76f1c3b", "I am a pooper! Poo poo poo!!!", "VladBlack-2420@mail.ru", true, null, false, null, "VLADBLACK-2420@MAIL.RU", "VLADBLACK-24", "AQAAAAIAAYagAAAAEDbvcLnQ+Ua4+5z899jgUecHTK9muhb6MpGXzeo8c0Ys6azpcQSAf7v1SrY7fjk+Hg==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "34e9e35d-6c51-4b9c-9711-7b6574c557a4", false, "VladBlack-24", null },
                    { "c1713cd1-099d-4de3-bd55-11192ec724ad", 0, 0, "67e0672c-fd8e-4fb1-9250-2fc0f6d2217b", "I am a pooper! Poo poo poo!!!", "SanchoLeaver-1020@mail.ru", true, null, false, null, "SANCHOLEAVER-1020@MAIL.RU", "SANCHOLEAVER-10", "AQAAAAIAAYagAAAAEGHkSJo/0Ej2xLBd4RUkRQzOeT9MFw76eiAzd/UmtpBhk4IH/WD5+UWzcczsppx/uQ==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "6a7c48e8-e16c-49d8-aa74-77a4e517082d", false, "SanchoLeaver-10", null },
                    { "c9af9594-c82f-4069-84eb-4d3793d987b9", 0, 0, "d2a50c9a-efdb-460d-9c16-6db2b8a02725", "I am a pooper! Poo poo poo!!!", "VladBlack-320@mail.ru", true, null, false, null, "VLADBLACK-320@MAIL.RU", "VLADBLACK-3", "AQAAAAIAAYagAAAAEMN53fZD+jSaF+wvkcgk+yKKCh+B+5Nc2BzzFGz3+HUYWMTfChXxvMcMOA7xiopfwA==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "94d0d49e-35af-4002-84b5-d5b50fc919f1", false, "VladBlack-3", null },
                    { "ca54a240-4d1e-4a8a-ac34-3fad5c5c5fc2", 0, 0, "70a652e7-f9f3-448f-87e2-f5c2f690d810", "I am a pooper! Poo poo poo!!!", "SanchoLeaver-1620@mail.ru", true, null, false, null, "SANCHOLEAVER-1620@MAIL.RU", "SANCHOLEAVER-16", "AQAAAAIAAYagAAAAEDIB7EMNQ5+Dc5GnlppuIuWMZM+vSNWolGb6vTafwGlZDMejyLmpDEUZgcEGxszGuA==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "1572cc96-cc31-4811-ad03-e9bcdfa8fc21", false, "SanchoLeaver-16", null },
                    { "d23163db-be3e-4fd5-a5da-2f72c768c05a", 0, 0, "4c007207-8ad5-4776-8275-49b195a73e53", "I am a pooper! Poo poo poo!!!", "GregorPiha-420@mail.ru", true, null, false, null, "GREGORPIHA-420@MAIL.RU", "GREGORPIHA-4", "AQAAAAIAAYagAAAAEOCyeSbGD83XYfYmHxU2+Y6fJ+OsVGnqhSJv3n+U5Q9JecqTWT8uW15EjZEr7vTSFw==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "3e912ec5-263b-4994-b233-40783930ac85", false, "GregorPiha-4", null },
                    { "dba21b20-7551-488a-bb08-40f034e0b475", 0, 0, "3aa8c73a-6479-4d4f-89d0-48c75e4b6642", "I am a pooper! Poo poo poo!!!", "AdrewRojer-520@mail.ru", true, null, false, null, "ADREWROJER-520@MAIL.RU", "ADREWROJER-5", "AQAAAAIAAYagAAAAEJ4S5zEVQvfIwuMNRH6mRdfBH/kpTZugtBN2FUQz+OkezyWkmsdwn5WkS2n+GDakHg==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "f50778a5-4300-4df3-8eac-90700254470c", false, "AdrewRojer-5", null },
                    { "ed1e6df8-af68-44cc-80ff-e32937583545", 0, 0, "3d267db2-1267-4515-97dd-b048eb017f73", "I am a pooper! Poo poo poo!!!", "SanchoLeaver-2120@mail.ru", true, null, false, null, "SANCHOLEAVER-2120@MAIL.RU", "SANCHOLEAVER-21", "AQAAAAIAAYagAAAAECn+M2iaVSWEZqKiHauRPxU3kE153400HFXbEi8XLxe638y5Fi6Y/e4rkhkvpOlgKQ==", "", true, "509e6302-eac5-42e3-8ed7-f542f6579487", "3cb8913c-ab60-4fde-bb0e-9d072185d30f", false, "SanchoLeaver-21", null },
                    { "eda12e6b-c0da-4b5c-b5df-accdc0d91847", 0, 0, "d69e64c0-a01b-4de4-aeb2-0d072e793dc3", "I am the admin! Call me the Boss!!!", "VladBalkar20@mail.ru", true, null, false, null, "VLADBALKAR20@MAIL.RU", "VLADBALKAR", "AQAAAAIAAYagAAAAEMxshkAdnsDvEEhC1Iz7mQRrnRNm9V1Pgx6l7AoEMGElXngwuOHGFP7iKcQew16X4Q==", "", true, "f6ed4a0d-9d62-43dd-8b22-004a142bc227", "fd8b6237-b249-457d-aa1e-1b361e7c671e", false, "VladBalkar", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 15717488, "SharerClaim", "Back", "8de033fe-d7c2-4375-9e49-d7387fe86153" },
                    { 74115542, "SharerClaim", "Front", "906f6fc5-68ee-431b-be2e-2545682da6bd" },
                    { 80319825, "SharerClaim", "Lol", "aef95f03-48d8-4397-b0c3-3b5b09f8375f" },
                    { 87921071, "SharerClaim", "Stinky", "775134f4-446d-4393-a01d-8e52bd08ff78" },
                    { 94213098, "SharerClaim", "Dev", "8cef2ae9-c0d2-4ab5-8646-429c68e7cdfc" },
                    { 118938034, "SharerClaim", "Lead", "c1713cd1-099d-4de3-bd55-11192ec724ad" },
                    { 156896491, "SharerClaim", "Front", "97d4c05f-c0a0-475a-9ba5-7d027d193c60" },
                    { 169645470, "SharerClaim", "Stinky", "ed1e6df8-af68-44cc-80ff-e32937583545" },
                    { 177452456, "SharerClaim", "Dev", "775134f4-446d-4393-a01d-8e52bd08ff78" },
                    { 186461090, "SharerClaim", "Stinky", "569e6ec9-987b-484d-bfde-b393fed2b933" },
                    { 230328325, "SharerClaim", "Back", "ca54a240-4d1e-4a8a-ac34-3fad5c5c5fc2" },
                    { 259075146, "SharerClaim", "Lead", "8de033fe-d7c2-4375-9e49-d7387fe86153" },
                    { 263197977, "SharerClaim", "Dba", "8e39a8f9-830a-4cfc-bbc1-462b84c85b71" },
                    { 263686423, "SharerClaim", "Lol", "71827788-34d5-458b-b030-99c0fa21dd42" },
                    { 297144103, "SharerClaim", "Lead", "67b764c8-35e7-462a-95e6-b39f2291c4fe" },
                    { 303348558, "SharerClaim", "Dev", "05d4176e-5516-4263-9561-750e6d07a75b" },
                    { 320226043, "SharerClaim", "Lead", "7265999d-da9d-461c-a372-a1090a8a62ec" },
                    { 324593259, "SharerClaim", "Lol", "67b764c8-35e7-462a-95e6-b39f2291c4fe" },
                    { 324913620, "SharerClaim", "Dev", "71827788-34d5-458b-b030-99c0fa21dd42" },
                    { 346700899, "SharerClaim", "Front", "8cef2ae9-c0d2-4ab5-8646-429c68e7cdfc" },
                    { 351971416, "SharerClaim", "Dba", "8de033fe-d7c2-4375-9e49-d7387fe86153" },
                    { 360875772, "SharerClaim", "Front", "71827788-34d5-458b-b030-99c0fa21dd42" },
                    { 387021760, "SharerClaim", "Lead", "dba21b20-7551-488a-bb08-40f034e0b475" },
                    { 397427697, "SharerClaim", "Lead", "0034b642-85f5-4c06-bb37-a500e288c187" },
                    { 398947107, "SharerClaim", "Back", "c9af9594-c82f-4069-84eb-4d3793d987b9" },
                    { 399835112, "SharerClaim", "Stinky", "8de033fe-d7c2-4375-9e49-d7387fe86153" },
                    { 408382374, "SharerClaim", "Front", "40dee089-43c6-4781-b39c-b320375a0f10" },
                    { 441226546, "SharerClaim", "Lol", "bd552e5c-2adb-4974-aecc-43bfaf14fed9" },
                    { 509122057, "SharerClaim", "Front", "dba21b20-7551-488a-bb08-40f034e0b475" },
                    { 542798954, "SharerClaim", "Dev", "1f809152-0401-4ab0-b80d-e61d046e7e30" },
                    { 557503203, "SharerClaim", "Lead", "2ae52980-9c9e-4391-adf6-0390a3f82084" },
                    { 588645552, "SharerClaim", "Back", "b44a894a-7a09-4543-9f02-cbcfd40cbb8d" },
                    { 603514995, "SharerClaim", "Back", "40dee089-43c6-4781-b39c-b320375a0f10" },
                    { 621192772, "SharerClaim", "Front", "b44a894a-7a09-4543-9f02-cbcfd40cbb8d" },
                    { 627245840, "SharerClaim", "Front", "c1713cd1-099d-4de3-bd55-11192ec724ad" },
                    { 648276513, "SharerClaim", "Back", "8cef2ae9-c0d2-4ab5-8646-429c68e7cdfc" },
                    { 656095921, "SharerClaim", "Dba", "775134f4-446d-4393-a01d-8e52bd08ff78" },
                    { 719022104, "SharerClaim", "Dev", "40dee089-43c6-4781-b39c-b320375a0f10" },
                    { 723473254, "SharerClaim", "Stinky", "3f6a3f23-4c49-4fc9-9c5c-1ec226cf3a4a" },
                    { 734446896, "SharerClaim", "Back", "d23163db-be3e-4fd5-a5da-2f72c768c05a" },
                    { 737894017, "SharerClaim", "Front", "149a9b6c-a589-4a22-82f0-e655a84210ee" },
                    { 740841528, "SharerClaim", "Dba", "52c7c03e-6b9c-43c8-93cd-6d0c38af2520" },
                    { 785581740, "SharerClaim", "Lol", "8cef2ae9-c0d2-4ab5-8646-429c68e7cdfc" },
                    { 831056663, "SharerClaim", "Lead", "3f6a3f23-4c49-4fc9-9c5c-1ec226cf3a4a" },
                    { 836720500, "SharerClaim", "Dba", "67b764c8-35e7-462a-95e6-b39f2291c4fe" },
                    { 882298038, "SharerClaim", "Dba", "7265999d-da9d-461c-a372-a1090a8a62ec" },
                    { 892603135, "SharerClaim", "Front", "52c7c03e-6b9c-43c8-93cd-6d0c38af2520" },
                    { 899302995, "SharerClaim", "Dev", "7265999d-da9d-461c-a372-a1090a8a62ec" },
                    { 926531527, "SharerClaim", "Lol", "8e39a8f9-830a-4cfc-bbc1-462b84c85b71" },
                    { 931760445, "SharerClaim", "Dba", "d23163db-be3e-4fd5-a5da-2f72c768c05a" },
                    { 933042901, "SharerClaim", "Dev", "ca54a240-4d1e-4a8a-ac34-3fad5c5c5fc2" },
                    { 934105501, "SharerClaim", "Back", "71827788-34d5-458b-b030-99c0fa21dd42" },
                    { 935943092, "SharerClaim", "Dev", "ed1e6df8-af68-44cc-80ff-e32937583545" },
                    { 960736301, "SharerClaim", "Lol", "ed1e6df8-af68-44cc-80ff-e32937583545" },
                    { 969461130, "SharerClaim", "Front", "b3023d3d-0a25-43ac-ba10-3815be222227" },
                    { 971969300, "SharerClaim", "Dba", "8cef2ae9-c0d2-4ab5-8646-429c68e7cdfc" },
                    { 973165427, "SharerClaim", "Front", "8021b9a7-dca8-4940-b587-3fb85064c8a1" },
                    { 1010093174, "SharerClaim", "Back", "ed1e6df8-af68-44cc-80ff-e32937583545" },
                    { 1029139120, "SharerClaim", "Dev", "906f6fc5-68ee-431b-be2e-2545682da6bd" },
                    { 1074980351, "SharerClaim", "Front", "67b764c8-35e7-462a-95e6-b39f2291c4fe" },
                    { 1092087515, "SharerClaim", "Dev", "97d4c05f-c0a0-475a-9ba5-7d027d193c60" },
                    { 1094355230, "SharerClaim", "Lead", "149a9b6c-a589-4a22-82f0-e655a84210ee" },
                    { 1108121292, "SharerClaim", "Lead", "52c7c03e-6b9c-43c8-93cd-6d0c38af2520" },
                    { 1113314316, "SharerClaim", "Lol", "ca54a240-4d1e-4a8a-ac34-3fad5c5c5fc2" },
                    { 1131251016, "SharerClaim", "Dba", "2ae52980-9c9e-4391-adf6-0390a3f82084" },
                    { 1135499982, "SharerClaim", "Dev", "b3023d3d-0a25-43ac-ba10-3815be222227" },
                    { 1146553954, "SharerClaim", "Dba", "ed1e6df8-af68-44cc-80ff-e32937583545" },
                    { 1202895920, "SharerClaim", "Back", "bd552e5c-2adb-4974-aecc-43bfaf14fed9" },
                    { 1206697884, "SharerClaim", "Back", "1f809152-0401-4ab0-b80d-e61d046e7e30" },
                    { 1258981171, "SharerClaim", "Dev", "569e6ec9-987b-484d-bfde-b393fed2b933" },
                    { 1267591420, "SharerClaim", "Dba", "b3023d3d-0a25-43ac-ba10-3815be222227" },
                    { 1337468595, "SharerClaim", "Dba", "05d4176e-5516-4263-9561-750e6d07a75b" },
                    { 1346341151, "SharerClaim", "Back", "b3023d3d-0a25-43ac-ba10-3815be222227" },
                    { 1357111178, "SharerClaim", "Lol", "2ae52980-9c9e-4391-adf6-0390a3f82084" },
                    { 1377329691, "SharerClaim", "Lol", "2506ad74-1604-4a0e-bfff-d434b16344ae" },
                    { 1381567465, "SharerClaim", "Lol", "906f6fc5-68ee-431b-be2e-2545682da6bd" },
                    { 1382469265, "SharerClaim", "Front", "775134f4-446d-4393-a01d-8e52bd08ff78" },
                    { 1419443854, "SharerClaim", "Lead", "8cef2ae9-c0d2-4ab5-8646-429c68e7cdfc" },
                    { 1440606044, "SharerClaim", "Dba", "ca54a240-4d1e-4a8a-ac34-3fad5c5c5fc2" },
                    { 1452189078, "SharerClaim", "Dev", "2ae52980-9c9e-4391-adf6-0390a3f82084" },
                    { 1483670485, "SharerClaim", "Lead", "40dee089-43c6-4781-b39c-b320375a0f10" },
                    { 1488795376, "SharerClaim", "Dba", "aef95f03-48d8-4397-b0c3-3b5b09f8375f" },
                    { 1494175272, "SharerClaim", "Dba", "3f6a3f23-4c49-4fc9-9c5c-1ec226cf3a4a" },
                    { 1513763553, "SharerClaim", "Dba", "1f809152-0401-4ab0-b80d-e61d046e7e30" },
                    { 1543335612, "SharerClaim", "Dev", "3f6a3f23-4c49-4fc9-9c5c-1ec226cf3a4a" },
                    { 1556886131, "SharerClaim", "Stinky", "aef95f03-48d8-4397-b0c3-3b5b09f8375f" },
                    { 1584059505, "SharerClaim", "Back", "67b764c8-35e7-462a-95e6-b39f2291c4fe" },
                    { 1604088658, "SharerClaim", "Front", "8e39a8f9-830a-4cfc-bbc1-462b84c85b71" },
                    { 1607538593, "SharerClaim", "Back", "149a9b6c-a589-4a22-82f0-e655a84210ee" },
                    { 1613162362, "SharerClaim", "Dev", "bd552e5c-2adb-4974-aecc-43bfaf14fed9" },
                    { 1623499305, "SharerClaim", "Front", "3f6a3f23-4c49-4fc9-9c5c-1ec226cf3a4a" },
                    { 1660809167, "SharerClaim", "Stinky", "149a9b6c-a589-4a22-82f0-e655a84210ee" },
                    { 1664487711, "SharerClaim", "Lol", "c9af9594-c82f-4069-84eb-4d3793d987b9" },
                    { 1672618307, "SharerClaim", "Lead", "775134f4-446d-4393-a01d-8e52bd08ff78" },
                    { 1685028985, "SharerClaim", "Dev", "dba21b20-7551-488a-bb08-40f034e0b475" },
                    { 1695967758, "SharerClaim", "Stinky", "906f6fc5-68ee-431b-be2e-2545682da6bd" },
                    { 1700253994, "SharerClaim", "Stinky", "71827788-34d5-458b-b030-99c0fa21dd42" },
                    { 1702615242, "SharerClaim", "Front", "2ae52980-9c9e-4391-adf6-0390a3f82084" },
                    { 1707261684, "SharerClaim", "Lol", "3f6a3f23-4c49-4fc9-9c5c-1ec226cf3a4a" },
                    { 1714360514, "SharerClaim", "Back", "2ae52980-9c9e-4391-adf6-0390a3f82084" },
                    { 1724662366, "SharerClaim", "Stinky", "52c7c03e-6b9c-43c8-93cd-6d0c38af2520" },
                    { 1753332339, "SharerClaim", "Lead", "bd552e5c-2adb-4974-aecc-43bfaf14fed9" },
                    { 1757094260, "SharerClaim", "Stinky", "ca54a240-4d1e-4a8a-ac34-3fad5c5c5fc2" },
                    { 1796228221, "SharerClaim", "Lol", "d23163db-be3e-4fd5-a5da-2f72c768c05a" },
                    { 1802908134, "SharerClaim", "Front", "ca54a240-4d1e-4a8a-ac34-3fad5c5c5fc2" },
                    { 1832508832, "SharerClaim", "Dba", "569e6ec9-987b-484d-bfde-b393fed2b933" },
                    { 1840160016, "SharerClaim", "Front", "bd552e5c-2adb-4974-aecc-43bfaf14fed9" },
                    { 1850720950, "SharerClaim", "Front", "1f809152-0401-4ab0-b80d-e61d046e7e30" },
                    { 1854720387, "SharerClaim", "Stinky", "dba21b20-7551-488a-bb08-40f034e0b475" },
                    { 1884352274, "SharerClaim", "Stinky", "d23163db-be3e-4fd5-a5da-2f72c768c05a" },
                    { 1904438428, "SharerClaim", "Dba", "149a9b6c-a589-4a22-82f0-e655a84210ee" },
                    { 1924669843, "SharerClaim", "Lol", "8021b9a7-dca8-4940-b587-3fb85064c8a1" },
                    { 1930583941, "SharerClaim", "Back", "7265999d-da9d-461c-a372-a1090a8a62ec" },
                    { 1985990734, "SharerClaim", "Stinky", "40dee089-43c6-4781-b39c-b320375a0f10" },
                    { 2011242017, "SharerClaim", "Back", "dba21b20-7551-488a-bb08-40f034e0b475" },
                    { 2025765925, "SharerClaim", "Front", "aef95f03-48d8-4397-b0c3-3b5b09f8375f" },
                    { 2044549006, "SharerClaim", "Back", "0034b642-85f5-4c06-bb37-a500e288c187" },
                    { 2081992517, "BossClaim", "BossClaim", "eda12e6b-c0da-4b5c-b5df-accdc0d91847" },
                    { 2092754607, "SharerClaim", "Lead", "1f809152-0401-4ab0-b80d-e61d046e7e30" },
                    { 2099268837, "SharerClaim", "Lol", "775134f4-446d-4393-a01d-8e52bd08ff78" },
                    { 2113021204, "SharerClaim", "Lead", "71827788-34d5-458b-b030-99c0fa21dd42" },
                    { 2114494684, "SharerClaim", "Front", "8de033fe-d7c2-4375-9e49-d7387fe86153" },
                    { 2143496566, "SharerClaim", "Dba", "bd552e5c-2adb-4974-aecc-43bfaf14fed9" },
                    { 2146327657, "SharerClaim", "Lol", "40dee089-43c6-4781-b39c-b320375a0f10" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "0034b642-85f5-4c06-bb37-a500e288c187" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "05d4176e-5516-4263-9561-750e6d07a75b" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "149a9b6c-a589-4a22-82f0-e655a84210ee" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "1f809152-0401-4ab0-b80d-e61d046e7e30" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "2506ad74-1604-4a0e-bfff-d434b16344ae" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "2ae52980-9c9e-4391-adf6-0390a3f82084" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "3f6a3f23-4c49-4fc9-9c5c-1ec226cf3a4a" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "40dee089-43c6-4781-b39c-b320375a0f10" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "52c7c03e-6b9c-43c8-93cd-6d0c38af2520" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "569e6ec9-987b-484d-bfde-b393fed2b933" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "67b764c8-35e7-462a-95e6-b39f2291c4fe" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "71827788-34d5-458b-b030-99c0fa21dd42" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "7265999d-da9d-461c-a372-a1090a8a62ec" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "775134f4-446d-4393-a01d-8e52bd08ff78" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "8021b9a7-dca8-4940-b587-3fb85064c8a1" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "8cef2ae9-c0d2-4ab5-8646-429c68e7cdfc" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "8de033fe-d7c2-4375-9e49-d7387fe86153" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "8e39a8f9-830a-4cfc-bbc1-462b84c85b71" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "906f6fc5-68ee-431b-be2e-2545682da6bd" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "97d4c05f-c0a0-475a-9ba5-7d027d193c60" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "aef95f03-48d8-4397-b0c3-3b5b09f8375f" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "b3023d3d-0a25-43ac-ba10-3815be222227" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "b44a894a-7a09-4543-9f02-cbcfd40cbb8d" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "bd552e5c-2adb-4974-aecc-43bfaf14fed9" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "c1713cd1-099d-4de3-bd55-11192ec724ad" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "c9af9594-c82f-4069-84eb-4d3793d987b9" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "ca54a240-4d1e-4a8a-ac34-3fad5c5c5fc2" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "d23163db-be3e-4fd5-a5da-2f72c768c05a" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "dba21b20-7551-488a-bb08-40f034e0b475" },
                    { "509e6302-eac5-42e3-8ed7-f542f6579487", "ed1e6df8-af68-44cc-80ff-e32937583545" },
                    { "f6ed4a0d-9d62-43dd-8b22-004a142bc227", "eda12e6b-c0da-4b5c-b5df-accdc0d91847" }
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
