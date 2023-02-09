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
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
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
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
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
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    AmountOfPoops = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false),
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
