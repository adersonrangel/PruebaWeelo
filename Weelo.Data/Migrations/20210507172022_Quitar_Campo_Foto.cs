using Microsoft.EntityFrameworkCore.Migrations;

namespace Weelo.Data.Migrations
{
    public partial class Quitar_Campo_Foto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File",
                table: "PropertyImage");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Owner");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "File",
                table: "PropertyImage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Owner",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
