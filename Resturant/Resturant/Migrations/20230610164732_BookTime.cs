using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Resturant.Migrations
{
    public partial class BookTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterItemMenus_MasterCategoryMenus_MasterCategoryMenuId",
                table: "MasterItemMenus");

            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionBookTableTime",
                table: "TransactionBookTables",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "MasterItemMenuDate",
                table: "MasterItemMenus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MasterCategoryMenuId",
                table: "MasterItemMenus",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterItemMenus_MasterCategoryMenus_MasterCategoryMenuId",
                table: "MasterItemMenus",
                column: "MasterCategoryMenuId",
                principalTable: "MasterCategoryMenus",
                principalColumn: "MasterCategoryMenuId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterItemMenus_MasterCategoryMenus_MasterCategoryMenuId",
                table: "MasterItemMenus");

            migrationBuilder.DropColumn(
                name: "TransactionBookTableTime",
                table: "TransactionBookTables");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MasterItemMenuDate",
                table: "MasterItemMenus",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "MasterCategoryMenuId",
                table: "MasterItemMenus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterItemMenus_MasterCategoryMenus_MasterCategoryMenuId",
                table: "MasterItemMenus",
                column: "MasterCategoryMenuId",
                principalTable: "MasterCategoryMenus",
                principalColumn: "MasterCategoryMenuId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
