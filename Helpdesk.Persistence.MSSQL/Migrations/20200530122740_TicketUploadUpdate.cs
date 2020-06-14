using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Helpdesk.Persistence.MSSQL.Migrations
{
    public partial class TicketUploadUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HelpdeskTicketUploads_HelpdeskTicketHistories_HelpdeskTicketHistoryId",
                table: "HelpdeskTicketUploads");

            migrationBuilder.DropIndex(
                name: "IX_HelpdeskTicketUploads_HelpdeskTicketHistoryId",
                table: "HelpdeskTicketUploads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HelpdeskTicketHistories",
                table: "HelpdeskTicketHistories");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "HelpdeskTicketUploads");

            migrationBuilder.DropColumn(
                name: "HelpdeskTicketHistoryId",
                table: "HelpdeskTicketUploads");

            migrationBuilder.DropColumn(
                name: "TicketDetailsId",
                table: "HelpdeskTicketUploads");

            migrationBuilder.RenameTable(
                name: "HelpdeskTicketHistories",
                newName: "HelpdeskTicketHistory");

            migrationBuilder.RenameIndex(
                name: "IX_HelpdeskTicketHistories_TicketId",
                table: "HelpdeskTicketHistory",
                newName: "IX_HelpdeskTicketHistory_TicketId");

            migrationBuilder.AddColumn<string>(
                name: "OriginalFileName",
                table: "HelpdeskTicketUploads",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "TicketId",
                table: "HelpdeskTicketUploads",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "TicketNumber",
                table: "HelpdeskTicketUploads",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UploadedFileName",
                table: "HelpdeskTicketUploads",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HelpdeskTicketHistory",
                table: "HelpdeskTicketHistory",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HelpdeskTicketUploads_TicketId",
                table: "HelpdeskTicketUploads",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_HelpdeskTicketUploads_HelpdeskTicket",
                table: "HelpdeskTicketUploads",
                column: "TicketId",
                principalTable: "HelpdeskTickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HelpdeskTicketUploads_HelpdeskTicket",
                table: "HelpdeskTicketUploads");

            migrationBuilder.DropIndex(
                name: "IX_HelpdeskTicketUploads_TicketId",
                table: "HelpdeskTicketUploads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HelpdeskTicketHistory",
                table: "HelpdeskTicketHistory");

            migrationBuilder.DropColumn(
                name: "OriginalFileName",
                table: "HelpdeskTicketUploads");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "HelpdeskTicketUploads");

            migrationBuilder.DropColumn(
                name: "TicketNumber",
                table: "HelpdeskTicketUploads");

            migrationBuilder.DropColumn(
                name: "UploadedFileName",
                table: "HelpdeskTicketUploads");

            migrationBuilder.RenameTable(
                name: "HelpdeskTicketHistory",
                newName: "HelpdeskTicketHistories");

            migrationBuilder.RenameIndex(
                name: "IX_HelpdeskTicketHistory_TicketId",
                table: "HelpdeskTicketHistories",
                newName: "IX_HelpdeskTicketHistories_TicketId");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "HelpdeskTicketUploads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "HelpdeskTicketHistoryId",
                table: "HelpdeskTicketUploads",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TicketDetailsId",
                table: "HelpdeskTicketUploads",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_HelpdeskTicketHistories",
                table: "HelpdeskTicketHistories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HelpdeskTicketUploads_HelpdeskTicketHistoryId",
                table: "HelpdeskTicketUploads",
                column: "HelpdeskTicketHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_HelpdeskTicketUploads_HelpdeskTicketHistories_HelpdeskTicketHistoryId",
                table: "HelpdeskTicketUploads",
                column: "HelpdeskTicketHistoryId",
                principalTable: "HelpdeskTicketHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}