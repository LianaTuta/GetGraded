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
    [Migration("20240508212453_fourth")]
    partial class fourth
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.Property<int>("UniverisityYearId")
                        .HasColumnType("int");

                    b.Property<int>("UniversityYearId")
                        .HasColumnType("int");

                    b.Property<int>("UserLoginId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UniversityYearId");

                    b.HasIndex("UserLoginId");

                    b.ToTable("StudentDetail");
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

                    b.Property<int>("UserLoginId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserLoginId");

                    b.ToTable("UserProfile");
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
                    b.HasOne("GetGraded.Models.Models.UniversityYear", "UniversityYear")
                        .WithMany()
                        .HasForeignKey("UniversityYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GetGraded.Models.Models.UserLoginDetails", "UserLogin")
                        .WithMany()
                        .HasForeignKey("UserLoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UniversityYear");

                    b.Navigation("UserLogin");
                });

            modelBuilder.Entity("GetGraded.Models.Models.UserProfile", b =>
                {
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

                    b.HasOne("GetGraded.Models.Models.UserLoginDetails", "UserLogin")
                        .WithMany()
                        .HasForeignKey("UserLoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Role");

                    b.Navigation("UserLogin");
                });
#pragma warning restore 612, 618
        }
    }
}
