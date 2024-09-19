﻿// <auto-generated />
using System;
using DBEgzaminas_StudentuInfoSistema.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DBEgzaminas_StudentuInfoSistema.Migrations
{
    [DbContext(typeof(SystemContext))]
    [Migration("20240917184034_AddJunctionTableInitialData")]
    partial class AddJunctionTableInitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DBEgzaminas_StudentuInfoSistema.Database.Entities.Department", b =>
                {
                    b.Property<string>("DepartmentCode")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DepartmentCode");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentCode = "CS1234",
                            DepartmentName = "ComputerScience"
                        },
                        new
                        {
                            DepartmentCode = "MTH567",
                            DepartmentName = "Mathematics"
                        });
                });

            modelBuilder.Entity("DBEgzaminas_StudentuInfoSistema.Database.Entities.Lecture", b =>
                {
                    b.Property<int>("LectureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LectureId"));

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time(0)");

                    b.Property<string>("LectureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time(0)");

                    b.Property<string>("Weekday")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LectureId");

                    b.HasIndex("LectureName")
                        .IsUnique();

                    b.ToTable("Lectures");

                    b.HasData(
                        new
                        {
                            LectureId = 1,
                            EndTime = new TimeOnly(11, 30, 0),
                            LectureName = "Algorithms",
                            StartTime = new TimeOnly(10, 0, 0),
                            Weekday = "Monday"
                        },
                        new
                        {
                            LectureId = 2,
                            EndTime = new TimeOnly(13, 30, 0),
                            LectureName = "Calculus",
                            StartTime = new TimeOnly(12, 0, 0),
                            Weekday = "Monday"
                        },
                        new
                        {
                            LectureId = 3,
                            EndTime = new TimeOnly(15, 30, 0),
                            LectureName = "DataStructures",
                            StartTime = new TimeOnly(14, 0, 0),
                            Weekday = "Monday"
                        });
                });

            modelBuilder.Entity("DBEgzaminas_StudentuInfoSistema.Database.Entities.Student", b =>
                {
                    b.Property<int>("StudentNumber")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(5)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentNumber"));

                    b.Property<string>("DepartmentCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StudentNumber");

                    b.HasIndex("DepartmentCode");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentNumber = 12345678,
                            DepartmentCode = "CS1234",
                            Email = "john.smith@example.com",
                            FirstName = "John",
                            LastName = "Smith"
                        },
                        new
                        {
                            StudentNumber = 87654321,
                            DepartmentCode = "MTH567",
                            Email = "alice.johnson@example.com",
                            FirstName = "Alice",
                            LastName = "Johnson"
                        });
                });

            modelBuilder.Entity("DepartmentLecture", b =>
                {
                    b.Property<string>("DepartmentsDepartmentCode")
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("LecturesLectureId")
                        .HasColumnType("int");

                    b.HasKey("DepartmentsDepartmentCode", "LecturesLectureId");

                    b.HasIndex("LecturesLectureId");

                    b.ToTable("DepartmentLecture");

                    b.HasData(
                        new
                        {
                            DepartmentsDepartmentCode = "CS1234",
                            LecturesLectureId = 1
                        },
                        new
                        {
                            DepartmentsDepartmentCode = "CS1234",
                            LecturesLectureId = 3
                        },
                        new
                        {
                            DepartmentsDepartmentCode = "MTH567",
                            LecturesLectureId = 2
                        });
                });

            modelBuilder.Entity("LectureStudent", b =>
                {
                    b.Property<int>("LecturesLectureId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsStudentNumber")
                        .HasColumnType("int");

                    b.HasKey("LecturesLectureId", "StudentsStudentNumber");

                    b.HasIndex("StudentsStudentNumber");

                    b.ToTable("LectureStudent");
                });

            modelBuilder.Entity("DBEgzaminas_StudentuInfoSistema.Database.Entities.Student", b =>
                {
                    b.HasOne("DBEgzaminas_StudentuInfoSistema.Database.Entities.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("DepartmentLecture", b =>
                {
                    b.HasOne("DBEgzaminas_StudentuInfoSistema.Database.Entities.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentsDepartmentCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBEgzaminas_StudentuInfoSistema.Database.Entities.Lecture", null)
                        .WithMany()
                        .HasForeignKey("LecturesLectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LectureStudent", b =>
                {
                    b.HasOne("DBEgzaminas_StudentuInfoSistema.Database.Entities.Lecture", null)
                        .WithMany()
                        .HasForeignKey("LecturesLectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBEgzaminas_StudentuInfoSistema.Database.Entities.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsStudentNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DBEgzaminas_StudentuInfoSistema.Database.Entities.Department", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
