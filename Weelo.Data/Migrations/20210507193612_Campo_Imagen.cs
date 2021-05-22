using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weelo.Data.Migrations
{
    public partial class Campo_Imagen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "File",
                table: "PropertyImage",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Owner",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File",
                table: "PropertyImage");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Owner");
        }
    }
}
