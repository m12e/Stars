using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Dal.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(maxLength: 32, nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 256, nullable: false),
                    Guid = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DateOfCreationUtc = table.Column<DateTime>(nullable: false),
                    DateOfLastChangeUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_Guid",
                table: "UserAccounts",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_Login",
                table: "UserAccounts",
                column: "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccounts");
        }
    }
}
