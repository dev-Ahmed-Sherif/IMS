using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProVendorTables : Migration
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
                name: "FK_ProTenderOpenings_ProSeller_SellerId",
                table: "ProTenderOpenings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderSellerReqs_ProSeller_SellerId",
                table: "ProTenderSellerReqs");

            migrationBuilder.DropForeignKey(
                name: "FK_StrAdd_ProSeller_SellerId",
                table: "StrAdd");

            migrationBuilder.DropTable(
                name: "ProContractorTypes");

            migrationBuilder.DropTable(
                name: "ProSellerTypes");

            migrationBuilder.DropTable(
                name: "ProContractor");

            migrationBuilder.DropTable(
                name: "ProSeller");

            migrationBuilder.DropTable(
                name: "ProSupplierTypes");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "StrAdd",
                newName: "VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_StrAdd_SellerId",
                table: "StrAdd",
                newName: "IX_StrAdd_VendorId");

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
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CommericalRegister = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                name: "IX_ProVendorTypes_OperationTypeId",
                table: "ProVendorTypes",
                column: "OperationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProVendorTypes_UpdateByID",
                table: "ProVendorTypes",
                column: "UpdateByID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProPurchaseOrders_ProVendors_SellerId",
                table: "ProPurchaseOrders",
                column: "SellerId",
                principalTable: "ProVendors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProQuotations_ProVendors_SellerId",
                table: "ProQuotations",
                column: "SellerId",
                principalTable: "ProVendors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderOpenings_ProVendors_SellerId",
                table: "ProTenderOpenings",
                column: "SellerId",
                principalTable: "ProVendors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderSellerReqs_ProVendors_SellerId",
                table: "ProTenderSellerReqs",
                column: "SellerId",
                principalTable: "ProVendors",
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
                name: "FK_ProPurchaseOrders_ProVendors_SellerId",
                table: "ProPurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProQuotations_ProVendors_SellerId",
                table: "ProQuotations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderOpenings_ProVendors_SellerId",
                table: "ProTenderOpenings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderSellerReqs_ProVendors_SellerId",
                table: "ProTenderSellerReqs");

            migrationBuilder.DropForeignKey(
                name: "FK_StrAdd_ProVendors_VendorId",
                table: "StrAdd");

            migrationBuilder.DropTable(
                name: "ProVendorsTypes");

            migrationBuilder.DropTable(
                name: "ProVendorTypes");

            migrationBuilder.DropTable(
                name: "ProVendors");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                table: "StrAdd",
                newName: "SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_StrAdd_VendorId",
                table: "StrAdd",
                newName: "IX_StrAdd_SellerId");

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
                name: "FK_ProTenderOpenings_ProSeller_SellerId",
                table: "ProTenderOpenings",
                column: "SellerId",
                principalTable: "ProSeller",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderSellerReqs_ProSeller_SellerId",
                table: "ProTenderSellerReqs",
                column: "SellerId",
                principalTable: "ProSeller",
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
