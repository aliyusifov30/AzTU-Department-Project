using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kafedra.Persistence.Migrations
{
    public partial class DescriptionAddedToSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_FacultyId",
                table: "Subjects",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Faculties_FacultyId",
                table: "Subjects",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Faculties_FacultyId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_FacultyId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Subjects");
        }
    }
}
