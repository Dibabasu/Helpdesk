using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helpdesk.Persistence.MSSQL.Migrations
{
    public partial class Addlocaitontouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocaitonId",
                table: "User",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_LocationId",
                table: "User",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Locations_LocationId",
                table: "User",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Locations_LocationId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_LocationId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LocaitonId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "User");
        }
    }
}
