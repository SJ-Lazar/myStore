﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace myStore.Data.Migrations
{
    public partial class updDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_ShoppingCart_ShoppingCartID",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_ShoppingCartID",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "ShoppingCartID",
                table: "CartItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartID",
                table: "CartItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ShoppingCartID",
                table: "CartItem",
                column: "ShoppingCartID");

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