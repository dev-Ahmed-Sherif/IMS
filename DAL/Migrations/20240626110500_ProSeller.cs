using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProSeller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProPurchaseOrders_ProSeller_SellerId",
                table: "ProPurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProQuotations_ProSeller_SellerId",
                table: "ProQuotations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderCommittees_HrEmployee_EmployeeId",
                table: "ProTenderCommittees");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderCommittees_ProTenderCommitteeRoles_RoleId",
                table: "ProTenderCommittees");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderOpenings_ProSeller_SellerId",
                table: "ProTenderOpenings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderSelections_ProTenderDetails_TenderDetailsId",
                table: "ProTenderSelections");

            migrationBuilder.DropForeignKey(
                name: "FK_StrAdd_ProSeller_SellerId",
                table: "StrAdd");

            migrationBuilder.DropTable(
                name: "ProContractorTypes");

            migrationBuilder.DropTable(
                name: "ProSellerTypes");

            migrationBuilder.DropTable(
                name: "ProTenderSellerReqs");

            migrationBuilder.DropTable(
                name: "ProContractor");

            migrationBuilder.DropTable(
                name: "ProSupplierTypes");

            migrationBuilder.DropTable(
                name: "ProTenderSellerReqSendType");

            migrationBuilder.DropIndex(
                name: "IX_ProTenderSelections_TenderDetailsId",
                table: "ProTenderSelections");

            migrationBuilder.DropIndex(
                name: "IX_ProTenderOpenings_SellerId",
                table: "ProTenderOpenings");

            migrationBuilder.DropIndex(
                name: "IX_ProTenderCommittees_EmployeeId",
                table: "ProTenderCommittees");

            migrationBuilder.DropColumn(
                name: "TenderDetailsId",
                table: "ProTenderSelections");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "ProTenderOpenings");

            migrationBuilder.DropColumn(
                name: "Close",
                table: "ProTenderCommittees");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "ProTenderCommittees");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "StrAdd",
                newName: "VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_StrAdd_SellerId",
                table: "StrAdd",
                newName: "IX_StrAdd_VendorId");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "ProTenderCommittees",
                newName: "StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ProTenderCommittees_RoleId",
                table: "ProTenderCommittees",
                newName: "IX_ProTenderCommittees_StatusId");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "ProQuotations",
                newName: "VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProQuotations_SellerId",
                table: "ProQuotations",
                newName: "IX_ProQuotations_VendorId");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "ProPurchaseOrders",
                newName: "VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProPurchaseOrders_SellerId",
                table: "ProPurchaseOrders",
                newName: "IX_ProPurchaseOrders_VendorId");

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

            migrationBuilder.AddColumn<string>(
                name: "AddedValueTaxUrl",
                table: "ProSeller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IndusterialRegister",
                table: "ProSeller",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TheLevel",
                table: "ProSeller",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnionCardUrl",
                table: "ProSeller",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "ProTenderVendorReqSendType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProTenderVendorReqSendType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProVendorTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    OperationTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProVendorTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProVendorTypes_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProVendorTypes_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProVendorTypes_ProOperationType_OperationTypeId",
                        column: x => x.OperationTypeId,
                        principalTable: "ProOperationType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProTenderVendorReqs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SendTypeId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProTenderVendorReqs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProTenderVendorReqs_ProSeller_VendorId",
                        column: x => x.VendorId,
                        principalTable: "ProSeller",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProTenderVendorReqs_ProTenderVendorReqSendType_SendTypeId",
                        column: x => x.SendTypeId,
                        principalTable: "ProTenderVendorReqSendType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProTenderVendorReqs_ProTender_TenderId",
                        column: x => x.TenderId,
                        principalTable: "ProTender",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProVendorsTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    VendorTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    HrCityStateId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProVendorsTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProVendorsTypes_HrCityState_HrCityStateId",
                        column: x => x.HrCityStateId,
                        principalTable: "HrCityState",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProVendorsTypes_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProVendorsTypes_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProVendorsTypes_ProSeller_VendorId",
                        column: x => x.VendorId,
                        principalTable: "ProSeller",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProVendorsTypes_ProVendorTypes_VendorTypeId",
                        column: x => x.VendorTypeId,
                        principalTable: "ProVendorTypes",
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

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderVendorReqs_SendTypeId",
                table: "ProTenderVendorReqs",
                column: "SendTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderVendorReqs_TenderId",
                table: "ProTenderVendorReqs",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderVendorReqs_VendorId",
                table: "ProTenderVendorReqs",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProVendorsTypes_CreatedByID",
                table: "ProVendorsTypes",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProVendorsTypes_HrCityStateId",
                table: "ProVendorsTypes",
                column: "HrCityStateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProVendorsTypes_UpdateByID",
                table: "ProVendorsTypes",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProVendorsTypes_VendorId",
                table: "ProVendorsTypes",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProVendorsTypes_VendorTypeId",
                table: "ProVendorsTypes",
                column: "VendorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProVendorTypes_CreatedByID",
                table: "ProVendorTypes",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProVendorTypes_OperationTypeId",
                table: "ProVendorTypes",
                column: "OperationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProVendorTypes_UpdateByID",
                table: "ProVendorTypes",
                column: "UpdateByID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProPurchaseOrders_ProSeller_VendorId",
                table: "ProPurchaseOrders",
                column: "VendorId",
                principalTable: "ProSeller",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProQuotations_ProSeller_VendorId",
                table: "ProQuotations",
                column: "VendorId",
                principalTable: "ProSeller",
                principalColumn: "Id");

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
                name: "FK_StrAdd_ProSeller_VendorId",
                table: "StrAdd",
                column: "VendorId",
                principalTable: "ProSeller",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProPurchaseOrders_ProSeller_VendorId",
                table: "ProPurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProQuotations_ProSeller_VendorId",
                table: "ProQuotations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderCommittees_ProTenderOpeningStatuses_StatusId",
                table: "ProTenderCommittees");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderSelections_ProTenderDetails_ProTenderDetailsId",
                table: "ProTenderSelections");

            migrationBuilder.DropForeignKey(
                name: "FK_StrAdd_ProSeller_VendorId",
                table: "StrAdd");

            migrationBuilder.DropTable(
                name: "ProTenderCommitteeMember");

            migrationBuilder.DropTable(
                name: "ProTenderVendorReqs");

            migrationBuilder.DropTable(
                name: "ProVendorsTypes");

            migrationBuilder.DropTable(
                name: "ProTenderVendorReqSendType");

            migrationBuilder.DropTable(
                name: "ProVendorTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProTenderSelections_ProTenderDetailsId",
                table: "ProTenderSelections");

            migrationBuilder.DropColumn(
                name: "ProTenderDetailsId",
                table: "ProTenderSelections");

            migrationBuilder.DropColumn(
                name: "AddedValueTaxUrl",
                table: "ProSeller");

            migrationBuilder.DropColumn(
                name: "IndusterialRegister",
                table: "ProSeller");

            migrationBuilder.DropColumn(
                name: "TheLevel",
                table: "ProSeller");

            migrationBuilder.DropColumn(
                name: "UnionCardUrl",
                table: "ProSeller");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                table: "StrAdd",
                newName: "SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_StrAdd_VendorId",
                table: "StrAdd",
                newName: "IX_StrAdd_SellerId");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "ProTenderCommittees",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_ProTenderCommittees_StatusId",
                table: "ProTenderCommittees",
                newName: "IX_ProTenderCommittees_RoleId");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                table: "ProQuotations",
                newName: "SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_ProQuotations_VendorId",
                table: "ProQuotations",
                newName: "IX_ProQuotations_SellerId");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                table: "ProPurchaseOrders",
                newName: "SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_ProPurchaseOrders_VendorId",
                table: "ProPurchaseOrders",
                newName: "IX_ProPurchaseOrders_SellerId");

            migrationBuilder.AddColumn<int>(
                name: "TenderDetailsId",
                table: "ProTenderSelections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
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

            migrationBuilder.CreateTable(
                name: "ProContractor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CityStateId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IndusterialRegister = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxCard = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TheLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProContractor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProContractor_HrCityState_CityStateId",
                        column: x => x.CityStateId,
                        principalTable: "HrCityState",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProContractor_HrCity_CityId",
                        column: x => x.CityId,
                        principalTable: "HrCity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProContractor_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProContractor_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProSupplierTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProSupplierTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProSupplierTypes_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProSupplierTypes_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProTenderSellerReqSendType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdateByID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProTenderSellerReqSendType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProContractorTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractorId = table.Column<int>(type: "int", nullable: false),
                    ContractorTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HrCityStateId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProContractorTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProContractorTypes_HrCityState_HrCityStateId",
                        column: x => x.HrCityStateId,
                        principalTable: "HrCityState",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProContractorTypes_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProContractorTypes_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProContractorTypes_ProContractor_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "ProContractor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProContractorTypes_ProSupplierTypes_ContractorTypeId",
                        column: x => x.ContractorTypeId,
                        principalTable: "ProSupplierTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProSellerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    SellerTypeId = table.Column<int>(type: "int", nullable: false),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProSellerTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProSellerTypes_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProSellerTypes_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProSellerTypes_ProSeller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "ProSeller",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProSellerTypes_ProSupplierTypes_SellerTypeId",
                        column: x => x.SellerTypeId,
                        principalTable: "ProSupplierTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProTenderSellerReqs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    SendTypeId = table.Column<int>(type: "int", nullable: false),
                    TenderId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateByID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProTenderSellerReqs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProTenderSellerReqs_ProSeller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "ProSeller",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProTenderSellerReqs_ProTenderSellerReqSendType_SendTypeId",
                        column: x => x.SendTypeId,
                        principalTable: "ProTenderSellerReqSendType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProTenderSellerReqs_ProTender_TenderId",
                        column: x => x.TenderId,
                        principalTable: "ProTender",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderSelections_TenderDetailsId",
                table: "ProTenderSelections",
                column: "TenderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderOpenings_SellerId",
                table: "ProTenderOpenings",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderCommittees_EmployeeId",
                table: "ProTenderCommittees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProContractor_CityId",
                table: "ProContractor",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProContractor_CityStateId",
                table: "ProContractor",
                column: "CityStateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProContractor_CreatedByID",
                table: "ProContractor",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProContractor_UpdateByID",
                table: "ProContractor",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProContractorTypes_ContractorId",
                table: "ProContractorTypes",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProContractorTypes_ContractorTypeId",
                table: "ProContractorTypes",
                column: "ContractorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProContractorTypes_CreatedByID",
                table: "ProContractorTypes",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProContractorTypes_HrCityStateId",
                table: "ProContractorTypes",
                column: "HrCityStateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProContractorTypes_UpdateByID",
                table: "ProContractorTypes",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProSellerTypes_CreatedByID",
                table: "ProSellerTypes",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProSellerTypes_SellerId",
                table: "ProSellerTypes",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProSellerTypes_SellerTypeId",
                table: "ProSellerTypes",
                column: "SellerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProSellerTypes_UpdateByID",
                table: "ProSellerTypes",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProSupplierTypes_CreatedByID",
                table: "ProSupplierTypes",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProSupplierTypes_UpdateByID",
                table: "ProSupplierTypes",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderSellerReqs_SellerId",
                table: "ProTenderSellerReqs",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderSellerReqs_SendTypeId",
                table: "ProTenderSellerReqs",
                column: "SendTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderSellerReqs_TenderId",
                table: "ProTenderSellerReqs",
                column: "TenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProPurchaseOrders_ProSeller_SellerId",
                table: "ProPurchaseOrders",
                column: "SellerId",
                principalTable: "ProSeller",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProQuotations_ProSeller_SellerId",
                table: "ProQuotations",
                column: "SellerId",
                principalTable: "ProSeller",
                principalColumn: "Id");

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
                name: "FK_ProTenderOpenings_ProSeller_SellerId",
                table: "ProTenderOpenings",
                column: "SellerId",
                principalTable: "ProSeller",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderSelections_ProTenderDetails_TenderDetailsId",
                table: "ProTenderSelections",
                column: "TenderDetailsId",
                principalTable: "ProTenderDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StrAdd_ProSeller_SellerId",
                table: "StrAdd",
                column: "SellerId",
                principalTable: "ProSeller",
                principalColumn: "Id");
        }
    }
}
