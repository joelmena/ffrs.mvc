using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ffrs.mvc.Migrations
{
    public partial class addedContactRepository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Contactos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Inactivo",
                table: "Contactos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Contactos");

            migrationBuilder.DropColumn(
                name: "Inactivo",
                table: "Contactos");
        }
    }
}
