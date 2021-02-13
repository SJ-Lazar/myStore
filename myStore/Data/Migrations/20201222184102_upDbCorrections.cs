using Microsoft.EntityFrameworkCore.Migrations;

namespace myStore.Data.Migrations
{
    public partial class upDbCorrections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sizeId",
                table: "ProductSpec",
                newName: "SizeId");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "ProductSpec",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "ColoId",
                table: "ProductSpec",
                newName: "ColorId");

            migrationBuilder.AddColumn<int>(
                name: "ProductSpecId",
                table: "Tag",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductSpecId",
                table: "Size",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductSpecId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductSpecId",
                table: "Color",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductSpecId",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ProductSpecId",
                table: "Tag",
                column: "ProductSpecId");

            migrationBuilder.CreateIndex(
                name: "IX_Size_ProductSpecId",
                table: "Size",
                column: "ProductSpecId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductSpecId",
                table: "Products",
                column: "ProductSpecId");

            migrationBuilder.CreateIndex(
                name: "IX_Color_ProductSpecId",
                table: "Color",
                column: "ProductSpecId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ProductSpecId",
                table: "Category",
                column: "ProductSpecId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_ProductSpec_ProductSpecId",
                table: "Category",
                column: "ProductSpecId",
                principalTable: "ProductSpec",
                principalColumn: "ProductSpecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Color_ProductSpec_ProductSpecId",
                table: "Color",
                column: "ProductSpecId",
                principalTable: "ProductSpec",
                principalColumn: "ProductSpecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductSpec_ProductSpecId",
                table: "Products",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_ProductSpec_ProductSpecId",
                table: "Tag",
                column: "ProductSpecId",
                principalTable: "ProductSpec",
                principalColumn: "ProductSpecId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_ProductSpec_ProductSpecId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Color_ProductSpec_ProductSpecId",
                table: "Color");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductSpec_ProductSpecId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Size_ProductSpec_ProductSpecId",
                table: "Size");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_ProductSpec_ProductSpecId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_ProductSpecId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Size_ProductSpecId",
                table: "Size");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductSpecId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Color_ProductSpecId",
                table: "Color");

            migrationBuilder.DropIndex(
                name: "IX_Category_ProductSpecId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ProductSpecId",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "ProductSpecId",
                table: "Size");

            migrationBuilder.DropColumn(
                name: "ProductSpecId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductSpecId",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "ProductSpecId",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "SizeId",
                table: "ProductSpec",
                newName: "sizeId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "ProductSpec",
                newName: "categoryId");

            migrationBuilder.RenameColumn(
                name: "ColorId",
                table: "ProductSpec",
                newName: "ColoId");
        }
    }
}
