using Microsoft.EntityFrameworkCore.Migrations;

namespace Helpdesk.Persistence.MSSQL.Migrations
{
    public partial class UpdatedCOuntrytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountyCode",
                table: "Country");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Country",
                maxLength: 6,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Country");

            migrationBuilder.AddColumn<string>(
                name: "CountyCode",
                table: "Country",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");
        }
    }
}
