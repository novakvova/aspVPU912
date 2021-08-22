using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoShop.Domain.Migrations
{
    public partial class AddimagecoltoCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "tblCars",
                type: "character varying(400)",
                maxLength: 400,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "tblCars");
        }
    }
}
