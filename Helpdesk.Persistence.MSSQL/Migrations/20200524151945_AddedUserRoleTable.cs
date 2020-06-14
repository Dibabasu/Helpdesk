using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Helpdesk.Persistence.MSSQL.Migrations
{
    public partial class AddedUserRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "FileCount",
                table: "HelpdeskTicketHistories",
                type: "smallint",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(short),
                oldType: "smallint",
                oldDefaultValueSql: "((1))");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    AdAccount_Domain = table.Column<string>(nullable: true),
                    AdAccount_UserName = table.Column<string>(nullable: true),
                    DepartmentName = table.Column<string>(nullable: true),
                    Division = table.Column<string>(nullable: true),
                    Name_Title = table.Column<string>(nullable: true),
                    Name_FirstMidName = table.Column<string>(nullable: true),
                    Name_LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Role = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HelpdeskTickets_ReportedBy",
                table: "HelpdeskTickets",
                column: "ReportedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HelpdeskTickets_User",
                table: "HelpdeskTickets",
                column: "ReportedBy",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HelpdeskTickets_User",
                table: "HelpdeskTickets");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_HelpdeskTickets_ReportedBy",
                table: "HelpdeskTickets");

            migrationBuilder.AlterColumn<short>(
                name: "FileCount",
                table: "HelpdeskTicketHistories",
                type: "smallint",
                nullable: false,
                defaultValueSql: "((1))",
                oldClrType: typeof(short),
                oldType: "smallint",
                oldDefaultValueSql: "((0))");
        }
    }
}