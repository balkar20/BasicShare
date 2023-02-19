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
                    AmountOfPoops = table.Column<int>(type: "integer", nullable: false),
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
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true)
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
                    UserEntityId = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
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
                    { "06a331d1-e7bb-448c-8d43-0f8a30b0cb4b", null, "Reviwer", "REVIWER" },
                    { "10588fcb-2d64-40ff-8f35-d01f65f070de", null, "Pooper", "POOPER" },
                    { "4e8afb2f-0597-4c95-ba9a-c1240a0059a2", null, "Administrator", "ADMINISTRATOR" },
                    { "53ea82b4-5d5a-4a68-8231-a2291d057276", null, "Maker", "MAKER" },
                    { "e8ff507f-81ba-4a94-9790-0e4a09572169", null, "Viewer", "VIEWER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AmountOfPoops", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Year", "Image" },
                values: new object[,]
                {
                    { "01eefbe1-0f88-4d9d-b3a8-80a00a2212f4", 0, 0, "b25d36af-322a-47da-a226-3361715d4522", "NastyaKareva20@mail.ru", true, false, null, "NastyaKareva20@mail.ru", "NastyaKareva", "AQAAAAIAAYagAAAAEMa1ilIFmhkAL0LzEbHMtTCpfDR6TpP+3vQ11T0vEPL3OUSeRgu7bJAhrbnZaZMK0A==", "", true, "5b4f9fec-c36d-476f-8980-16fc430429ff", false, "NastyaKareva", null, null },
                    { "400b679f-c2c8-4567-9d43-ba4195cd1bfe", 0, 0, "0d46ed8e-2d58-4439-8571-c6f1c3ac9f86", "NastyaBocharnikova20@mail.ru", true, false, null, "NastyaBocharnikova20@mail.ru", "NastyaBocharnikova", "AQAAAAIAAYagAAAAEJD2aIfH7NsXINTSmoOjcGt95hHY6IX6htymC+BwHaPjpAXszJ2xgcaWj15qrO0C9A==", "", true, "2995208d-5b79-4b01-a372-80e60a59172c", false, "NastyaBocharnikova", null, null },
                    { "4e131785-454c-4e20-89e9-e7830a434baf", 0, 0, "c0b25a42-0f20-45cc-b540-0297a7072a7a", "SanchoLeaver20@mail.ru", true, false, null, "SanchoLeaver20@mail.ru", "SanchoLeaver", "AQAAAAIAAYagAAAAEBcjvxwTBp6/LLx4CR+qFxmXWS/rxRDPRI4Vf4Mpjx1CtRdqubcbvhE26SCHMXvUWA==", "", true, "01e6c1dc-adea-4270-bdd6-ffcdfbecbcf1", false, "SanchoLeaver", null, null },
                    { "de7cae6c-f602-4dd3-802d-76e48456957a", 0, 0, "0ef16730-721a-4106-bbe6-f7d600eb4db4", "VladBlack20@mail.ru", true, false, null, "VladBlack20@mail.ru", "VladBlack", "AQAAAAIAAYagAAAAEFydVXew/lUrBMUm1cX+pXmUZRtnCuENb/ETG4gilgqi7HtuggNOzHBMBzah8kyjyw==", "", true, "df45db37-7345-460c-8dd9-8c98942bc2a2", false, "VladBlack", null, null },
                    { "faf27c3e-d598-4215-9e8b-015e5bca9907", 0, 0, "1037eb36-cb46-4e54-bb83-5ce1af400a01", "VladBalkar20@mail.ru", true, false, null, "VladBalkar20@mail.ru", "VladBalkar", "AQAAAAIAAYagAAAAEOEr6avF3dhQEx4jw9n14wDs9sL93RQ8doEGXiJjRNPbDKhF1wCdf4jjETiB/W6OMQ==", "", true, "12d65610-0eff-4b0b-82fb-819829828d31", false, "VladBalkar", null, null },
                    { "fd737bec-bb0a-4f97-975b-4f88fd34a3ad", 0, 0, "2092b347-0fea-4b69-8c08-377b1569687b", "AdrewRojer20@mail.ru", true, false, null, "AdrewRojer20@mail.ru", "AdrewRojer", "AQAAAAIAAYagAAAAENtR0j8kudtA5M0nuZhrOCbjtEexnuDtV9Kd4OfjlfuX1ZWsru01Sn704hFyAFinDg==", "", true, "9409818e-85c7-4169-85de-fe341e04f19d", false, "AdrewRojer", null, null }
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
