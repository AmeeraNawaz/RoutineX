using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace samplecrud.Migrations
{
    public partial class AddDueDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DueDateTime",
                table: "RoutineTasks",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDateTime",
                table: "RoutineTasks");
        }
    }
}
