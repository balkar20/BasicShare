using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityDb.Migrations
{
    /// <inheritdoc />
    public partial class PooperAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ee72f2d-a070-46c2-9a76-e0f6979e1ea7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37b2d878-0e75-4035-9190-bd8769a7b4eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2a6c7c8-ae62-4dbf-821d-586ad752791f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0f4f8e49-588d-4e73-8889-5efec79b7418", "0aaea01d-7149-4a4e-997c-be32993e8f8a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "54ff59dd-79bb-409a-bd9f-e3b31074f90e", "2d02eb00-cb6d-46aa-98f0-ddc68319e825" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0f4f8e49-588d-4e73-8889-5efec79b7418", "336733a1-5f0b-456e-81af-69713c8da7f7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0f4f8e49-588d-4e73-8889-5efec79b7418", "49a32563-956e-4d07-a79a-fcecfdf10f7e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0f4f8e49-588d-4e73-8889-5efec79b7418", "870e149e-3652-4813-9514-034ea5faea89" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0f4f8e49-588d-4e73-8889-5efec79b7418", "d78f51b5-66ed-4da0-a3f4-4075f8814e42" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f4f8e49-588d-4e73-8889-5efec79b7418");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54ff59dd-79bb-409a-bd9f-e3b31074f90e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0aaea01d-7149-4a4e-997c-be32993e8f8a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d02eb00-cb6d-46aa-98f0-ddc68319e825");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "336733a1-5f0b-456e-81af-69713c8da7f7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49a32563-956e-4d07-a79a-fcecfdf10f7e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "870e149e-3652-4813-9514-034ea5faea89");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d78f51b5-66ed-4da0-a3f4-4075f8814e42");

            migrationBuilder.AddColumn<int>(
                name: "AmountOfPoops",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a52f5f4-fb8e-4d51-99df-2413d38e3f65", null, "Maker", "MAKER" },
                    { "2a86b21c-17d6-4e56-976f-5d58fd41e651", null, "Reviwer", "REVIWER" },
                    { "3dac91f7-4f48-48fb-bd80-9bf473733d78", null, "Administrator", "ADMINISTRATOR" },
                    { "a44d8e85-b0e5-47b1-bc2c-ad9874bacece", null, "Viewer", "VIEWER" },
                    { "c15f1672-1e28-403d-970e-064009ef4c0e", null, "Pooper", "POOPER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AmountOfPoops", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Year" },
                values: new object[,]
                {
                    { "412b7dcd-9cb3-4ee4-98fe-8b545a28acf6", 0, null, "2132b926-2a36-4ded-b249-db1d57f5f738", "NastyaBocharnikova20@mail.ru", true, false, null, "NastyaBocharnikova20@mail.ru", "NastyaBocharnikova", "AQAAAAIAAYagAAAAEG+XwqcaWGbxkzNE6BuOjWE2G2Yroe32Ut46/Sh7Lva1Dq397mDjyHfcEv1iWCQR3Q==", "", true, "95e3df2e-5473-4ee9-8f7c-b051bebad9ff", false, "NastyaBocharnikova", null },
                    { "7b82acbe-8885-4940-aa1b-f1522e32a7b8", 0, null, "aebfb5b7-775b-45ed-a2fb-de7142d48a0d", "SanchoLeaver20@mail.ru", true, false, null, "SanchoLeaver20@mail.ru", "SanchoLeaver", "AQAAAAIAAYagAAAAEBlipiJvgaQda15BsENPR9vNFXLQ1lxLf/NynkG7z14qObsmjcJlxmtCNhFbB50I9A==", "", true, "e4443dd2-036e-4e16-b741-cbb30f406de5", false, "SanchoLeaver", null },
                    { "92469288-59e3-4694-8f5e-7cdc771afa19", 0, null, "199c4071-a799-43c0-94f5-ceb88f13cf7b", "AdrewRojer20@mail.ru", true, false, null, "AdrewRojer20@mail.ru", "AdrewRojer", "AQAAAAIAAYagAAAAELz8D9l8iU2KwiN191Eirx6Uaf7iHXdLgyWr3X2pZMHKYklng+dpLm+wR3WBMi19qg==", "", true, "7d4baa77-c54e-46cd-a6bc-4ced79748777", false, "AdrewRojer", null },
                    { "c9b2ef0e-ea65-41b9-9d10-4957557821b8", 0, null, "7c2e8937-8f15-43af-b61b-18acaf1a1d45", "VladBalkar20@mail.ru", true, false, null, "VladBalkar20@mail.ru", "VladBalkar", "AQAAAAIAAYagAAAAEKvb5q0ct/K6jnmN8AQodUG13HtTkcd+kGxJFFoSucDUTIWuP+yrcwNABjY+UeeiBw==", "", true, "7529c4ad-4c56-47dd-bf27-9d2c73f3463d", false, "VladBalkar", null },
                    { "f7c1f949-b1b4-45d0-bd88-87267d7afbca", 0, null, "85f6af95-5e0d-45db-9d8a-896099881c10", "NastyaKareva20@mail.ru", true, false, null, "NastyaKareva20@mail.ru", "NastyaKareva", "AQAAAAIAAYagAAAAEOvAQmjL+2d0D3TbSvqEsJjk5MAIg8lw+R66b8q4eDzperC4sy+yQS8aqFLFSWl11w==", "", true, "d9777d1e-6ac2-4a1e-8cd3-dc0be3368fbd", false, "NastyaKareva", null },
                    { "fe1e4c24-794d-4943-bf47-047ba7f49d11", 0, null, "6935502a-1830-4f1c-811e-716a225548f8", "VladBlack20@mail.ru", true, false, null, "VladBlack20@mail.ru", "VladBlack", "AQAAAAIAAYagAAAAED4NL6MXAISDXC05NxkRmXqjxS4K3XI/cTdX+EiUmrhzdaaRZzPBuqg/IncciPC9OA==", "", true, "c6298a16-b37f-4856-8718-684755a8940f", false, "VladBlack", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c15f1672-1e28-403d-970e-064009ef4c0e", "412b7dcd-9cb3-4ee4-98fe-8b545a28acf6" },
                    { "c15f1672-1e28-403d-970e-064009ef4c0e", "7b82acbe-8885-4940-aa1b-f1522e32a7b8" },
                    { "c15f1672-1e28-403d-970e-064009ef4c0e", "92469288-59e3-4694-8f5e-7cdc771afa19" },
                    { "3dac91f7-4f48-48fb-bd80-9bf473733d78", "c9b2ef0e-ea65-41b9-9d10-4957557821b8" },
                    { "c15f1672-1e28-403d-970e-064009ef4c0e", "f7c1f949-b1b4-45d0-bd88-87267d7afbca" },
                    { "c15f1672-1e28-403d-970e-064009ef4c0e", "fe1e4c24-794d-4943-bf47-047ba7f49d11" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a52f5f4-fb8e-4d51-99df-2413d38e3f65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a86b21c-17d6-4e56-976f-5d58fd41e651");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a44d8e85-b0e5-47b1-bc2c-ad9874bacece");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c15f1672-1e28-403d-970e-064009ef4c0e", "412b7dcd-9cb3-4ee4-98fe-8b545a28acf6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c15f1672-1e28-403d-970e-064009ef4c0e", "7b82acbe-8885-4940-aa1b-f1522e32a7b8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c15f1672-1e28-403d-970e-064009ef4c0e", "92469288-59e3-4694-8f5e-7cdc771afa19" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3dac91f7-4f48-48fb-bd80-9bf473733d78", "c9b2ef0e-ea65-41b9-9d10-4957557821b8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c15f1672-1e28-403d-970e-064009ef4c0e", "f7c1f949-b1b4-45d0-bd88-87267d7afbca" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c15f1672-1e28-403d-970e-064009ef4c0e", "fe1e4c24-794d-4943-bf47-047ba7f49d11" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3dac91f7-4f48-48fb-bd80-9bf473733d78");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c15f1672-1e28-403d-970e-064009ef4c0e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "412b7dcd-9cb3-4ee4-98fe-8b545a28acf6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b82acbe-8885-4940-aa1b-f1522e32a7b8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92469288-59e3-4694-8f5e-7cdc771afa19");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c9b2ef0e-ea65-41b9-9d10-4957557821b8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f7c1f949-b1b4-45d0-bd88-87267d7afbca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe1e4c24-794d-4943-bf47-047ba7f49d11");

            migrationBuilder.DropColumn(
                name: "AmountOfPoops",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f4f8e49-588d-4e73-8889-5efec79b7418", null, "Pooper", "POOPER" },
                    { "1ee72f2d-a070-46c2-9a76-e0f6979e1ea7", null, "Maker", "MAKER" },
                    { "37b2d878-0e75-4035-9190-bd8769a7b4eb", null, "Reviwer", "REVIWER" },
                    { "54ff59dd-79bb-409a-bd9f-e3b31074f90e", null, "Administrator", "ADMINISTRATOR" },
                    { "d2a6c7c8-ae62-4dbf-821d-586ad752791f", null, "Viewer", "VIEWER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Year" },
                values: new object[,]
                {
                    { "0aaea01d-7149-4a4e-997c-be32993e8f8a", 0, "1b833f2a-c98e-43a1-a33f-1699a9ab7767", "NastyaKareva20@mail.ru", true, false, null, "NastyaKareva20@mail.ru", "NastyaKareva", "AQAAAAIAAYagAAAAEDh/8OJ8RiHClbvsR37RHID5To5ze4oiVf53f+81jLUgw3fmjknUp4Kq/3VSm6WoiA==", "", true, "e0f292c0-7d9e-429d-94a1-7bf952c6d838", false, "NastyaKareva", null },
                    { "2d02eb00-cb6d-46aa-98f0-ddc68319e825", 0, "54a7969c-f1d5-44f4-aaf6-6b31a38f5fc3", "VladBalkar20@mail.ru", true, false, null, "VladBalkar20@mail.ru", "VladBalkar", "AQAAAAIAAYagAAAAEJVXprzl1vA7J79f43/vNK06qll5aCTM5q9uH2wgY9k7YKJVAjNz1XjVvhkaRB81Yw==", "", true, "6d258907-4a04-4ef1-8730-bbb634c50dc5", false, "VladBalkar", null },
                    { "336733a1-5f0b-456e-81af-69713c8da7f7", 0, "214e5233-14e1-4803-a108-37080b915141", "NastyaBocharnikova20@mail.ru", true, false, null, "NastyaBocharnikova20@mail.ru", "NastyaBocharnikova", "AQAAAAIAAYagAAAAENi8tlVRmw9e2pmyEqkYqQzLGLi0GQvOdjFSAf+ah3L2hSuioVC7AWmnRdjbkK6HqQ==", "", true, "b25e79db-d146-41d6-b614-af2a30497926", false, "NastyaBocharnikova", null },
                    { "49a32563-956e-4d07-a79a-fcecfdf10f7e", 0, "92d5f6ed-1af9-4824-8dae-c25f62687117", "SanchoLeaver20@mail.ru", true, false, null, "SanchoLeaver20@mail.ru", "SanchoLeaver", "AQAAAAIAAYagAAAAEOAMmpRjpjw1FdyhfXsAJjB8XnIs2Fc7+Ys5GakJmUrOjud30pdK874IvL/cRz8BIA==", "", true, "db48c8b1-4f00-4758-a6a0-ec76df0cef5b", false, "SanchoLeaver", null },
                    { "870e149e-3652-4813-9514-034ea5faea89", 0, "37b88a68-2004-4a96-af4e-954dc95de541", "VladBlack20@mail.ru", true, false, null, "VladBlack20@mail.ru", "VladBlack", "AQAAAAIAAYagAAAAENc32MbaTatYHX3TolCto4mgnHaeY8BzzQk5Z4z690N0HdiO4bM5KaEnz58Ye3kEEQ==", "", true, "f2bc5bd4-cf21-4309-8319-bdc5a66982f9", false, "VladBlack", null },
                    { "d78f51b5-66ed-4da0-a3f4-4075f8814e42", 0, "81c03264-f4bb-4835-96d1-e6efa942de6a", "AdrewRojer20@mail.ru", true, false, null, "AdrewRojer20@mail.ru", "AdrewRojer", "AQAAAAIAAYagAAAAELqF2z8+6o+xqOw9bjSCInXPtl+wOZifZbby3jlIcBz8uTmj04tQiQrbjQ+RBdhRIA==", "", true, "677ca410-1a21-483c-b21a-67b7c1dbd5e0", false, "AdrewRojer", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0f4f8e49-588d-4e73-8889-5efec79b7418", "0aaea01d-7149-4a4e-997c-be32993e8f8a" },
                    { "54ff59dd-79bb-409a-bd9f-e3b31074f90e", "2d02eb00-cb6d-46aa-98f0-ddc68319e825" },
                    { "0f4f8e49-588d-4e73-8889-5efec79b7418", "336733a1-5f0b-456e-81af-69713c8da7f7" },
                    { "0f4f8e49-588d-4e73-8889-5efec79b7418", "49a32563-956e-4d07-a79a-fcecfdf10f7e" },
                    { "0f4f8e49-588d-4e73-8889-5efec79b7418", "870e149e-3652-4813-9514-034ea5faea89" },
                    { "0f4f8e49-588d-4e73-8889-5efec79b7418", "d78f51b5-66ed-4da0-a3f4-4075f8814e42" }
                });
        }
    }
}
