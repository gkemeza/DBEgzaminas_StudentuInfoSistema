using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBEgzaminas_StudentuInfoSistema.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTimeCloumnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "StartTime",
                table: "Lectures",
                type: "time(0)",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "EndTime",
                table: "Lectures",
                type: "time(0)",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "StartTime",
                table: "Lectures",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time(0)");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "EndTime",
                table: "Lectures",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time(0)");
        }
    }
}
