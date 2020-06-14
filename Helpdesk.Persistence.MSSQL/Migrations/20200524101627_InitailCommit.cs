using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Helpdesk.Persistence.MSSQL.Migrations
{
    public partial class InitailCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    CountyCode = table.Column<string>(maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssueCatagory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    IssueCatagoryCode = table.Column<string>(maxLength: 6, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueCatagory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssueType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IssueTypeCode = table.Column<string>(maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    LocationTypeCode = table.Column<string>(maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    StatusCode = table.Column<string>(maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssueSubCatagories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    IssueSubCatagoryCode = table.Column<string>(maxLength: 6, nullable: false),
                    IssueCatagoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueSubCatagories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueSubCatagories_IssueCatagory",
                        column: x => x.IssueCatagoryId,
                        principalTable: "IssueCatagory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: false),
                    LocationCode = table.Column<string>(maxLength: 6, nullable: false),
                    LocationTypeId = table.Column<Guid>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Country",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locations_LocationType",
                        column: x => x.LocationTypeId,
                        principalTable: "LocationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApproverMappings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: false),
                    IssueTypeId = table.Column<Guid>(nullable: false),
                    IssueSubCatagoryId = table.Column<Guid>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApproverMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApproverMappings_IssueSubCatagories_IssueSubCatagoryId",
                        column: x => x.IssueSubCatagoryId,
                        principalTable: "IssueSubCatagories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApproverMappings_IssueType_IssueTypeId",
                        column: x => x.IssueTypeId,
                        principalTable: "IssueType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApproverMappings_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApproverMappings_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsultantMappings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: false),
                    IssueTypeId = table.Column<Guid>(nullable: false),
                    IssueSubCatagoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultantMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultantMappings_IssueSubCatagories_IssueSubCatagoryId",
                        column: x => x.IssueSubCatagoryId,
                        principalTable: "IssueSubCatagories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultantMappings_IssueType_IssueTypeId",
                        column: x => x.IssueTypeId,
                        principalTable: "IssueType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultantMappings_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HelpdeskTickets",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TicketNumber = table.Column<string>(maxLength: 25, nullable: false),
                    ReportedBy = table.Column<Guid>(nullable: false),
                    Detail = table.Column<string>(nullable: false),
                    PriorityLevel = table.Column<short>(type: "smallint", nullable: false),
                    IssueSubCatagoryId = table.Column<Guid>(nullable: false),
                    IssueTypeId = table.Column<Guid>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpdeskTickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_HelpdeskTickets_IssueSubCatagories_IssueSubCatagoryId",
                        column: x => x.IssueSubCatagoryId,
                        principalTable: "IssueSubCatagories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HelpdeskTickets_IssueType_IssueTypeId",
                        column: x => x.IssueTypeId,
                        principalTable: "IssueType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HelpdeskTickets_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HelpdeskTickets_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HelpdeskTicketApproval",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TicketId = table.Column<Guid>(nullable: false),
                    Reportedy = table.Column<Guid>(nullable: false),
                    Status = table.Column<Guid>(nullable: false),
                    ApprovalStatus = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpdeskTicketApproval", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HelpdeskTicketApprovals_HelpdeskTicket",
                        column: x => x.TicketId,
                        principalTable: "HelpdeskTickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HelpdeskTicketHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TicketNumber = table.Column<string>(nullable: true),
                    TicketId = table.Column<Guid>(nullable: false),
                    Response = table.Column<string>(nullable: false),
                    Status = table.Column<Guid>(nullable: false),
                    FileCount = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpdeskTicketHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HelpdeskTicketHistories_HelpdeskTicket",
                        column: x => x.TicketId,
                        principalTable: "HelpdeskTickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HelpdeskTicketUploads",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    FileName = table.Column<string>(nullable: false),
                    TicketDetailsId = table.Column<Guid>(nullable: false),
                    HelpdeskTicketHistoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpdeskTicketUploads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HelpdeskTicketUploads_HelpdeskTicketHistories_HelpdeskTicketHistoryId",
                        column: x => x.HelpdeskTicketHistoryId,
                        principalTable: "HelpdeskTicketHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApproverMappings_IssueSubCatagoryId",
                table: "ApproverMappings",
                column: "IssueSubCatagoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ApproverMappings_IssueTypeId",
                table: "ApproverMappings",
                column: "IssueTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApproverMappings_LocationId",
                table: "ApproverMappings",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApproverMappings_StatusId",
                table: "ApproverMappings",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantMappings_IssueSubCatagoryId",
                table: "ConsultantMappings",
                column: "IssueSubCatagoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantMappings_IssueTypeId",
                table: "ConsultantMappings",
                column: "IssueTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantMappings_LocationId",
                table: "ConsultantMappings",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpdeskTicketApproval_TicketId",
                table: "HelpdeskTicketApproval",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpdeskTicketHistories_TicketId",
                table: "HelpdeskTicketHistories",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpdeskTickets_IssueSubCatagoryId",
                table: "HelpdeskTickets",
                column: "IssueSubCatagoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpdeskTickets_IssueTypeId",
                table: "HelpdeskTickets",
                column: "IssueTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpdeskTickets_LocationId",
                table: "HelpdeskTickets",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpdeskTickets_StatusId",
                table: "HelpdeskTickets",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpdeskTicketUploads_HelpdeskTicketHistoryId",
                table: "HelpdeskTicketUploads",
                column: "HelpdeskTicketHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueSubCatagories_IssueCatagoryId",
                table: "IssueSubCatagories",
                column: "IssueCatagoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CountryId",
                table: "Locations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LocationTypeId",
                table: "Locations",
                column: "LocationTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApproverMappings");

            migrationBuilder.DropTable(
                name: "ConsultantMappings");

            migrationBuilder.DropTable(
                name: "HelpdeskTicketApproval");

            migrationBuilder.DropTable(
                name: "HelpdeskTicketUploads");

            migrationBuilder.DropTable(
                name: "HelpdeskTicketHistories");

            migrationBuilder.DropTable(
                name: "HelpdeskTickets");

            migrationBuilder.DropTable(
                name: "IssueSubCatagories");

            migrationBuilder.DropTable(
                name: "IssueType");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "IssueCatagory");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "LocationType");
        }
    }
}