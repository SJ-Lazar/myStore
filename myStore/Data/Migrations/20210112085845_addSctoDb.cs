using Microsoft.EntityFrameworkCore.Migrations;

namespace myStore.Data.Migrations
{
    public partial class addSctoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_ShoppingCart_ShoppingCartID",
                table: "CartItem");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartID",
                table: "ShoppingCart",
                newName: "ShoppingCartId");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartID",
                table: "CartItem",
                newName: "ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_ShoppingCartID",
                table: "CartItem",
                newName: "IX_CartItem_ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_ShoppingCart_ShoppingCartId",
                table: "CartItem",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "ShoppingCartId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_ShoppingCart_ShoppingCartId",
                table: "CartItem");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartId",
                table: "ShoppingCart",
                newName: "ShoppingCartID");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartId",
                table: "CartItem",
                newName: "ShoppingCartID");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_ShoppingCartId",
                table: "CartItem",
                newName: "IX_CartItem_ShoppingCartID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_ShoppingCart_ShoppingCartID",
                table: "CartItem",
                column: "ShoppingCartID",
                principalTable: "ShoppingCart",
                principalColumn: "ShoppingCartID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
