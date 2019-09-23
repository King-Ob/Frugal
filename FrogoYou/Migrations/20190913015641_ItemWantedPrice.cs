using Microsoft.EntityFrameworkCore.Migrations;

namespace FrogoYou.Migrations
{
    public partial class ItemWantedPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemWantedPrice",
                table: "ItemDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemWantedPrice",
                table: "ItemDetails");
        }
    }
}
