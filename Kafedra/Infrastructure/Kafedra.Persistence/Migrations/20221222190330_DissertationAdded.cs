using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kafedra.Persistence.Migrations
{
    public partial class DissertationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Dissertations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DefenseYear",
                table: "Dissertations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Dissertations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DissertationType",
                table: "Dissertations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Dissertations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Manager",
                table: "Dissertations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Point",
                table: "Dissertations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublicationYear",
                table: "Dissertations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "QualificationId",
                table: "Dissertations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "Dissertations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Dissertations_QualificationId",
                table: "Dissertations",
                column: "QualificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dissertations_Qualifications_QualificationId",
                table: "Dissertations",
                column: "QualificationId",
                principalTable: "Qualifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dissertations_Qualifications_QualificationId",
                table: "Dissertations");

            migrationBuilder.DropIndex(
                name: "IX_Dissertations_QualificationId",
                table: "Dissertations");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Dissertations");

            migrationBuilder.DropColumn(
                name: "DefenseYear",
                table: "Dissertations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Dissertations");

            migrationBuilder.DropColumn(
                name: "DissertationType",
                table: "Dissertations");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Dissertations");

            migrationBuilder.DropColumn(
                name: "Manager",
                table: "Dissertations");

            migrationBuilder.DropColumn(
                name: "Point",
                table: "Dissertations");

            migrationBuilder.DropColumn(
                name: "PublicationYear",
                table: "Dissertations");

            migrationBuilder.DropColumn(
                name: "QualificationId",
                table: "Dissertations");

            migrationBuilder.DropColumn(
                name: "Topic",
                table: "Dissertations");
        }
    }
}
