using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateConsultant.DataAccess.Migrations
{
    public partial class FixErrProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Properties");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "HousingProperties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "HousingProperties");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
