using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Migrations
{
    public partial class try33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileFullName",
                table: "MasterPapers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileFullName",
                table: "MasterPapers");
        }
    }
}
