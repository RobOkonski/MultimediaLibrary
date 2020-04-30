using Microsoft.EntityFrameworkCore.Migrations;

namespace MultimediaLibrary.Migrations
{
    public partial class AddSubsAndViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Views",
                table: "Tracks",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Subscribers",
                table: "Artists",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Views",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "Subscribers",
                table: "Artists");
        }
    }
}
