using Microsoft.EntityFrameworkCore.Migrations;

namespace myStore.Data.Migrations
{
    public partial class updateTheStockTbl1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDetail");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Stock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SizesId",
                table: "Stock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "Size",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "Color",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Size_StockId",
                table: "Size",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Color_StockId",
                table: "Color",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Color_Stock_StockId",
                table: "Color",
                column: "StockId",
                principalTable: "Stock",
                principalColumn: "StockId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Size_Stock_StockId",
                table: "Size",
                column: "StockId",
                principalTable: "Stock",
                principalColumn: "StockId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Color_Stock_StockId",
                table: "Color");

            migrationBuilder.DropForeignKey(
                name: "FK_Size_Stock_StockId",
                table: "Size");

            migrationBuilder.DropIndex(
                name: "IX_Size_StockId",
                table: "Size");

            migrationBuilder.DropIndex(
                name: "IX_Color_StockId",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "SizesId",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "Size");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "Color");

            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    ProductDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SizesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetail", x => x.ProductDetailId);
                });
        }
    }
}
