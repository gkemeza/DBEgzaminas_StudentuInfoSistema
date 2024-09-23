using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DBEgzaminas_StudentuInfoSistema.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentCode);
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    LectureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LectureName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time(0)", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time(0)", nullable: false),
                    Weekday = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.LectureId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentNumber = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentCode = table.Column<string>(type: "nvarchar(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentNumber);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentCode",
                        column: x => x.DepartmentCode,
                        principalTable: "Departments",
                        principalColumn: "DepartmentCode");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentLecture",
                columns: table => new
                {
                    DepartmentsDepartmentCode = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    LecturesLectureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentLecture", x => new { x.DepartmentsDepartmentCode, x.LecturesLectureId });
                    table.ForeignKey(
                        name: "FK_DepartmentLecture_Departments_DepartmentsDepartmentCode",
                        column: x => x.DepartmentsDepartmentCode,
                        principalTable: "Departments",
                        principalColumn: "DepartmentCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentLecture_Lectures_LecturesLectureId",
                        column: x => x.LecturesLectureId,
                        principalTable: "Lectures",
                        principalColumn: "LectureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LectureStudent",
                columns: table => new
                {
                    LecturesLectureId = table.Column<int>(type: "int", nullable: false),
                    StudentsStudentNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureStudent", x => new { x.LecturesLectureId, x.StudentsStudentNumber });
                    table.ForeignKey(
                        name: "FK_LectureStudent_Lectures_LecturesLectureId",
                        column: x => x.LecturesLectureId,
                        principalTable: "Lectures",
                        principalColumn: "LectureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LectureStudent_Students_StudentsStudentNumber",
                        column: x => x.StudentsStudentNumber,
                        principalTable: "Students",
                        principalColumn: "StudentNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentCode", "DepartmentName" },
                values: new object[,]
                {
                    { "CS1234", "ComputerScience" },
                    { "MTH567", "Mathematics" }
                });

            migrationBuilder.InsertData(
                table: "Lectures",
                columns: new[] { "LectureId", "EndTime", "LectureName", "StartTime", "Weekday" },
                values: new object[,]
                {
                    { 1, new TimeOnly(11, 30, 0), "Algorithms", new TimeOnly(10, 0, 0), null },
                    { 2, new TimeOnly(13, 30, 0), "Calculus", new TimeOnly(12, 0, 0), null },
                    { 3, new TimeOnly(15, 30, 0), "DataStructures", new TimeOnly(14, 0, 0), null }
                });

            migrationBuilder.InsertData(
                table: "DepartmentLecture",
                columns: new[] { "DepartmentsDepartmentCode", "LecturesLectureId" },
                values: new object[,]
                {
                    { "CS1234", 1 },
                    { "CS1234", 3 },
                    { "MTH567", 2 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentNumber", "DepartmentCode", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 12345678, "CS1234", "john.smith@example.com", "John", "Smith" },
                    { 87654321, "MTH567", "alice.johnson@example.com", "Alice", "Johnson" }
                });

            migrationBuilder.InsertData(
                table: "LectureStudent",
                columns: new[] { "LecturesLectureId", "StudentsStudentNumber" },
                values: new object[,]
                {
                    { 1, 12345678 },
                    { 2, 87654321 },
                    { 3, 12345678 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentLecture_LecturesLectureId",
                table: "DepartmentLecture",
                column: "LecturesLectureId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_LectureName",
                table: "Lectures",
                column: "LectureName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LectureStudent_StudentsStudentNumber",
                table: "LectureStudent",
                column: "StudentsStudentNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentCode",
                table: "Students",
                column: "DepartmentCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentLecture");

            migrationBuilder.DropTable(
                name: "LectureStudent");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
