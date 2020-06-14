using Microsoft.EntityFrameworkCore.Migrations;

namespace Helpdesk.Persistence.MSSQL.Migrations
{
    public partial class RemoveFilecountfromHelpdeskTicketHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name_Title",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FileCount",
                table: "HelpdeskTicketHistory");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantMappings_UserId",
                table: "ConsultantMappings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApproverMappings_UserId",
                table: "ApproverMappings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApproverMappings_User_UserId",
                table: "ApproverMappings",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultantMappings_User_UserId",
                table: "ConsultantMappings",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApproverMappings_User_UserId",
                table: "ApproverMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultantMappings_User_UserId",
                table: "ConsultantMappings");

            migrationBuilder.DropIndex(
                name: "IX_ConsultantMappings_UserId",
                table: "ConsultantMappings");

            migrationBuilder.DropIndex(
                name: "IX_ApproverMappings_UserId",
                table: "ApproverMappings");

            migrationBuilder.AddColumn<string>(
                name: "Name_Title",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "FileCount",
                table: "HelpdeskTicketHistory",
                type: "smallint",
                nullable: false,
                defaultValueSql: "((0))");
        }
    }
}
