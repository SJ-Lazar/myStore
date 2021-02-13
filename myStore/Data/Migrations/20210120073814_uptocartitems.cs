using Microsoft.EntityFrameworkCore.Migrations;

namespace myStore.Data.Migrations
{
    public partial class uptocartitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "CartItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "CartItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "CartItem");
        }
    }
}
