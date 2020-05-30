using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace BlogR.Data.EF.MySQL.Migrations
{
    public partial class InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreationTimeUtc = table.Column<DateTime>(nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(maxLength: 160, nullable: false),
                    Password = table.Column<string>(maxLength: 160, nullable: false),
                    Salt = table.Column<string>(maxLength: 80, nullable: false),
                    Nickname = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreationTimeUtc = table.Column<DateTime>(nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 160, nullable: false),
                    Summary = table.Column<string>(maxLength: 460, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    Slug = table.Column<string>(maxLength: 160, nullable: false),
                    ViewCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
