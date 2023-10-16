﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserTesting.DAL.Data;

#nullable disable

namespace UserTesting.DAL.Migrations
{
    [DbContext(typeof(UserTestingDbContext))]
    partial class UserTestingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.HasData(
                        new
                        {
                            Id = "d96d22fd-fbe0-4ba1-a8d0-7f076c3e3edd",
                            ConcurrencyStamp = "d96d22fd-fbe0-4ba1-a8d0-7f076c3e3edd",
                            Name = "User",
                            NormalizedName = "USER"
                        });
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

                    b.HasData(
                        new
                        {
                            UserId = "11bac029-c18b-40dd-baca-2854e731149f",
                            RoleId = "d96d22fd-fbe0-4ba1-a8d0-7f076c3e3edd"
                        },
                        new
                        {
                            UserId = "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9",
                            RoleId = "d96d22fd-fbe0-4ba1-a8d0-7f076c3e3edd"
                        });
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

            modelBuilder.Entity("UserTesting.DAL.Entities.Test", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Questions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tests");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ba4dfdda-e505-402e-8be2-d2c619974c9e"),
                            Description = "This is Test 1",
                            Name = "Test 1",
                            Questions = "[{\"Number\":1,\"Text\":\"Question 1\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":2,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":1,\"Text\":\"Option 1\"}},{\"Number\":2,\"Text\":\"Question 2\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":2,\"Text\":\"Option 2\"}},{\"Number\":3,\"Text\":\"Question 3\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":3,\"Text\":\"Option 3\"}}]"
                        },
                        new
                        {
                            Id = new Guid("2cbae21d-0651-4609-b77c-a0d69af10349"),
                            Description = "This is Test 2",
                            Name = "Test 2",
                            Questions = "[{\"Number\":1,\"Text\":\"Question 1\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":2,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":1,\"Text\":\"Option 1\"}},{\"Number\":2,\"Text\":\"Question 2\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":2,\"Text\":\"Option 2\"}},{\"Number\":3,\"Text\":\"Question 3\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":3,\"Text\":\"Option 3\"}}]"
                        },
                        new
                        {
                            Id = new Guid("591928f1-0e0a-4e7b-8b9d-e5c7a7791974"),
                            Description = "This is Test 3",
                            Name = "Test 3",
                            Questions = "[{\"Number\":1,\"Text\":\"Question 1\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":2,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":1,\"Text\":\"Option 1\"}},{\"Number\":2,\"Text\":\"Question 2\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":2,\"Text\":\"Option 2\"}},{\"Number\":3,\"Text\":\"Question 3\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":3,\"Text\":\"Option 3\"}}]"
                        },
                        new
                        {
                            Id = new Guid("0ccda22e-372a-48ef-afc6-9dc8b41007e1"),
                            Description = "This is Test 4",
                            Name = "Test 4",
                            Questions = "[{\"Number\":1,\"Text\":\"Question 1\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":2,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":1,\"Text\":\"Option 1\"}},{\"Number\":2,\"Text\":\"Question 2\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":2,\"Text\":\"Option 2\"}},{\"Number\":3,\"Text\":\"Question 3\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":3,\"Text\":\"Option 3\"}}]"
                        });
                });

            modelBuilder.Entity("UserTesting.DAL.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

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
                            Id = "11bac029-c18b-40dd-baca-2854e731149f",
                            ConcurrencyStamp = "4fbf0bb8-3c87-4acb-a00b-33e465ed0e29",
                            Email = "user1@example.com",
                            NormalizedEmail = "USER1@EXAMPLE.COM",
                            NormalizedUserName = "USER1",
                            PasswordHash = "AQAAAAIAAYagAAAAEFwoXJ2eiWC6CS4PKyE2reIJ+2KCoXdFxQxi+ka6xE6t4AqlfAzsJhKo2NR8s8Qmxg==",
                            SecurityStamp = "43ce0aa7-2ac0-440a-9bbb-135969d46a96",
                            UserName = "User1"
                        },
                        new
                        {
                            Id = "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9",
                            ConcurrencyStamp = "1152b097-5402-4645-a3c4-6389d8dc1d96",
                            Email = "user2@example.com",
                            NormalizedEmail = "USER2@EXAMPLE.COM",
                            NormalizedUserName = "USER2",
                            PasswordHash = "AQAAAAIAAYagAAAAEFW2MKxOHy6jXZfFd8Y8P9LOkYoCDvRaQKhLovcbNhRILaMJjMaRRr0wPZnnHM1ObQ==",
                            SecurityStamp = "6c748b18-49c6-4e32-897d-d40eb83feb06",
                            UserName = "User2"
                        });
                });

            modelBuilder.Entity("UserTesting.DAL.Entities.UserTest", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("TestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Mark")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<bool>("Passed")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "TestId");

                    b.HasIndex("TestId");

                    b.ToTable("UserTests");

                    b.HasData(
                        new
                        {
                            UserId = "11bac029-c18b-40dd-baca-2854e731149f",
                            TestId = new Guid("ba4dfdda-e505-402e-8be2-d2c619974c9e"),
                            Passed = false
                        },
                        new
                        {
                            UserId = "11bac029-c18b-40dd-baca-2854e731149f",
                            TestId = new Guid("2cbae21d-0651-4609-b77c-a0d69af10349"),
                            Passed = false
                        },
                        new
                        {
                            UserId = "11bac029-c18b-40dd-baca-2854e731149f",
                            TestId = new Guid("591928f1-0e0a-4e7b-8b9d-e5c7a7791974"),
                            Passed = false
                        },
                        new
                        {
                            UserId = "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9",
                            TestId = new Guid("591928f1-0e0a-4e7b-8b9d-e5c7a7791974"),
                            Passed = false
                        },
                        new
                        {
                            UserId = "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9",
                            TestId = new Guid("0ccda22e-372a-48ef-afc6-9dc8b41007e1"),
                            Passed = false
                        });
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
                    b.HasOne("UserTesting.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("UserTesting.DAL.Entities.User", null)
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

                    b.HasOne("UserTesting.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("UserTesting.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserTesting.DAL.Entities.UserTest", b =>
                {
                    b.HasOne("UserTesting.DAL.Entities.Test", "Test")
                        .WithMany("UserTests")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserTesting.DAL.Entities.User", "User")
                        .WithMany("UserTests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserTesting.DAL.Entities.Test", b =>
                {
                    b.Navigation("UserTests");
                });

            modelBuilder.Entity("UserTesting.DAL.Entities.User", b =>
                {
                    b.Navigation("UserTests");
                });
#pragma warning restore 612, 618
        }
    }
}
