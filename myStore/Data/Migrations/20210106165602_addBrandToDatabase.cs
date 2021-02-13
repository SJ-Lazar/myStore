using Microsoft.EntityFrameworkCore.Migrations;

namespace myStore.Data.Migrations
{
    public partial class addBrandToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "ProductSpec",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductSpecId",
                table: "Brand",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brand_ProductSpecId",
                table: "Brand",
                column: "ProductSpecId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brand_ProductSpec_ProductSpecId",
                table: "Brand",
                column: "ProductSpecId",
                principalTable: "ProductSpec",
                principalColumn: "ProductSpecId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brand_ProductSpec_ProductSpecId",
                table: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Brand_ProductSpecId",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "ProductSpec");

            migrationBuilder.DropColumn(
                name: "ProductSpecId",
                table: "Brand");
        }
    }
}
