using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBEgzaminas_StudentuInfoSistema.Migrations
{
    /// <inheritdoc />
    public partial class fixedTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departaments_DepartamentCode",
                table: "Students");

            migrationBuilder.DropTable(
                name: "DepartamentLecture");

            migrationBuilder.DropTable(
                name: "Departaments");

            migrationBuilder.RenameColumn(
                name: "DepartamentCode",
                table: "Students",
                newName: "DepartmentCode");

            migrationBuilder.RenameIndex(
                name: "IX_Students_DepartamentCode",
                table: "Students",
                newName: "IX_Students_DepartmentCode");

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

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentLecture_LecturesLectureId",
                table: "DepartmentLecture",
                column: "LecturesLectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentCode",
                table: "Students",
                column: "DepartmentCode",
                principalTable: "Departments",
                principalColumn: "DepartmentCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentCode",
                table: "Students");

            migrationBuilder.DropTable(
                name: "DepartmentLecture");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.RenameColumn(
                name: "DepartmentCode",
                table: "Students",
                newName: "DepartamentCode");

            migrationBuilder.RenameIndex(
                name: "IX_Students_DepartmentCode",
                table: "Students",
                newName: "IX_Students_DepartamentCode");

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

            migrationBuilder.CreateIndex(
                name: "IX_DepartamentLecture_LecturesLectureId",
                table: "DepartamentLecture",
                column: "LecturesLectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departaments_DepartamentCode",
                table: "Students",
                column: "DepartamentCode",
                principalTable: "Departaments",
                principalColumn: "DepartamentCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
