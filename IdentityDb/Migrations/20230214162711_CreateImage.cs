using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityDb.Migrations
{
    /// <inheritdoc />
    public partial class CreateImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06a331d1-e7bb-448c-8d43-0f8a30b0cb4b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53ea82b4-5d5a-4a68-8231-a2291d057276");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8ff507f-81ba-4a94-9790-0e4a09572169");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "10588fcb-2d64-40ff-8f35-d01f65f070de", "01eefbe1-0f88-4d9d-b3a8-80a00a2212f4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "10588fcb-2d64-40ff-8f35-d01f65f070de", "400b679f-c2c8-4567-9d43-ba4195cd1bfe" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "10588fcb-2d64-40ff-8f35-d01f65f070de", "4e131785-454c-4e20-89e9-e7830a434baf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "10588fcb-2d64-40ff-8f35-d01f65f070de", "de7cae6c-f602-4dd3-802d-76e48456957a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4e8afb2f-0597-4c95-ba9a-c1240a0059a2", "faf27c3e-d598-4215-9e8b-015e5bca9907" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "10588fcb-2d64-40ff-8f35-d01f65f070de", "fd737bec-bb0a-4f97-975b-4f88fd34a3ad" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10588fcb-2d64-40ff-8f35-d01f65f070de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e8afb2f-0597-4c95-ba9a-c1240a0059a2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "01eefbe1-0f88-4d9d-b3a8-80a00a2212f4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "400b679f-c2c8-4567-9d43-ba4195cd1bfe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4e131785-454c-4e20-89e9-e7830a434baf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "de7cae6c-f602-4dd3-802d-76e48456957a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faf27c3e-d598-4215-9e8b-015e5bca9907");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd737bec-bb0a-4f97-975b-4f88fd34a3ad");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "480aaf70-cc75-4c4d-8f57-32199e399025", null, "Pooper", "POOPER" },
                    { "ae32f7d5-e4fd-4825-89ea-5f271277689f", null, "Administrator", "ADMINISTRATOR" },
                    { "bd1ce5b3-e269-452b-a928-beec0c3ec5a5", null, "Reviwer", "REVIWER" },
                    { "c7ed38e6-26f4-4c08-a088-751fd9c33b8c", null, "Maker", "MAKER" },
                    { "fc9a3a4c-bbb7-4acb-99c1-6d7f98483a51", null, "Viewer", "VIEWER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AmountOfPoops", "ConcurrencyStamp", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Year" },
                values: new object[,]
                {
                    { "10802db0-9b25-4944-bfc6-ed10ed5469d5", 0, 0, "413625df-c4ed-4351-a8c5-7b94b0e22c33", "VladBalkar20@mail.ru", true, null, false, null, "VladBalkar20@mail.ru", "VladBalkar", "AQAAAAIAAYagAAAAEGtri29qZKXLdgHl3qKvskwdL/fD2CVOfKangcSMXvjy+e5pVp0QM/UJ5cmvNR/vew==", "", true, "edd85334-90a4-4f43-99c4-35730821bfc6", false, "VladBalkar", null },
                    { "5202afb9-a7aa-4483-82f5-b3ba67eaa918", 0, 0, "025b7631-30ff-41a4-925e-e08919a76aa0", "SanchoLeaver20@mail.ru", true, null, false, null, "SanchoLeaver20@mail.ru", "SanchoLeaver", "AQAAAAIAAYagAAAAEA6/AKomHqQPGgxb+p83TDLefT4elKK7BV3aD0KFmGYgc0w1o3w1aDUBoQJlzK1pCQ==", "", true, "06bf42d0-3b36-4421-b011-f17d8c3bbca8", false, "SanchoLeaver", null },
                    { "847dc853-9d7a-4f1e-b39d-8fb8cdb5ba93", 0, 0, "fa96e24c-62de-4b59-9552-da9c7278f238", "NastyaKareva20@mail.ru", true, null, false, null, "NastyaKareva20@mail.ru", "NastyaKareva", "AQAAAAIAAYagAAAAEF2n0vcTrNki+npkytCNcDHL0c/sM5WVm2THT3dcvSNmLMzc/ldZrU6UYuNxtvr1WA==", "", true, "ee4896b7-b933-4f74-8c9d-24d4a872b983", false, "NastyaKareva", null },
                    { "a672c3d3-c25b-4fac-841a-961ea2141408", 0, 0, "f360edb7-f5c3-4940-b57c-43dd05248f79", "VladBlack20@mail.ru", true, null, false, null, "VladBlack20@mail.ru", "VladBlack", "AQAAAAIAAYagAAAAEAIU5nbqg9iSf1wAHn5CE5EvSbtYPdOrS+SRyizDc16JOZVRdamCFW1feXkEqvl1ZA==", "", true, "2837794d-de02-4275-9aac-0e4d5cd7f606", false, "VladBlack", null },
                    { "cbd70375-0612-482c-9c91-75502c647424", 0, 0, "cefaed7a-8ac0-4c9d-81ed-284a66087817", "NastyaBocharnikova20@mail.ru", true, null, false, null, "NastyaBocharnikova20@mail.ru", "NastyaBocharnikova", "AQAAAAIAAYagAAAAEOCHoaJ5HHDa0BnGVMSYaNBR5fGJtX1kuryh6EI3LDik6br7w7/R5hasB1vRQV0XfQ==", "", true, "d62ff0a8-194b-4c62-b56b-5a3fe12e53c0", false, "NastyaBocharnikova", null },
                    { "ea82de2a-4659-4740-af7f-d0222055c45c", 0, 0, "89a76b94-e44f-4207-a1d3-7751eeec6ff5", "AdrewRojer20@mail.ru", true, null, false, null, "AdrewRojer20@mail.ru", "AdrewRojer", "AQAAAAIAAYagAAAAEKBE1tCJrR5TFGLGeYx8JiAao6hejXhACKTAGJObeXLkgfZdGpCoTNE0DlrBTpqCZg==", "", true, "422c3951-2c32-4ca8-b967-241d47ad027f", false, "AdrewRojer", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ae32f7d5-e4fd-4825-89ea-5f271277689f", "10802db0-9b25-4944-bfc6-ed10ed5469d5" },
                    { "480aaf70-cc75-4c4d-8f57-32199e399025", "5202afb9-a7aa-4483-82f5-b3ba67eaa918" },
                    { "480aaf70-cc75-4c4d-8f57-32199e399025", "847dc853-9d7a-4f1e-b39d-8fb8cdb5ba93" },
                    { "480aaf70-cc75-4c4d-8f57-32199e399025", "a672c3d3-c25b-4fac-841a-961ea2141408" },
                    { "480aaf70-cc75-4c4d-8f57-32199e399025", "cbd70375-0612-482c-9c91-75502c647424" },
                    { "480aaf70-cc75-4c4d-8f57-32199e399025", "ea82de2a-4659-4740-af7f-d0222055c45c" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd1ce5b3-e269-452b-a928-beec0c3ec5a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7ed38e6-26f4-4c08-a088-751fd9c33b8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc9a3a4c-bbb7-4acb-99c1-6d7f98483a51");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ae32f7d5-e4fd-4825-89ea-5f271277689f", "10802db0-9b25-4944-bfc6-ed10ed5469d5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "480aaf70-cc75-4c4d-8f57-32199e399025", "5202afb9-a7aa-4483-82f5-b3ba67eaa918" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "480aaf70-cc75-4c4d-8f57-32199e399025", "847dc853-9d7a-4f1e-b39d-8fb8cdb5ba93" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "480aaf70-cc75-4c4d-8f57-32199e399025", "a672c3d3-c25b-4fac-841a-961ea2141408" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "480aaf70-cc75-4c4d-8f57-32199e399025", "cbd70375-0612-482c-9c91-75502c647424" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "480aaf70-cc75-4c4d-8f57-32199e399025", "ea82de2a-4659-4740-af7f-d0222055c45c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "480aaf70-cc75-4c4d-8f57-32199e399025");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae32f7d5-e4fd-4825-89ea-5f271277689f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10802db0-9b25-4944-bfc6-ed10ed5469d5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5202afb9-a7aa-4483-82f5-b3ba67eaa918");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "847dc853-9d7a-4f1e-b39d-8fb8cdb5ba93");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a672c3d3-c25b-4fac-841a-961ea2141408");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cbd70375-0612-482c-9c91-75502c647424");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ea82de2a-4659-4740-af7f-d0222055c45c");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06a331d1-e7bb-448c-8d43-0f8a30b0cb4b", null, "Reviwer", "REVIWER" },
                    { "10588fcb-2d64-40ff-8f35-d01f65f070de", null, "Pooper", "POOPER" },
                    { "4e8afb2f-0597-4c95-ba9a-c1240a0059a2", null, "Administrator", "ADMINISTRATOR" },
                    { "53ea82b4-5d5a-4a68-8231-a2291d057276", null, "Maker", "MAKER" },
                    { "e8ff507f-81ba-4a94-9790-0e4a09572169", null, "Viewer", "VIEWER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AmountOfPoops", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Year" },
                values: new object[,]
                {
                    { "01eefbe1-0f88-4d9d-b3a8-80a00a2212f4", 0, 0, "b25d36af-322a-47da-a226-3361715d4522", "NastyaKareva20@mail.ru", true, false, null, "NastyaKareva20@mail.ru", "NastyaKareva", "AQAAAAIAAYagAAAAEMa1ilIFmhkAL0LzEbHMtTCpfDR6TpP+3vQ11T0vEPL3OUSeRgu7bJAhrbnZaZMK0A==", "", true, "5b4f9fec-c36d-476f-8980-16fc430429ff", false, "NastyaKareva", null },
                    { "400b679f-c2c8-4567-9d43-ba4195cd1bfe", 0, 0, "0d46ed8e-2d58-4439-8571-c6f1c3ac9f86", "NastyaBocharnikova20@mail.ru", true, false, null, "NastyaBocharnikova20@mail.ru", "NastyaBocharnikova", "AQAAAAIAAYagAAAAEJD2aIfH7NsXINTSmoOjcGt95hHY6IX6htymC+BwHaPjpAXszJ2xgcaWj15qrO0C9A==", "", true, "2995208d-5b79-4b01-a372-80e60a59172c", false, "NastyaBocharnikova", null },
                    { "4e131785-454c-4e20-89e9-e7830a434baf", 0, 0, "c0b25a42-0f20-45cc-b540-0297a7072a7a", "SanchoLeaver20@mail.ru", true, false, null, "SanchoLeaver20@mail.ru", "SanchoLeaver", "AQAAAAIAAYagAAAAEBcjvxwTBp6/LLx4CR+qFxmXWS/rxRDPRI4Vf4Mpjx1CtRdqubcbvhE26SCHMXvUWA==", "", true, "01e6c1dc-adea-4270-bdd6-ffcdfbecbcf1", false, "SanchoLeaver", null },
                    { "de7cae6c-f602-4dd3-802d-76e48456957a", 0, 0, "0ef16730-721a-4106-bbe6-f7d600eb4db4", "VladBlack20@mail.ru", true, false, null, "VladBlack20@mail.ru", "VladBlack", "AQAAAAIAAYagAAAAEFydVXew/lUrBMUm1cX+pXmUZRtnCuENb/ETG4gilgqi7HtuggNOzHBMBzah8kyjyw==", "", true, "df45db37-7345-460c-8dd9-8c98942bc2a2", false, "VladBlack", null },
                    { "faf27c3e-d598-4215-9e8b-015e5bca9907", 0, 0, "1037eb36-cb46-4e54-bb83-5ce1af400a01", "VladBalkar20@mail.ru", true, false, null, "VladBalkar20@mail.ru", "VladBalkar", "AQAAAAIAAYagAAAAEOEr6avF3dhQEx4jw9n14wDs9sL93RQ8doEGXiJjRNPbDKhF1wCdf4jjETiB/W6OMQ==", "", true, "12d65610-0eff-4b0b-82fb-819829828d31", false, "VladBalkar", null },
                    { "fd737bec-bb0a-4f97-975b-4f88fd34a3ad", 0, 0, "2092b347-0fea-4b69-8c08-377b1569687b", "AdrewRojer20@mail.ru", true, false, null, "AdrewRojer20@mail.ru", "AdrewRojer", "AQAAAAIAAYagAAAAENtR0j8kudtA5M0nuZhrOCbjtEexnuDtV9Kd4OfjlfuX1ZWsru01Sn704hFyAFinDg==", "", true, "9409818e-85c7-4169-85de-fe341e04f19d", false, "AdrewRojer", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "10588fcb-2d64-40ff-8f35-d01f65f070de", "01eefbe1-0f88-4d9d-b3a8-80a00a2212f4" },
                    { "10588fcb-2d64-40ff-8f35-d01f65f070de", "400b679f-c2c8-4567-9d43-ba4195cd1bfe" },
                    { "10588fcb-2d64-40ff-8f35-d01f65f070de", "4e131785-454c-4e20-89e9-e7830a434baf" },
                    { "10588fcb-2d64-40ff-8f35-d01f65f070de", "de7cae6c-f602-4dd3-802d-76e48456957a" },
                    { "4e8afb2f-0597-4c95-ba9a-c1240a0059a2", "faf27c3e-d598-4215-9e8b-015e5bca9907" },
                    { "10588fcb-2d64-40ff-8f35-d01f65f070de", "fd737bec-bb0a-4f97-975b-4f88fd34a3ad" }
                });
        }
    }
}
