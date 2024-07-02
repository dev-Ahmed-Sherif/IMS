using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class LatestProModifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderCommittees_ProTenderOpeningStatuses_StatusId",
                table: "ProTenderCommittees");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderSelections_ProTenderDetails_ProTenderDetailsId",
                table: "ProTenderSelections");

            migrationBuilder.DropForeignKey(
                name: "FK_ProVendorAttachment_ProVendors_ProVendorId",
                table: "ProVendorAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_ProVendorsTypes_ProVendors_ProVendorId",
                table: "ProVendorsTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProVendorsTypes_ProVendorId",
                table: "ProVendorsTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProVendorAttachment_ProVendorId",
                table: "ProVendorAttachment");

            migrationBuilder.DropIndex(
                name: "IX_ProTenderCommittees_StatusId",
                table: "ProTenderCommittees");

            migrationBuilder.DropColumn(
                name: "ProVendorId",
                table: "ProVendorsTypes");

            migrationBuilder.DropColumn(
                name: "AddedValueTaxUrl",
                table: "ProVendors");

            migrationBuilder.DropColumn(
                name: "CommericalRegister",
                table: "ProVendors");

            migrationBuilder.DropColumn(
                name: "IndusterialRegister",
                table: "ProVendors");

            migrationBuilder.DropColumn(
                name: "TaxCard",
                table: "ProVendors");

            migrationBuilder.DropColumn(
                name: "UnionCardUrl",
                table: "ProVendors");

            migrationBuilder.DropColumn(
                name: "ProVendorId",
                table: "ProVendorAttachment");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ProTenderCommittees");

            migrationBuilder.RenameColumn(
                name: "ProTenderDetailsId",
                table: "ProTenderSelections",
                newName: "TenderDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProTenderSelections_ProTenderDetailsId",
                table: "ProTenderSelections",
                newName: "IX_ProTenderSelections_TenderDetailsId");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "ProVendorTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "ProVendorsTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "ProVendors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "ProVendorAttachment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommitteeId",
                table: "ProTenderSelections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ProTenderOpenings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "ProTenderOpenings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TenderOpeningId",
                table: "ProTenderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ProTenderCommittees",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "ProTenderCommittees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Result",
                table: "ProTenderCommittees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ProQuotations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProVendorTypes_Code",
                table: "ProVendorTypes",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_ProVendorTypes_TypeId",
                table: "ProVendorTypes",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProVendorsTypes_VendorId",
                table: "ProVendorsTypes",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProVendorAttachment_VendorId",
                table: "ProVendorAttachment",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderSelections_CommitteeId",
                table: "ProTenderSelections",
                column: "CommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderOpenings_Code",
                table: "ProTenderOpenings",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderDetails_TenderOpeningId",
                table: "ProTenderDetails",
                column: "TenderOpeningId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderCommittees_Code",
                table: "ProTenderCommittees",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProQuotations_Code",
                table: "ProQuotations",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderDetails_ProTenderOpenings_TenderOpeningId",
                table: "ProTenderDetails",
                column: "TenderOpeningId",
                principalTable: "ProTenderOpenings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderSelections_ProTenderCommittees_CommitteeId",
                table: "ProTenderSelections",
                column: "CommitteeId",
                principalTable: "ProTenderCommittees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderSelections_ProTenderDetails_TenderDetailsId",
                table: "ProTenderSelections",
                column: "TenderDetailsId",
                principalTable: "ProTenderDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProVendorAttachment_ProVendors_VendorId",
                table: "ProVendorAttachment",
                column: "VendorId",
                principalTable: "ProVendors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProVendorsTypes_ProVendors_VendorId",
                table: "ProVendorsTypes",
                column: "VendorId",
                principalTable: "ProVendors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProVendorTypes_ProTypes_TypeId",
                table: "ProVendorTypes",
                column: "TypeId",
                principalTable: "ProTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderDetails_ProTenderOpenings_TenderOpeningId",
                table: "ProTenderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderSelections_ProTenderCommittees_CommitteeId",
                table: "ProTenderSelections");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderSelections_ProTenderDetails_TenderDetailsId",
                table: "ProTenderSelections");

            migrationBuilder.DropForeignKey(
                name: "FK_ProVendorAttachment_ProVendors_VendorId",
                table: "ProVendorAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_ProVendorsTypes_ProVendors_VendorId",
                table: "ProVendorsTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProVendorTypes_ProTypes_TypeId",
                table: "ProVendorTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProVendorTypes_Code",
                table: "ProVendorTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProVendorTypes_TypeId",
                table: "ProVendorTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProVendorsTypes_VendorId",
                table: "ProVendorsTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProVendorAttachment_VendorId",
                table: "ProVendorAttachment");

            migrationBuilder.DropIndex(
                name: "IX_ProTenderSelections_CommitteeId",
                table: "ProTenderSelections");

            migrationBuilder.DropIndex(
                name: "IX_ProTenderOpenings_Code",
                table: "ProTenderOpenings");

            migrationBuilder.DropIndex(
                name: "IX_ProTenderDetails_TenderOpeningId",
                table: "ProTenderDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProTenderCommittees_Code",
                table: "ProTenderCommittees");

            migrationBuilder.DropIndex(
                name: "IX_ProQuotations_Code",
                table: "ProQuotations");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "ProVendorTypes");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "ProVendorsTypes");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "ProVendorAttachment");

            migrationBuilder.DropColumn(
                name: "CommitteeId",
                table: "ProTenderSelections");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ProTenderOpenings");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "ProTenderOpenings");

            migrationBuilder.DropColumn(
                name: "TenderOpeningId",
                table: "ProTenderDetails");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ProTenderCommittees");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "ProTenderCommittees");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "ProTenderCommittees");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ProQuotations");

            migrationBuilder.RenameColumn(
                name: "TenderDetailsId",
                table: "ProTenderSelections",
                newName: "ProTenderDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProTenderSelections_TenderDetailsId",
                table: "ProTenderSelections",
                newName: "IX_ProTenderSelections_ProTenderDetailsId");

            migrationBuilder.AddColumn<int>(
                name: "ProVendorId",
                table: "ProVendorsTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "ProVendors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedValueTaxUrl",
                table: "ProVendors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommericalRegister",
                table: "ProVendors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IndusterialRegister",
                table: "ProVendors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxCard",
                table: "ProVendors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnionCardUrl",
                table: "ProVendors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProVendorId",
                table: "ProVendorAttachment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "ProTenderCommittees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProVendorsTypes_ProVendorId",
                table: "ProVendorsTypes",
                column: "ProVendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProVendorAttachment_ProVendorId",
                table: "ProVendorAttachment",
                column: "ProVendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderCommittees_StatusId",
                table: "ProTenderCommittees",
                column: "StatusId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProVendorAttachment_ProVendors_ProVendorId",
                table: "ProVendorAttachment",
                column: "ProVendorId",
                principalTable: "ProVendors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProVendorsTypes_ProVendors_ProVendorId",
                table: "ProVendorsTypes",
                column: "ProVendorId",
                principalTable: "ProVendors",
                principalColumn: "Id");
        }
    }
}
