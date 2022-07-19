using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentViewModel");

            migrationBuilder.RenameColumn(
                name: "classNameId",
                table: "Students",
                newName: "ClassNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassNameId",
                table: "Students",
                column: "ClassNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ClassNames_ClassNameId",
                table: "Students",
                column: "ClassNameId",
                principalTable: "ClassNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ClassNames_ClassNameId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassNameId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "ClassNameId",
                table: "Students",
                newName: "classNameId");

            migrationBuilder.CreateTable(
                name: "StudentViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classNameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentViewModel_ClassNames_classNameId",
                        column: x => x.classNameId,
                        principalTable: "ClassNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentViewModel_classNameId",
                table: "StudentViewModel",
                column: "classNameId");
        }
    }
}
