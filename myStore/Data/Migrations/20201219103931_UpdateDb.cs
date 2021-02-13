﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace myStore.Data.Migrations
{
    public partial class UpdateDb : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "CartItemId",
                table: "ShoppingCart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "CartItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartItemId",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "CartItem");

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