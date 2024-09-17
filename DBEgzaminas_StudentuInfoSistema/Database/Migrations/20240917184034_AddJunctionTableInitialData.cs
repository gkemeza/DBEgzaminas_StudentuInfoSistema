using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DBEgzaminas_StudentuInfoSistema.Migrations
{
    /// <inheritdoc />
    public partial class AddJunctionTableInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DepartmentLecture",
                columns: new[] { "DepartmentsDepartmentCode", "LecturesLectureId" },
                values: new object[,]
                {
                    { "CS1234", 1 },
                    { "CS1234", 3 },
                    { "MTH567", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DepartmentLecture",
                keyColumns: new[] { "DepartmentsDepartmentCode", "LecturesLectureId" },
                keyValues: new object[] { "CS1234", 1 });

            migrationBuilder.DeleteData(
                table: "DepartmentLecture",
                keyColumns: new[] { "DepartmentsDepartmentCode", "LecturesLectureId" },
                keyValues: new object[] { "CS1234", 3 });

            migrationBuilder.DeleteData(
                table: "DepartmentLecture",
                keyColumns: new[] { "DepartmentsDepartmentCode", "LecturesLectureId" },
                keyValues: new object[] { "MTH567", 2 });
        }
    }
}
