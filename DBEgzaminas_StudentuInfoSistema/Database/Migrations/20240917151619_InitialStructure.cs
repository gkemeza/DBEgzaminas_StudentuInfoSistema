using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBEgzaminas_StudentuInfoSistema.Migrations
{
    /// <inheritdoc />
    public partial class InitialStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departaments",
                columns: table => new
                {
                    DepartamentCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    DepartamentName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departaments", x => x.DepartamentCode);
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    LectureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LectureName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    Weekday = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.LectureId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentNumber = table.Column<int>(type: "int", precision: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartamentCode = table.Column<string>(type: "nvarchar(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentNumber);
                    table.ForeignKey(
                        name: "FK_Students_Departaments_DepartamentCode",
                        column: x => x.DepartamentCode,
                        principalTable: "Departaments",
                        principalColumn: "DepartamentCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartamentLecture",
                columns: table => new
                {
                    DepartamentsDepartamentCode = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    LecturesLectureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartamentLecture", x => new { x.DepartamentsDepartamentCode, x.LecturesLectureId });
                    table.ForeignKey(
                        name: "FK_DepartamentLecture_Departaments_DepartamentsDepartamentCode",
                        column: x => x.DepartamentsDepartamentCode,
                        principalTable: "Departaments",
                        principalColumn: "DepartamentCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartamentLecture_Lectures_LecturesLectureId",
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

            migrationBuilder.CreateIndex(
                name: "IX_DepartamentLecture_LecturesLectureId",
                table: "DepartamentLecture",
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
                name: "IX_Students_DepartamentCode",
                table: "Students",
                column: "DepartamentCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartamentLecture");

            migrationBuilder.DropTable(
                name: "LectureStudent");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departaments");
        }
    }
}
