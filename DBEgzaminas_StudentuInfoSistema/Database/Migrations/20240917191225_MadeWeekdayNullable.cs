using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBEgzaminas_StudentuInfoSistema.Migrations
{
    /// <inheritdoc />
    public partial class MadeWeekdayNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Weekday",
                table: "Lectures",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "LectureId",
                keyValue: 1,
                column: "Weekday",
                value: null);

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "LectureId",
                keyValue: 2,
                column: "Weekday",
                value: null);

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "LectureId",
                keyValue: 3,
                column: "Weekday",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Weekday",
                table: "Lectures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "LectureId",
                keyValue: 1,
                column: "Weekday",
                value: "Monday");

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "LectureId",
                keyValue: 2,
                column: "Weekday",
                value: "Monday");

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "LectureId",
                keyValue: 3,
                column: "Weekday",
                value: "Monday");
        }
    }
}
