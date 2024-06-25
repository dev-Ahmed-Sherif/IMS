using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class VendorTablesNoSeller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderCommittees_HrEmployee_EmployeeId",
                table: "ProTenderCommittees");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderCommittees_ProTenderCommitteeRoles_RoleId",
                table: "ProTenderCommittees");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderOpenings_ProVendors_VendorId",
                table: "ProTenderOpenings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderSelections_ProTenderDetails_TenderDetailsId",
                table: "ProTenderSelections");

            migrationBuilder.DropIndex(
                name: "IX_ProTenderSelections_TenderDetailsId",
                table: "ProTenderSelections");

            migrationBuilder.DropIndex(
                name: "IX_ProTenderOpenings_VendorId",
                table: "ProTenderOpenings");

            migrationBuilder.DropIndex(
                name: "IX_ProTenderCommittees_EmployeeId",
                table: "ProTenderCommittees");

            migrationBuilder.DropColumn(
                name: "TenderDetailsId",
                table: "ProTenderSelections");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "ProTenderOpenings");

            migrationBuilder.DropColumn(
                name: "Close",
                table: "ProTenderCommittees");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "ProTenderCommittees");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "ProTenderCommittees",
                newName: "StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ProTenderCommittees_RoleId",
                table: "ProTenderCommittees",
                newName: "IX_ProTenderCommittees_StatusId");

            migrationBuilder.AddColumn<string>(
                name: "AddedValueTaxUrl",
                table: "ProVendors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnionCardUrl",
                table: "ProVendors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProTenderDetailsId",
                table: "ProTenderSelections",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ProTenderCommittees",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProTenderCommitteeMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderCommitteeId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProTenderOpeningId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProTenderCommitteeMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProTenderCommitteeMember_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProTenderCommitteeMember_ProTenderCommitteeRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ProTenderCommitteeRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProTenderCommitteeMember_ProTenderCommittees_TenderCommitteeId",
                        column: x => x.TenderCommitteeId,
                        principalTable: "ProTenderCommittees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProTenderCommitteeMember_ProTenderOpenings_ProTenderOpeningId",
                        column: x => x.ProTenderOpeningId,
                        principalTable: "ProTenderOpenings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderSelections_ProTenderDetailsId",
                table: "ProTenderSelections",
                column: "ProTenderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderCommitteeMember_EmployeeId",
                table: "ProTenderCommitteeMember",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderCommitteeMember_ProTenderOpeningId",
                table: "ProTenderCommitteeMember",
                column: "ProTenderOpeningId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderCommitteeMember_RoleId",
                table: "ProTenderCommitteeMember",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderCommitteeMember_TenderCommitteeId",
                table: "ProTenderCommitteeMember",
                column: "TenderCommitteeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderCommittees_ProTenderOpeningStatuses_StatusId",
                table: "ProTenderCommittees",
                column: "StatusId",
                principalTable: "ProTenderOpeningStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderSelections_ProTenderDetails_ProTenderDetailsId",
                table: "ProTenderSelections",
                column: "ProTenderDetailsId",
                principalTable: "ProTenderDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderCommittees_ProTenderOpeningStatuses_StatusId",
                table: "ProTenderCommittees");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderSelections_ProTenderDetails_ProTenderDetailsId",
                table: "ProTenderSelections");

            migrationBuilder.DropTable(
                name: "ProTenderCommitteeMember");

            migrationBuilder.DropIndex(
                name: "IX_ProTenderSelections_ProTenderDetailsId",
                table: "ProTenderSelections");

            migrationBuilder.DropColumn(
                name: "AddedValueTaxUrl",
                table: "ProVendors");

            migrationBuilder.DropColumn(
                name: "UnionCardUrl",
                table: "ProVendors");

            migrationBuilder.DropColumn(
                name: "ProTenderDetailsId",
                table: "ProTenderSelections");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "ProTenderCommittees",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_ProTenderCommittees_StatusId",
                table: "ProTenderCommittees",
                newName: "IX_ProTenderCommittees_RoleId");

            migrationBuilder.AddColumn<int>(
                name: "TenderDetailsId",
                table: "ProTenderSelections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "ProTenderOpenings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ProTenderCommittees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Close",
                table: "ProTenderCommittees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "ProTenderCommittees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderSelections_TenderDetailsId",
                table: "ProTenderSelections",
                column: "TenderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderOpenings_VendorId",
                table: "ProTenderOpenings",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderCommittees_EmployeeId",
                table: "ProTenderCommittees",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderCommittees_HrEmployee_EmployeeId",
                table: "ProTenderCommittees",
                column: "EmployeeId",
                principalTable: "HrEmployee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderCommittees_ProTenderCommitteeRoles_RoleId",
                table: "ProTenderCommittees",
                column: "RoleId",
                principalTable: "ProTenderCommitteeRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderOpenings_ProVendors_VendorId",
                table: "ProTenderOpenings",
                column: "VendorId",
                principalTable: "ProVendors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderSelections_ProTenderDetails_TenderDetailsId",
                table: "ProTenderSelections",
                column: "TenderDetailsId",
                principalTable: "ProTenderDetails",
                principalColumn: "Id");
        }
    }
}
