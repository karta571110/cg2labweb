using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Service.Migrations
{
    public partial class @try : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hankPageHonors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    schoolYear = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DoWhat = table.Column<string>(nullable: true),
                    Award = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hankPageHonors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hankPageProjects",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    schoolYear = table.Column<int>(nullable: false),
                    projectName = table.Column<string>(nullable: true),
                    projectTopice = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hankPageProjects", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "industryResearches",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    schoolYear = table.Column<int>(nullable: false),
                    projectName = table.Column<string>(nullable: true),
                    projectTopice = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_industryResearches", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hankPageHonors");

            migrationBuilder.DropTable(
                name: "hankPageProjects");

            migrationBuilder.DropTable(
                name: "industryResearches");
        }
    }
}
