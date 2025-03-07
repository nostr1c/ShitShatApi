﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShitChat.Infrastructure.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250120120153_seedconnectionTest")]
    partial class seedconnectionTest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.Property<Guid>("GroupsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("GroupsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UserGroups", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("api.Data.Models.Connection", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Accepted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "created_at");

                    b.Property<string>("FriendId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("FriendId");

                    b.HasIndex("UserId");

                    b.ToTable("Connections");

                    b.HasData(
                        new
                        {
                            id = new Guid("dcdf519b-70a5-448a-8599-515d9da297d9"),
                            Accepted = true,
                            CreatedAt = new DateTime(2024, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FriendId = "a1f2d713-1234-43fa-9c8e-65fa6ee39244",
                            UserId = "bb29d713-9414-43fa-9c8e-65fa6ee39243"
                        });
                });

            modelBuilder.Entity("api.Data.Models.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("api.Data.Models.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("api.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("AvatarUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "bb29d713-9414-43fa-9c8e-65fa6ee39243",
                            AccessFailedCount = 0,
                            AvatarUri = "a2138670-ffb4-466c-b40c-44dde76566ed.jpg",
                            CreatedAt = new DateOnly(2025, 1, 20),
                            Email = "alice.smith@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ALICE.SMITH@EXAMPLE.COM",
                            NormalizedUserName = "ALICE123",
                            PasswordHash = "AQAAAAIAAYagAAAAEG719JW0JH1H9VQgj8uzgJ4HLJ+/2qP7NjjLeDMIku1+rtQT16BvU3uracoab0E0Gg==",
                            PhoneNumberConfirmed = false,
                            RefreshToken = "exampletoken1",
                            RefreshTokenExpiryTime = new DateTime(2024, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "alice123"
                        },
                        new
                        {
                            Id = "a1f2d713-1234-43fa-9c8e-65fa6ee39244",
                            AccessFailedCount = 0,
                            AvatarUri = "a2138670-ffb4-466c-b40c-44dde76566ed.jpg",
                            CreatedAt = new DateOnly(2025, 1, 20),
                            Email = "bob.jones@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "BOB.JONES@EXAMPLE.COM",
                            NormalizedUserName = "BOBLORD1337",
                            PasswordHash = "AQAAAAIAAYagAAAAEG719JW0JH1H9VQgj8uzgJ4HLJ+/2qP7NjjLeDMIku1+rtQT16BvU3uracoab0E0Gg==",
                            PhoneNumberConfirmed = false,
                            RefreshToken = "exampletoken1",
                            RefreshTokenExpiryTime = new DateTime(2024, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "BobLord1337"
                        },
                        new
                        {
                            Id = "c1f3d713-5678-43fa-9c8e-65fa6ee39245",
                            AccessFailedCount = 0,
                            AvatarUri = "a2138670-ffb4-466c-b40c-44dde76566ed.jpg",
                            CreatedAt = new DateOnly(2025, 1, 20),
                            Email = "carla.davis@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "CARLA.DAVIS@EXAMPLE.COM",
                            NormalizedUserName = "CARLIS",
                            PasswordHash = "AQAAAAIAAYagAAAAEG719JW0JH1H9VQgj8uzgJ4HLJ+/2qP7NjjLeDMIku1+rtQT16BvU3uracoab0E0Gg==",
                            PhoneNumberConfirmed = false,
                            RefreshToken = "exampletoken1",
                            RefreshTokenExpiryTime = new DateTime(2024, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "Carlis"
                        },
                        new
                        {
                            Id = "d1f4d713-9101-43fa-9c8e-65fa6ee39246",
                            AccessFailedCount = 0,
                            AvatarUri = "a2138670-ffb4-466c-b40c-44dde76566ed.jpg",
                            CreatedAt = new DateOnly(2025, 1, 20),
                            Email = "david.lee@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "DAVID.LEE@EXAMPLE.COM",
                            NormalizedUserName = "DAVIDLEE",
                            PasswordHash = "AQAAAAIAAYagAAAAEG719JW0JH1H9VQgj8uzgJ4HLJ+/2qP7NjjLeDMIku1+rtQT16BvU3uracoab0E0Gg==",
                            PhoneNumberConfirmed = false,
                            RefreshToken = "exampletoken1",
                            RefreshTokenExpiryTime = new DateTime(2024, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "DavidLee"
                        },
                        new
                        {
                            Id = "e1f5d713-1122-43fa-9c8e-65fa6ee39247",
                            AccessFailedCount = 0,
                            AvatarUri = "a2138670-ffb4-466c-b40c-44dde76566ed.jpg",
                            CreatedAt = new DateOnly(2025, 1, 20),
                            Email = "emily.white@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "EMILY.WHITE@EXAMPLE.COM",
                            NormalizedUserName = "EMILYCOOL",
                            PasswordHash = "AQAAAAIAAYagAAAAEG719JW0JH1H9VQgj8uzgJ4HLJ+/2qP7NjjLeDMIku1+rtQT16BvU3uracoab0E0Gg==",
                            PhoneNumberConfirmed = false,
                            RefreshToken = "exampletoken1",
                            RefreshTokenExpiryTime = new DateTime(2024, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "EmilyCool"
                        },
                        new
                        {
                            Id = "f1f6d713-3344-43fa-9c8e-65fa6ee39248",
                            AccessFailedCount = 0,
                            AvatarUri = "a2138670-ffb4-466c-b40c-44dde76566ed.jpg",
                            CreatedAt = new DateOnly(2025, 1, 20),
                            Email = "frank.hall@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "FRANK.HALL@EXAMPLE.COM",
                            NormalizedUserName = "FRANKTHEMAN",
                            PasswordHash = "AQAAAAIAAYagAAAAEG719JW0JH1H9VQgj8uzgJ4HLJ+/2qP7NjjLeDMIku1+rtQT16BvU3uracoab0E0Gg==",
                            PhoneNumberConfirmed = false,
                            RefreshToken = "exampletoken1",
                            RefreshTokenExpiryTime = new DateTime(2024, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "FrankTheMan"
                        });
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.HasOne("api.Data.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("api.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("api.Data.Models.User", null)
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

                    b.HasOne("api.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("api.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api.Data.Models.Connection", b =>
                {
                    b.HasOne("api.Data.Models.User", "friend")
                        .WithMany()
                        .HasForeignKey("FriendId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("api.Data.Models.User", "user")
                        .WithMany("Connections")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("friend");

                    b.Navigation("user");
                });

            modelBuilder.Entity("api.Data.Models.Group", b =>
                {
                    b.HasOne("api.Data.Models.User", "Owner")
                        .WithMany("OwnedGroups")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("api.Data.Models.Message", b =>
                {
                    b.HasOne("api.Data.Models.Group", "Group")
                        .WithMany("Messages")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("api.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Data.Models.Group", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("api.Data.Models.User", b =>
                {
                    b.Navigation("Connections");

                    b.Navigation("OwnedGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
