using Microsoft.EntityFrameworkCore.Migrations;

namespace Helpdesk.Persistence.MSSQL.Migrations
{
    public partial class IntialCommitv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserRole",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Statuses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LocationType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Locations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "IssueType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "IssueSubCatagories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "IssueCatagory",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ClosureRemark",
                table: "HelpdeskTickets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalTime",
                table: "HelpdeskTickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ElapsedTime",
                table: "HelpdeskTicketHistories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Country",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ConsultantMappings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ApproverMappings",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LocationType");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "IssueType");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "IssueSubCatagories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "IssueCatagory");

            migrationBuilder.DropColumn(
                name: "ClosureRemark",
                table: "HelpdeskTickets");

            migrationBuilder.DropColumn(
                name: "TotalTime",
                table: "HelpdeskTickets");

            migrationBuilder.DropColumn(
                name: "ElapsedTime",
                table: "HelpdeskTicketHistories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ConsultantMappings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ApproverMappings");
        }
    }
}