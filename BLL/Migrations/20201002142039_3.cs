using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BLL.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmailId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "diaries",
                columns: table => new
                {
                    Diaryid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    body = table.Column<string>(nullable: true),
                    PublishTime = table.Column<DateTime>(nullable: false),
                    userId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diaries", x => x.Diaryid);
                    table.ForeignKey(
                        name: "FK_diaries_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmailId",
                table: "Users",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_diaries_userId",
                table: "diaries",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Emails_EmailId",
                table: "Users",
                column: "EmailId",
                principalTable: "Emails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Emails_EmailId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "diaries");

            migrationBuilder.DropIndex(
                name: "IX_Users_EmailId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Users");
        }
    }
}
