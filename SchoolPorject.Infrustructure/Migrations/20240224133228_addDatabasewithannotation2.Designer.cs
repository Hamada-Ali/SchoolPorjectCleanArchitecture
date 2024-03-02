﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolProject.Infrustructure.Domain;

#nullable disable

namespace SchoolProject.Infrustructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240224133228_addDatabasewithannotation2")]
    partial class addDatabasewithannotation2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    b.Property<int?>("DID")
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
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("DID")
                        .HasColumnType("int");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
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

                    b.Property<DateTime>("Period")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubjectNameAr")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("SubjectNameEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubID");

                    b.ToTable("subjects");
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
                        .HasForeignKey("DID");

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
