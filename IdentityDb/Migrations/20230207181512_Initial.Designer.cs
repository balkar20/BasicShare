﻿// <auto-generated />
using System;
using Data.IdentityDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IdentityDb.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230207181512_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Auh.Entities.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int?>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2d02eb00-cb6d-46aa-98f0-ddc68319e825",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "54a7969c-f1d5-44f4-aaf6-6b31a38f5fc3",
                            Email = "VladBalkar20@mail.ru",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "VladBalkar20@mail.ru",
                            NormalizedUserName = "VladBalkar",
                            PasswordHash = "AQAAAAIAAYagAAAAEJVXprzl1vA7J79f43/vNK06qll5aCTM5q9uH2wgY9k7YKJVAjNz1XjVvhkaRB81Yw==",
                            PhoneNumber = "",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "6d258907-4a04-4ef1-8730-bbb634c50dc5",
                            TwoFactorEnabled = false,
                            UserName = "VladBalkar"
                        },
                        new
                        {
                            Id = "870e149e-3652-4813-9514-034ea5faea89",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "37b88a68-2004-4a96-af4e-954dc95de541",
                            Email = "VladBlack20@mail.ru",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "VladBlack20@mail.ru",
                            NormalizedUserName = "VladBlack",
                            PasswordHash = "AQAAAAIAAYagAAAAENc32MbaTatYHX3TolCto4mgnHaeY8BzzQk5Z4z690N0HdiO4bM5KaEnz58Ye3kEEQ==",
                            PhoneNumber = "",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "f2bc5bd4-cf21-4309-8319-bdc5a66982f9",
                            TwoFactorEnabled = false,
                            UserName = "VladBlack"
                        },
                        new
                        {
                            Id = "0aaea01d-7149-4a4e-997c-be32993e8f8a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1b833f2a-c98e-43a1-a33f-1699a9ab7767",
                            Email = "NastyaKareva20@mail.ru",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "NastyaKareva20@mail.ru",
                            NormalizedUserName = "NastyaKareva",
                            PasswordHash = "AQAAAAIAAYagAAAAEDh/8OJ8RiHClbvsR37RHID5To5ze4oiVf53f+81jLUgw3fmjknUp4Kq/3VSm6WoiA==",
                            PhoneNumber = "",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "e0f292c0-7d9e-429d-94a1-7bf952c6d838",
                            TwoFactorEnabled = false,
                            UserName = "NastyaKareva"
                        },
                        new
                        {
                            Id = "336733a1-5f0b-456e-81af-69713c8da7f7",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "214e5233-14e1-4803-a108-37080b915141",
                            Email = "NastyaBocharnikova20@mail.ru",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "NastyaBocharnikova20@mail.ru",
                            NormalizedUserName = "NastyaBocharnikova",
                            PasswordHash = "AQAAAAIAAYagAAAAENi8tlVRmw9e2pmyEqkYqQzLGLi0GQvOdjFSAf+ah3L2hSuioVC7AWmnRdjbkK6HqQ==",
                            PhoneNumber = "",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "b25e79db-d146-41d6-b614-af2a30497926",
                            TwoFactorEnabled = false,
                            UserName = "NastyaBocharnikova"
                        },
                        new
                        {
                            Id = "d78f51b5-66ed-4da0-a3f4-4075f8814e42",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "81c03264-f4bb-4835-96d1-e6efa942de6a",
                            Email = "AdrewRojer20@mail.ru",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "AdrewRojer20@mail.ru",
                            NormalizedUserName = "AdrewRojer",
                            PasswordHash = "AQAAAAIAAYagAAAAELqF2z8+6o+xqOw9bjSCInXPtl+wOZifZbby3jlIcBz8uTmj04tQiQrbjQ+RBdhRIA==",
                            PhoneNumber = "",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "677ca410-1a21-483c-b21a-67b7c1dbd5e0",
                            TwoFactorEnabled = false,
                            UserName = "AdrewRojer"
                        },
                        new
                        {
                            Id = "49a32563-956e-4d07-a79a-fcecfdf10f7e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "92d5f6ed-1af9-4824-8dae-c25f62687117",
                            Email = "SanchoLeaver20@mail.ru",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "SanchoLeaver20@mail.ru",
                            NormalizedUserName = "SanchoLeaver",
                            PasswordHash = "AQAAAAIAAYagAAAAEOAMmpRjpjw1FdyhfXsAJjB8XnIs2Fc7+Ys5GakJmUrOjud30pdK874IvL/cRz8BIA==",
                            PhoneNumber = "",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "db48c8b1-4f00-4758-a6a0-ec76df0cef5b",
                            TwoFactorEnabled = false,
                            UserName = "SanchoLeaver"
                        });
                });

            modelBuilder.Entity("Core.Base.DataBase.Entities.PooperEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int?>("AmountOfPoops")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("UserEntityId")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("Poopers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "54ff59dd-79bb-409a-bd9f-e3b31074f90e",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "d2a6c7c8-ae62-4dbf-821d-586ad752791f",
                            Name = "Viewer",
                            NormalizedName = "VIEWER"
                        },
                        new
                        {
                            Id = "0f4f8e49-588d-4e73-8889-5efec79b7418",
                            Name = "Pooper",
                            NormalizedName = "POOPER"
                        },
                        new
                        {
                            Id = "37b2d878-0e75-4035-9190-bd8769a7b4eb",
                            Name = "Reviwer",
                            NormalizedName = "REVIWER"
                        },
                        new
                        {
                            Id = "1ee72f2d-a070-46c2-9a76-e0f6979e1ea7",
                            Name = "Maker",
                            NormalizedName = "MAKER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "2d02eb00-cb6d-46aa-98f0-ddc68319e825",
                            RoleId = "54ff59dd-79bb-409a-bd9f-e3b31074f90e"
                        },
                        new
                        {
                            UserId = "870e149e-3652-4813-9514-034ea5faea89",
                            RoleId = "0f4f8e49-588d-4e73-8889-5efec79b7418"
                        },
                        new
                        {
                            UserId = "0aaea01d-7149-4a4e-997c-be32993e8f8a",
                            RoleId = "0f4f8e49-588d-4e73-8889-5efec79b7418"
                        },
                        new
                        {
                            UserId = "336733a1-5f0b-456e-81af-69713c8da7f7",
                            RoleId = "0f4f8e49-588d-4e73-8889-5efec79b7418"
                        },
                        new
                        {
                            UserId = "d78f51b5-66ed-4da0-a3f4-4075f8814e42",
                            RoleId = "0f4f8e49-588d-4e73-8889-5efec79b7418"
                        },
                        new
                        {
                            UserId = "49a32563-956e-4d07-a79a-fcecfdf10f7e",
                            RoleId = "0f4f8e49-588d-4e73-8889-5efec79b7418"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Core.Base.DataBase.Entities.PooperEntity", b =>
                {
                    b.HasOne("Core.Auh.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserEntityId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Core.Auh.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Core.Auh.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Auh.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Core.Auh.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
