using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateConsultant.DataAccess.Migrations
{
    public partial class AddDescriptionToHousing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Housings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Housings");
        }
    }
}
