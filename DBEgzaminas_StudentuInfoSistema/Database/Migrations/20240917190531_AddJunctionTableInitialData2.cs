using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DBEgzaminas_StudentuInfoSistema.Migrations
{
    /// <inheritdoc />
    public partial class AddJunctionTableInitialData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LectureStudent",
                columns: new[] { "LecturesLectureId", "StudentsStudentNumber" },
                values: new object[,]
                {
                    { 1, 12345678 },
                    { 2, 87654321 },
                    { 3, 12345678 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LectureStudent",
                keyColumns: new[] { "LecturesLectureId", "StudentsStudentNumber" },
                keyValues: new object[] { 1, 12345678 });

            migrationBuilder.DeleteData(
                table: "LectureStudent",
                keyColumns: new[] { "LecturesLectureId", "StudentsStudentNumber" },
                keyValues: new object[] { 2, 87654321 });

            migrationBuilder.DeleteData(
                table: "LectureStudent",
                keyColumns: new[] { "LecturesLectureId", "StudentsStudentNumber" },
                keyValues: new object[] { 3, 12345678 });
        }
    }
}
