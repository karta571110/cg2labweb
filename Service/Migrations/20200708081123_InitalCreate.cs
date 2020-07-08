using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Service.Migrations
{
    public partial class InitalCreate : Migration
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
                name: "HankPageJournalPapers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    JournalPaper = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HankPageJournalPapers", x => x.id);
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
                name: "HankPageSeminarPapers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SeminarPaper = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HankPageSeminarPapers", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "MasterPapers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MasterName = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    FileFullName = table.Column<string>(nullable: true),
                    dateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterPapers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Account = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentData",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Studentid = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentData", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "undergraduateStudentsWorks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    updaterName = table.Column<string>(nullable: true),
                    teammate = table.Column<string>(nullable: true),
                    topic = table.Column<string>(nullable: true),
                    youtubeURL = table.Column<string>(nullable: true),
                    youtubeId = table.Column<string>(nullable: true),
                    googleDriveURL = table.Column<string>(nullable: true),
                    dateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_undergraduateStudentsWorks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hankPageHonors");

            migrationBuilder.DropTable(
                name: "HankPageJournalPapers");

            migrationBuilder.DropTable(
                name: "hankPageProjects");

            migrationBuilder.DropTable(
                name: "HankPageSeminarPapers");

            migrationBuilder.DropTable(
                name: "industryResearches");

            migrationBuilder.DropTable(
                name: "MasterPapers");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "StudentData");

            migrationBuilder.DropTable(
                name: "undergraduateStudentsWorks");
        }
    }
}
