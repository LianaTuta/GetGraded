﻿// <auto-generated />
using System;
using GetGraded.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GetGraded.Migrations.Migrations
{
    [DbContext(typeof(GetGradedContext))]
    [Migration("20240530084439_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GetGraded.Models.Models.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DeadLine")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MinunumPassingScore")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UniversityYearId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UniversityYearId");

                    b.ToTable("Assignment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeadLine = new DateTime(2024, 6, 18, 12, 30, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 1,
                            Description = "Write a research paper on a topic of your choice",
                            MinunumPassingScore = 0,
                            Name = "Research Paper",
                            UniversityYearId = 1
                        },
                        new
                        {
                            Id = 2,
                            DeadLine = new DateTime(2024, 6, 17, 17, 30, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 1,
                            Description = "Complete the math problem set covering chapters 1-5",
                            MinunumPassingScore = 0,
                            Name = "Math Problem Set",
                            UniversityYearId = 2
                        },
                        new
                        {
                            Id = 3,
                            DeadLine = new DateTime(2024, 6, 27, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 1,
                            Description = "Analyze and write a critical review of a selected literary work. Focus on themes, characters, and writing style",
                            MinunumPassingScore = 0,
                            Name = "Literature Analysis",
                            UniversityYearId = 3
                        },
                        new
                        {
                            Id = 4,
                            DeadLine = new DateTime(2024, 6, 30, 1, 30, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 1,
                            Description = "Conduct an experiment in the lab and write a detailed report documenting the procedure, results, and conclusions",
                            MinunumPassingScore = 0,
                            Name = "Lab Report",
                            UniversityYearId = 4
                        },
                        new
                        {
                            Id = 5,
                            DeadLine = new DateTime(2024, 6, 25, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 2,
                            Description = "Write an essay on the impact of the Industrial Revolution",
                            MinunumPassingScore = 0,
                            Name = "History Essay",
                            UniversityYearId = 1
                        },
                        new
                        {
                            Id = 6,
                            DeadLine = new DateTime(2024, 6, 28, 23, 59, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 2,
                            Description = "Develop a simple mobile application with user authentication",
                            MinunumPassingScore = 0,
                            Name = "Computer Science Project",
                            UniversityYearId = 2
                        },
                        new
                        {
                            Id = 7,
                            DeadLine = new DateTime(2024, 6, 20, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 2,
                            Description = "Analyze the economic impact of global trade policies",
                            MinunumPassingScore = 0,
                            Name = "Economics Report",
                            UniversityYearId = 3
                        },
                        new
                        {
                            Id = 8,
                            DeadLine = new DateTime(2024, 6, 29, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 2,
                            Description = "Create a painting representing modern art styles",
                            MinunumPassingScore = 0,
                            Name = "Art Project",
                            UniversityYearId = 4
                        },
                        new
                        {
                            Id = 9,
                            DeadLine = new DateTime(2024, 6, 21, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 3,
                            Description = "Prepare a presentation on the human immune system",
                            MinunumPassingScore = 0,
                            Name = "Biology Presentation",
                            UniversityYearId = 1
                        },
                        new
                        {
                            Id = 10,
                            DeadLine = new DateTime(2024, 6, 24, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 3,
                            Description = "Discuss the ethical implications of artificial intelligence",
                            MinunumPassingScore = 0,
                            Name = "Philosophy Paper",
                            UniversityYearId = 2
                        },
                        new
                        {
                            Id = 11,
                            DeadLine = new DateTime(2024, 6, 26, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 3,
                            Description = "Complete the titration experiment and submit the results",
                            MinunumPassingScore = 0,
                            Name = "Chemistry Lab",
                            UniversityYearId = 3
                        },
                        new
                        {
                            Id = 12,
                            DeadLine = new DateTime(2024, 6, 22, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 3,
                            Description = "Conduct a survey on social media usage among teenagers",
                            MinunumPassingScore = 0,
                            Name = "Sociology Survey",
                            UniversityYearId = 4
                        });
                });

            modelBuilder.Entity("GetGraded.Models.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Department 1",
                            UniversityId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Department 2",
                            UniversityId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Department 3",
                            UniversityId = 2
                        });
                });

            modelBuilder.Entity("GetGraded.Models.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Professor"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Student"
                        });
                });

            modelBuilder.Entity("GetGraded.Models.Models.StudentDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AspNetUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UniversityYearId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AspNetUserId");

                    b.HasIndex("UniversityYearId");

                    b.ToTable("StudentDetail");
                });

            modelBuilder.Entity("GetGraded.Models.Models.SubmittedAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReviewerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Score")
                        .HasColumnType("int");

                    b.Property<string>("SubmitterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("ReviewerId");

                    b.HasIndex("SubmitterId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("GetGraded.Models.Models.TestSave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("GetGraded.Models.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("University");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "University 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "University 2"
                        });
                });

            modelBuilder.Entity("GetGraded.Models.Models.UniversityYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UniversityYear");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "1st year"
                        },
                        new
                        {
                            Id = 2,
                            Name = "2nd year"
                        },
                        new
                        {
                            Id = 3,
                            Name = "3rd year"
                        },
                        new
                        {
                            Id = 4,
                            Name = "4th year"
                        });
                });

            modelBuilder.Entity("GetGraded.Models.Models.UserLoginDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserLoginDetails");
                });

            modelBuilder.Entity("GetGraded.Models.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AspNetUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AspNetUserId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserProfile");
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("GetGraded.Models.Models.Assignment", b =>
                {
                    b.HasOne("GetGraded.Models.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GetGraded.Models.Models.UniversityYear", "UniversityYear")
                        .WithMany()
                        .HasForeignKey("UniversityYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("UniversityYear");
                });

            modelBuilder.Entity("GetGraded.Models.Models.Department", b =>
                {
                    b.HasOne("GetGraded.Models.Models.University", "University")
                        .WithMany()
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("GetGraded.Models.Models.StudentDetails", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "AspNetUser")
                        .WithMany()
                        .HasForeignKey("AspNetUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GetGraded.Models.Models.UniversityYear", "UniversityYear")
                        .WithMany()
                        .HasForeignKey("UniversityYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AspNetUser");

                    b.Navigation("UniversityYear");
                });

            modelBuilder.Entity("GetGraded.Models.Models.SubmittedAnswer", b =>
                {
                    b.HasOne("GetGraded.Models.Models.Assignment", "Assignment")
                        .WithMany()
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Submitter")
                        .WithMany()
                        .HasForeignKey("SubmitterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Reviewer");

                    b.Navigation("Submitter");
                });

            modelBuilder.Entity("GetGraded.Models.Models.UserProfile", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "AspNetUser")
                        .WithMany()
                        .HasForeignKey("AspNetUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GetGraded.Models.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GetGraded.Models.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AspNetUser");

                    b.Navigation("Department");

                    b.Navigation("Role");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
