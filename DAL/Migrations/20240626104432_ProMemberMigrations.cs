using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProMemberMigrations : Migration
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
                name: "ProContractorType");

            migrationBuilder.DropTable(
                name: "ProContractor");

            migrationBuilder.DropTable(
                name: "ProSellerType");

            migrationBuilder.DropTable(
                name: "ProSeller");

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
                name: "ProVendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    TheLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxCard = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CityStateId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IndusterialRegister = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CommericalRegister = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UnionCardUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedValueTaxUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProVendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProVendors_HrCityState_CityStateId",
                        column: x => x.CityStateId,
                        principalTable: "HrCityState",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProVendors_HrCity_CityId",
                        column: x => x.CityId,
                        principalTable: "HrCity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProVendors_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProVendors_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProVendorTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "VlDrivierLicenseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlDrivierLicenseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlGarages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlGarages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlItineraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlItineraries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlManufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlStaffPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlStaffPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlStaffStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlStaffStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlVehicleStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlVehicleStatuses", x => x.Id);
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
                        name: "FK_ProTenderVendorReqs_ProTenderVendorReqSendType_SendTypeId",
                        column: x => x.SendTypeId,
                        principalTable: "ProTenderVendorReqSendType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProTenderVendorReqs_ProTender_TenderId",
                        column: x => x.TenderId,
                        principalTable: "ProTender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProTenderVendorReqs_ProVendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "ProVendors",
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
                    ProVendorId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_ProVendorAttachment_ProVendors_ProVendorId",
                        column: x => x.ProVendorId,
                        principalTable: "ProVendors",
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
                        name: "FK_ProVendorsTypes_ProVendorTypes_VendorTypeId",
                        column: x => x.VendorTypeId,
                        principalTable: "ProVendorTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProVendorsTypes_ProVendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "ProVendors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VlStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlStaff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VlStaff_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VlStaff_VlStaffPositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "VlStaffPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VlStaff_VlStaffStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "VlStaffStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VlVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardNo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ChassisNo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MotorNo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VlVehicles_VlManufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "VlManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VlVehicles_VlModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "VlModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VlVehicles_VlTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "VlTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VlVehicles_VlVehicleStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "VlVehicleStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VlDrivierLicenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlDrivierLicenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VlDrivierLicenses_VlDrivierLicenseTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "VlDrivierLicenseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VlDrivierLicenses_VlStaff_DriverId",
                        column: x => x.DriverId,
                        principalTable: "VlStaff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VlVehicleGarages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    GarageId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlVehicleGarages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VlVehicleGarages_VlGarages_GarageId",
                        column: x => x.GarageId,
                        principalTable: "VlGarages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VlVehicleGarages_VlVehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VlVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VlVehicleItineraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    ItineraryId = table.Column<int>(type: "int", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlVehicleItineraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VlVehicleItineraries_VlItineraries_ItineraryId",
                        column: x => x.ItineraryId,
                        principalTable: "VlItineraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VlVehicleItineraries_VlVehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VlVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VlVehicleJobOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: false),
                    GarageManagerId = table.Column<int>(type: "int", nullable: false),
                    ItineraryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Companion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeterStart = table.Column<int>(type: "int", nullable: false),
                    MeterEnd = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlVehicleJobOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VlVehicleJobOrders_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VlVehicleJobOrders_VlItineraries_ItineraryId",
                        column: x => x.ItineraryId,
                        principalTable: "VlItineraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VlVehicleJobOrders_VlStaff_DriverId",
                        column: x => x.DriverId,
                        principalTable: "VlStaff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VlVehicleJobOrders_VlStaff_GarageManagerId",
                        column: x => x.GarageManagerId,
                        principalTable: "VlStaff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VlVehicleJobOrders_VlStaff_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "VlStaff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VlVehicleJobOrders_VlVehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VlVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VlVehicleLicenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlVehicleLicenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VlVehicleLicenses_VlVehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VlVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_ProVendorAttachment_ProVendorId",
                table: "ProVendorAttachment",
                column: "ProVendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProVendors_CityId",
                table: "ProVendors",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProVendors_CityStateId",
                table: "ProVendors",
                column: "CityStateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProVendors_CreatedByID",
                table: "ProVendors",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProVendors_UpdateByID",
                table: "ProVendors",
                column: "UpdateByID");

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
                name: "IX_ProVendorTypes_UpdateByID",
                table: "ProVendorTypes",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_VlDrivierLicenses_DriverId",
                table: "VlDrivierLicenses",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_VlDrivierLicenses_TypeId",
                table: "VlDrivierLicenses",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VlDrivierLicenseTypes_Name",
                table: "VlDrivierLicenseTypes",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VlGarages_Name",
                table: "VlGarages",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VlItineraries_Name",
                table: "VlItineraries",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VlManufacturers_Name",
                table: "VlManufacturers",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VlModels_Name",
                table: "VlModels",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VlStaff_EmployeeId",
                table: "VlStaff",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_VlStaff_PositionId",
                table: "VlStaff",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_VlStaff_StatusId",
                table: "VlStaff",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_VlStaffPositions_Name",
                table: "VlStaffPositions",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VlStaffStatuses_Name",
                table: "VlStaffStatuses",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VlTypes_Name",
                table: "VlTypes",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleGarages_GarageId",
                table: "VlVehicleGarages",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleGarages_VehicleId",
                table: "VlVehicleGarages",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleItineraries_ItineraryId",
                table: "VlVehicleItineraries",
                column: "ItineraryId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleItineraries_VehicleId",
                table: "VlVehicleItineraries",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleJobOrders_DriverId",
                table: "VlVehicleJobOrders",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleJobOrders_EmployeeId",
                table: "VlVehicleJobOrders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleJobOrders_GarageManagerId",
                table: "VlVehicleJobOrders",
                column: "GarageManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleJobOrders_ItineraryId",
                table: "VlVehicleJobOrders",
                column: "ItineraryId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleJobOrders_SupervisorId",
                table: "VlVehicleJobOrders",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleJobOrders_VehicleId",
                table: "VlVehicleJobOrders",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleLicenses_VehicleId",
                table: "VlVehicleLicenses",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicles_BoardNo_ChassisNo_MotorNo",
                table: "VlVehicles",
                columns: new[] { "BoardNo", "ChassisNo", "MotorNo" },
                unique: true,
                filter: "[BoardNo] IS NOT NULL AND [ChassisNo] IS NOT NULL AND [MotorNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicles_ManufacturerId",
                table: "VlVehicles",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicles_ModelId",
                table: "VlVehicles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicles_StatusId",
                table: "VlVehicles",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicles_TypeId",
                table: "VlVehicles",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleStatuses_Name",
                table: "VlVehicleStatuses",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ProPurchaseOrders_ProVendors_VendorId",
                table: "ProPurchaseOrders",
                column: "VendorId",
                principalTable: "ProVendors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProQuotations_ProVendors_VendorId",
                table: "ProQuotations",
                column: "VendorId",
                principalTable: "ProVendors",
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
                name: "FK_StrAdd_ProVendors_VendorId",
                table: "StrAdd",
                column: "VendorId",
                principalTable: "ProVendors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProPurchaseOrders_ProVendors_VendorId",
                table: "ProPurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProQuotations_ProVendors_VendorId",
                table: "ProQuotations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderCommittees_ProTenderOpeningStatuses_StatusId",
                table: "ProTenderCommittees");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderSelections_ProTenderDetails_ProTenderDetailsId",
                table: "ProTenderSelections");

            migrationBuilder.DropForeignKey(
                name: "FK_StrAdd_ProVendors_VendorId",
                table: "StrAdd");

            migrationBuilder.DropTable(
                name: "ProTenderCommitteeMember");

            migrationBuilder.DropTable(
                name: "ProTenderVendorReqs");

            migrationBuilder.DropTable(
                name: "ProVendorAttachment");

            migrationBuilder.DropTable(
                name: "ProVendorsTypes");

            migrationBuilder.DropTable(
                name: "VlDrivierLicenses");

            migrationBuilder.DropTable(
                name: "VlVehicleGarages");

            migrationBuilder.DropTable(
                name: "VlVehicleItineraries");

            migrationBuilder.DropTable(
                name: "VlVehicleJobOrders");

            migrationBuilder.DropTable(
                name: "VlVehicleLicenses");

            migrationBuilder.DropTable(
                name: "ProTenderVendorReqSendType");

            migrationBuilder.DropTable(
                name: "ProVendorTypes");

            migrationBuilder.DropTable(
                name: "ProVendors");

            migrationBuilder.DropTable(
                name: "VlDrivierLicenseTypes");

            migrationBuilder.DropTable(
                name: "VlGarages");

            migrationBuilder.DropTable(
                name: "VlItineraries");

            migrationBuilder.DropTable(
                name: "VlStaff");

            migrationBuilder.DropTable(
                name: "VlVehicles");

            migrationBuilder.DropTable(
                name: "VlStaffPositions");

            migrationBuilder.DropTable(
                name: "VlStaffStatuses");

            migrationBuilder.DropTable(
                name: "VlManufacturers");

            migrationBuilder.DropTable(
                name: "VlModels");

            migrationBuilder.DropTable(
                name: "VlTypes");

            migrationBuilder.DropTable(
                name: "VlVehicleStatuses");

            migrationBuilder.DropIndex(
                name: "IX_ProTenderSelections_ProTenderDetailsId",
                table: "ProTenderSelections");

            migrationBuilder.DropColumn(
                name: "ProTenderDetailsId",
                table: "ProTenderSelections");

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
                name: "ProContractorType",
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
                    table.PrimaryKey("PK_ProContractorType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProContractorType_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProContractorType_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProSeller",
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
                    CommericalRegister = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxCard = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProSeller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProSeller_HrCityState_CityStateId",
                        column: x => x.CityStateId,
                        principalTable: "HrCityState",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProSeller_HrCity_CityId",
                        column: x => x.CityId,
                        principalTable: "HrCity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProSeller_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProSeller_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProSellerType",
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
                    table.PrimaryKey("PK_ProSellerType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProSellerType_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProSellerType_PrUser_UpdateByID",
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
                        name: "FK_ProContractorTypes_ProContractorType_ContractorTypeId",
                        column: x => x.ContractorTypeId,
                        principalTable: "ProContractorType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProContractorTypes_ProContractor_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "ProContractor",
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
                        name: "FK_ProSellerTypes_ProSellerType_SellerTypeId",
                        column: x => x.SellerTypeId,
                        principalTable: "ProSellerType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProSellerTypes_ProSeller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "ProSeller",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProTenderSellerReqs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    SendTypeId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
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
                name: "IX_ProContractorType_CreatedByID",
                table: "ProContractorType",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProContractorType_UpdateByID",
                table: "ProContractorType",
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
                name: "IX_ProSeller_CityId",
                table: "ProSeller",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProSeller_CityStateId",
                table: "ProSeller",
                column: "CityStateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProSeller_CreatedByID",
                table: "ProSeller",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProSeller_UpdateByID",
                table: "ProSeller",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProSellerType_CreatedByID",
                table: "ProSellerType",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProSellerType_UpdateByID",
                table: "ProSellerType",
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
