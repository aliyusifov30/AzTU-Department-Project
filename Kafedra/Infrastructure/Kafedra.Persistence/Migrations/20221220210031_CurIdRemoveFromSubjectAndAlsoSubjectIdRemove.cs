using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kafedra.Persistence.Migrations
{
    public partial class CurIdRemoveFromSubjectAndAlsoSubjectIdRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurriculumId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Curriculums");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurriculumId",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Curriculums",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
