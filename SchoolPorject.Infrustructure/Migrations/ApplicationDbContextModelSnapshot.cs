﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolProject.Infrustructure.Domain;

#nullable disable

namespace SchoolProject.Infrustructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SchoolProject.Domain.Entities.Department", b =>
                {
                    b.Property<int>("DID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DID"), 1L, 1);

                    b.Property<string>("DNameAr")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("DNameEn")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("InsManager")
                        .HasColumnType("int");

                    b.HasKey("DID");

                    b.HasIndex("InsManager")
                        .IsUnique();

                    b.ToTable("departments");
                });

            modelBuilder.Entity("SchoolProject.Domain.Entities.DepartmentSubject", b =>
                {
                    b.Property<int>("SubID")
                        .HasColumnType("int");

                    b.Property<int>("DID")
                        .HasColumnType("int");

                    b.HasKey("SubID", "DID");

                    b.HasIndex("DID");

                    b.ToTable("departmentSubjects");
                });

            modelBuilder.Entity("SchoolProject.Domain.Entities.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
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

            modelBuilder.Entity("SchoolProject.Domain.Entities.Ins_Subject", b =>
                {
                    b.Property<int>("SubId")
                        .HasColumnType("int");

                    b.Property<int>("InsId")
                        .HasColumnType("int");

                    b.HasKey("SubId", "InsId");

                    b.HasIndex("InsId");

                    b.ToTable("Ins_Subject");
                });

            modelBuilder.Entity("SchoolProject.Domain.Entities.Instructor", b =>
                {
                    b.Property<int>("InsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InsId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DID")
                        .HasColumnType("int");

                    b.Property<string>("ENameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ENameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SupervisorId")
                        .HasColumnType("int");

                    b.HasKey("InsId");

                    b.HasIndex("DID");

                    b.HasIndex("SupervisorId");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("SchoolProject.Domain.Entities.Student", b =>
                {
                    b.Property<int>("StudId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("DID")
                        .HasColumnType("int");

                    b.Property<string>("NameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("StudId");

                    b.HasIndex("DID");

                    b.ToTable("students");
                });

            modelBuilder.Entity("SchoolProject.Domain.Entities.StudentSubject", b =>
                {
                    b.Property<int>("StudID")
                        .HasColumnType("int");

                    b.Property<int>("SubID")
                        .HasColumnType("int");

                    b.Property<decimal?>("Grade")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("StudID", "SubID");

                    b.HasIndex("SubID");

                    b.ToTable("studentSubjects");
                });

            modelBuilder.Entity("SchoolProject.Domain.Entities.Subjects", b =>
                {
                    b.Property<int>("SubID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubID"), 1L, 1);

                    b.Property<int?>("Period")
                        .HasColumnType("int");

                    b.Property<string>("SubjectNameAr")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("SubjectNameEn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubID");

                    b.ToTable("subjects");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("SchoolProject.Domain.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("SchoolProject.Domain.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolProject.Domain.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("SchoolProject.Domain.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolProject.Domain.Entities.Department", b =>
                {
                    b.HasOne("SchoolProject.Domain.Entities.Instructor", "Instructor")
                        .WithOne("departmentManager")
                        .HasForeignKey("SchoolProject.Domain.Entities.Department", "InsManager")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("SchoolProject.Domain.Entities.DepartmentSubject", b =>
                {
                    b.HasOne("SchoolProject.Domain.Entities.Department", "Departments")
                        .WithMany("DepartmentSubjects")
                        .HasForeignKey("DID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolProject.Domain.Entities.Subjects", "Subjects")
                        .WithMany("DepartmentSubjects")
                        .HasForeignKey("SubID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departments");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("SchoolProject.Domain.Entities.Ins_Subject", b =>
                {
                    b.HasOne("SchoolProject.Domain.Entities.Instructor", "instructor")
                        .WithMany("Ins_Subjects")
                        .HasForeignKey("InsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolProject.Domain.Entities.Subjects", "Subject")
                        .WithMany("Ins_Subjects")
                        .HasForeignKey("SubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("instructor");
                });

            modelBuilder.Entity("SchoolProject.Domain.Entities.Instructor", b =>
                {
                    b.HasOne("SchoolProject.Domain.Entities.Department", "department")
                        .WithMany("Instructors")
                        .HasForeignKey("DID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolProject.Domain.Entities.Instructor", "supervisor")
                        .WithMany("Instructors")
                        .HasForeignKey("SupervisorId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("department");

                    b.Navigation("supervisor");
                });

            modelBuilder.Entity("SchoolProject.Domain.Entities.Student", b =>
                {
                    b.HasOne("SchoolProject.Domain.Entities.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DID");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SchoolProject.Domain.Entities.StudentSubject", b =>
                {
                    b.HasOne("SchoolProject.Domain.Entities.Student", "Student")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("StudID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolProject.Domain.Entities.Subjects", "Subject")
                        .WithMany("StudentsSubjects")
                        .HasForeignKey("SubID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SchoolProject.Domain.Entities.Department", b =>
                {
                    b.Navigation("DepartmentSubjects");

                    b.Navigation("Instructors");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("SchoolProject.Domain.Entities.Instructor", b =>
                {
                    b.Navigation("Ins_Subjects");

                    b.Navigation("Instructors");

                    b.Navigation("departmentManager");
                });

            modelBuilder.Entity("SchoolProject.Domain.Entities.Student", b =>
                {
                    b.Navigation("StudentSubjects");
                });

            modelBuilder.Entity("SchoolProject.Domain.Entities.Subjects", b =>
                {
                    b.Navigation("DepartmentSubjects");

                    b.Navigation("Ins_Subjects");

                    b.Navigation("StudentsSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
