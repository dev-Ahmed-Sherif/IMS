using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProMembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderCommitteeMember_HrEmployee_EmployeeId",
                table: "ProTenderCommitteeMember");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderCommitteeMember_ProTenderCommitteeRoles_RoleId",
                table: "ProTenderCommitteeMember");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderCommitteeMember_ProTenderCommittees_TenderCommitteeId",
                table: "ProTenderCommitteeMember");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderCommitteeMember_ProTenderOpenings_ProTenderOpeningId",
                table: "ProTenderCommitteeMember");

            migrationBuilder.DropForeignKey(
                name: "FK_ProVendorTypes_ProOperationType_OperationTypeId",
                table: "ProVendorTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProVendorTypes_OperationTypeId",
                table: "ProVendorTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProTenderCommitteeMember",
                table: "ProTenderCommitteeMember");

            migrationBuilder.DropColumn(
                name: "OperationTypeId",
                table: "ProVendorTypes");

            migrationBuilder.RenameTable(
                name: "ProTenderCommitteeMember",
                newName: "ProTenderCommitteeMembers");

            migrationBuilder.RenameIndex(
                name: "IX_ProTenderCommitteeMember_TenderCommitteeId",
                table: "ProTenderCommitteeMembers",
                newName: "IX_ProTenderCommitteeMembers_TenderCommitteeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProTenderCommitteeMember_RoleId",
                table: "ProTenderCommitteeMembers",
                newName: "IX_ProTenderCommitteeMembers_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_ProTenderCommitteeMember_ProTenderOpeningId",
                table: "ProTenderCommitteeMembers",
                newName: "IX_ProTenderCommitteeMembers_ProTenderOpeningId");

            migrationBuilder.RenameIndex(
                name: "IX_ProTenderCommitteeMember_EmployeeId",
                table: "ProTenderCommitteeMembers",
                newName: "IX_ProTenderCommitteeMembers_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProTenderCommitteeMembers",
                table: "ProTenderCommitteeMembers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProTenderOpeningDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuotationId = table.Column<int>(type: "int", nullable: false),
                    TenderOpeningId = table.Column<int>(type: "int", nullable: false),
                    Accepted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProTenderOpeningDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProTenderOpeningDetails_ProQuotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "ProQuotations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProTenderOpeningDetails_ProTenderOpenings_TenderOpeningId",
                        column: x => x.TenderOpeningId,
                        principalTable: "ProTenderOpenings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProTenderOpeningMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderOpeningId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProTenderOpeningMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProTenderOpeningMembers_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProTenderOpeningMembers_ProTenderCommitteeRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ProTenderCommitteeRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProTenderOpeningMembers_ProTenderOpenings_TenderOpeningId",
                        column: x => x.TenderOpeningId,
                        principalTable: "ProTenderOpenings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProVendorAttachment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProSellerId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProVendorAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProVendorAttachment_ProVendors_ProSellerId",
                        column: x => x.ProSellerId,
                        principalTable: "ProVendors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderOpeningDetails_QuotationId",
                table: "ProTenderOpeningDetails",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderOpeningDetails_TenderOpeningId",
                table: "ProTenderOpeningDetails",
                column: "TenderOpeningId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderOpeningMembers_EmployeeId",
                table: "ProTenderOpeningMembers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderOpeningMembers_RoleId",
                table: "ProTenderOpeningMembers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderOpeningMembers_TenderOpeningId",
                table: "ProTenderOpeningMembers",
                column: "TenderOpeningId");

            migrationBuilder.CreateIndex(
                name: "IX_ProVendorAttachment_ProSellerId",
                table: "ProVendorAttachment",
                column: "ProSellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderCommitteeMembers_HrEmployee_EmployeeId",
                table: "ProTenderCommitteeMembers",
                column: "EmployeeId",
                principalTable: "HrEmployee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderCommitteeMembers_ProTenderCommitteeRoles_RoleId",
                table: "ProTenderCommitteeMembers",
                column: "RoleId",
                principalTable: "ProTenderCommitteeRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderCommitteeMembers_ProTenderCommittees_TenderCommitteeId",
                table: "ProTenderCommitteeMembers",
                column: "TenderCommitteeId",
                principalTable: "ProTenderCommittees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderCommitteeMembers_ProTenderOpenings_ProTenderOpeningId",
                table: "ProTenderCommitteeMembers",
                column: "ProTenderOpeningId",
                principalTable: "ProTenderOpenings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderCommitteeMembers_HrEmployee_EmployeeId",
                table: "ProTenderCommitteeMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderCommitteeMembers_ProTenderCommitteeRoles_RoleId",
                table: "ProTenderCommitteeMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderCommitteeMembers_ProTenderCommittees_TenderCommitteeId",
                table: "ProTenderCommitteeMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderCommitteeMembers_ProTenderOpenings_ProTenderOpeningId",
                table: "ProTenderCommitteeMembers");

            migrationBuilder.DropTable(
                name: "ProTenderOpeningDetails");

            migrationBuilder.DropTable(
                name: "ProTenderOpeningMembers");

            migrationBuilder.DropTable(
                name: "ProVendorAttachment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProTenderCommitteeMembers",
                table: "ProTenderCommitteeMembers");

            migrationBuilder.RenameTable(
                name: "ProTenderCommitteeMembers",
                newName: "ProTenderCommitteeMember");

            migrationBuilder.RenameIndex(
                name: "IX_ProTenderCommitteeMembers_TenderCommitteeId",
                table: "ProTenderCommitteeMember",
                newName: "IX_ProTenderCommitteeMember_TenderCommitteeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProTenderCommitteeMembers_RoleId",
                table: "ProTenderCommitteeMember",
                newName: "IX_ProTenderCommitteeMember_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_ProTenderCommitteeMembers_ProTenderOpeningId",
                table: "ProTenderCommitteeMember",
                newName: "IX_ProTenderCommitteeMember_ProTenderOpeningId");

            migrationBuilder.RenameIndex(
                name: "IX_ProTenderCommitteeMembers_EmployeeId",
                table: "ProTenderCommitteeMember",
                newName: "IX_ProTenderCommitteeMember_EmployeeId");

            migrationBuilder.AddColumn<int>(
                name: "OperationTypeId",
                table: "ProVendorTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProTenderCommitteeMember",
                table: "ProTenderCommitteeMember",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProVendorTypes_OperationTypeId",
                table: "ProVendorTypes",
                column: "OperationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderCommitteeMember_HrEmployee_EmployeeId",
                table: "ProTenderCommitteeMember",
                column: "EmployeeId",
                principalTable: "HrEmployee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderCommitteeMember_ProTenderCommitteeRoles_RoleId",
                table: "ProTenderCommitteeMember",
                column: "RoleId",
                principalTable: "ProTenderCommitteeRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderCommitteeMember_ProTenderCommittees_TenderCommitteeId",
                table: "ProTenderCommitteeMember",
                column: "TenderCommitteeId",
                principalTable: "ProTenderCommittees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderCommitteeMember_ProTenderOpenings_ProTenderOpeningId",
                table: "ProTenderCommitteeMember",
                column: "ProTenderOpeningId",
                principalTable: "ProTenderOpenings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProVendorTypes_ProOperationType_OperationTypeId",
                table: "ProVendorTypes",
                column: "OperationTypeId",
                principalTable: "ProOperationType",
                principalColumn: "Id");
        }
    }
}
