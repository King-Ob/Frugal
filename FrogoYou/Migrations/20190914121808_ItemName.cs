using Microsoft.EntityFrameworkCore.Migrations;

namespace FrogoYou.Migrations
{
    public partial class ItemName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "ItemDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "ItemDetails");
        }
    }
}
