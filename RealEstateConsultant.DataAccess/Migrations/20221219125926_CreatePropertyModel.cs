using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateConsultant.DataAccess.Migrations
{
    public partial class CreatePropertyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoPath",
                table: "HousingProperties");

            migrationBuilder.DropColumn(
                name: "PropertyName",
                table: "HousingProperties");

            migrationBuilder.DropColumn(
                name: "PropertyValue",
                table: "HousingProperties");

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "HousingProperties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HousingProperties_PropertyId",
                table: "HousingProperties",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_HousingProperties_Property_PropertyId",
                table: "HousingProperties",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HousingProperties_Property_PropertyId",
                table: "HousingProperties");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropIndex(
                name: "IX_HousingProperties_PropertyId",
                table: "HousingProperties");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "HousingProperties");

            migrationBuilder.AddColumn<string>(
                name: "LogoPath",
                table: "HousingProperties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropertyName",
                table: "HousingProperties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PropertyValue",
                table: "HousingProperties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
