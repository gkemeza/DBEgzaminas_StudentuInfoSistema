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
    [Migration("20240917155204_fixedTypo")]
    partial class fixedTypo
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
                });

            modelBuilder.Entity("DBEgzaminas_StudentuInfoSistema.Database.Entities.Lecture", b =>
                {
                    b.Property<int>("LectureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LectureId"));

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("LectureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time");

                    b.Property<string>("Weekday")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LectureId");

                    b.HasIndex("LectureName")
                        .IsUnique();

                    b.ToTable("Lectures");
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
