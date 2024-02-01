using Microsoft.EntityFrameworkCore.Migrations;

namespace Resturant.Migrations
{
    public partial class systemsitting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SystemSettingWelcomeNoteImageUrl2",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SystemSettingWelcomeNoteImageUrl3",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SystemSettingWelcomeNoteImageUrl4",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SystemSettingWelcomeNoteImageUrl2",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "SystemSettingWelcomeNoteImageUrl3",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "SystemSettingWelcomeNoteImageUrl4",
                table: "SystemSettings");
        }
    }
}
