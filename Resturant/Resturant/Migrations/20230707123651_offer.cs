using Microsoft.EntityFrameworkCore.Migrations;

namespace Resturant.Migrations
{
    public partial class offer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterAbout",
                columns: table => new
                {
                    MasterAboutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterAboutTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterAboutBrief = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterAboutDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterAboutUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterAboutImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterAbout", x => x.MasterAboutId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterAbout");
        }
    }
}
