using Microsoft.EntityFrameworkCore.Migrations;

namespace myStore.Data.Migrations
{
    public partial class AddProductDetailToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Color_ProductSpec_ProductSpecId",
                table: "Color");

            migrationBuilder.DropForeignKey(
                name: "FK_Size_ProductSpec_ProductSpecId",
                table: "Size");

            migrationBuilder.DropIndex(
                name: "IX_Size_ProductSpecId",
                table: "Size");

            migrationBuilder.DropIndex(
                name: "IX_Color_ProductSpecId",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "ProductSpecId",
                table: "Size");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "ProductSpec");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "ProductSpec");

            migrationBuilder.DropColumn(
                name: "ProductSpecId",
                table: "Color");

            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    ProductDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    SizesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetail", x => x.ProductDetailId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDetail");

            migrationBuilder.AddColumn<int>(
                name: "ProductSpecId",
                table: "Size",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "ProductSpec",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "ProductSpec",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductSpecId",
                table: "Color",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Size_ProductSpecId",
                table: "Size",
                column: "ProductSpecId");

            migrationBuilder.CreateIndex(
                name: "IX_Color_ProductSpecId",
                table: "Color",
                column: "ProductSpecId");

            migrationBuilder.AddForeignKey(
                name: "FK_Color_ProductSpec_ProductSpecId",
                table: "Color",
                column: "ProductSpecId",
                principalTable: "ProductSpec",
                principalColumn: "ProductSpecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Size_ProductSpec_ProductSpecId",
                table: "Size",
                column: "ProductSpecId",
                principalTable: "ProductSpec",
                principalColumn: "ProductSpecId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
