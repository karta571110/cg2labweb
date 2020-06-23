using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Migrations
{
    public partial class change1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "googleDriveURL",
                table: "undergraduateStudentsWorks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updaterName",
                table: "undergraduateStudentsWorks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "youtubeURL",
                table: "undergraduateStudentsWorks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "googleDriveURL",
                table: "undergraduateStudentsWorks");

            migrationBuilder.DropColumn(
                name: "updaterName",
                table: "undergraduateStudentsWorks");

            migrationBuilder.DropColumn(
                name: "youtubeURL",
                table: "undergraduateStudentsWorks");
        }
    }
}
