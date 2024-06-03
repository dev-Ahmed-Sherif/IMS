using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProContractorTypes_ProContractorType_ContractorTypeId",
                table: "ProContractorTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProContractorTypes_ProContractor_ContractorId",
                table: "ProContractorTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProSellerTypes_ProSellerType_SellerTypeId",
                table: "ProSellerTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProSellerTypes_ProSeller_SellerId",
                table: "ProSellerTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTender_ProOperationType_OperationTypeId",
                table: "ProTender");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTender_ProPlantType_PlanTypeId",
                table: "ProTender");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTender_ProTenderType_TenderTypeId",
                table: "ProTender");

            migrationBuilder.DropForeignKey(
                name: "FK_StrAddDetailsSerial_StrProductSerial_ProductSerialId",
                table: "StrAddDetailsSerial");

            migrationBuilder.DropForeignKey(
                name: "FK_StrEmployeeExchangeSerial_StrProductSerial_ProductSerialId",
                table: "StrEmployeeExchangeSerial");

            migrationBuilder.DropForeignKey(
                name: "FK_StrEmployeeOpeningCustodySerial_StrProductSerial_ProductSerialId",
                table: "StrEmployeeOpeningCustodySerial");

            migrationBuilder.DropForeignKey(
                name: "FK_StrOpeningStockDetailsSerial_StrProductSerial_ProductSerialId",
                table: "StrOpeningStockDetailsSerial");

            migrationBuilder.DropForeignKey(
                name: "FK_StrProduct_StrItem_ItemId",
                table: "StrProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_StrProduct_StrModel_ModelId",
                table: "StrProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_StrProduct_StrVendor_VendorId",
                table: "StrProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_StrProductSerial_StrProduct_ProductId",
                table: "StrProductSerial");

            migrationBuilder.DropForeignKey(
                name: "FK_StrWithDrawDetailsSerial_StrProductSerial_ProductSerialId",
                table: "StrWithDrawDetailsSerial");

            migrationBuilder.CreateTable(
                name: "ProPurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProPurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProPurchaseOrders_ProSeller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "ProSeller",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProPurchaseOrders_ProTender_TenderId",
                        column: x => x.TenderId,
                        principalTable: "ProTender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProPurchaseOrders_StrStore_StoreId",
                        column: x => x.StoreId,
                        principalTable: "StrStore",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProQuotations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderId = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    ReceiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceiveType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProQuotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProQuotations_ProSeller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "ProSeller",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProQuotations_ProTender_TenderId",
                        column: x => x.TenderId,
                        principalTable: "ProTender",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProTenderCommittees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Close = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TenderId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProTenderCommittees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProTenderCommittees_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProTenderCommittees_ProTender_TenderId",
                        column: x => x.TenderId,
                        principalTable: "ProTender",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProTenderOpeningStatuses",
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
                    table.PrimaryKey("PK_ProTenderOpeningStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProTenderSellerReqs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderId = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SendType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                        name: "FK_ProTenderSellerReqs_ProTender_TenderId",
                        column: x => x.TenderId,
                        principalTable: "ProTender",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProQuotationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuotationId = table.Column<int>(type: "int", nullable: false),
                    PurchaseOrderDetailsId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProQuotationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProQuotationDetails_ProQuotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "ProQuotations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProTenderOpenings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TenderId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProTenderOpenings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProTenderOpenings_ProSeller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "ProSeller",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProTenderOpenings_ProTenderOpeningStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ProTenderOpeningStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProTenderOpenings_ProTender_TenderId",
                        column: x => x.TenderId,
                        principalTable: "ProTender",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProPurchaseOrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: false),
                    TenderDetailsId = table.Column<int>(type: "int", nullable: false),
                    QuotationDetailsId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProPurchaseOrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProPurchaseOrderDetails_ProPurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "ProPurchaseOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProPurchaseOrderDetails_ProQuotationDetails_QuotationDetailsId",
                        column: x => x.QuotationDetailsId,
                        principalTable: "ProQuotationDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProTenderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderId = table.Column<int>(type: "int", nullable: false),
                    PurchaseOrderDetailsId = table.Column<int>(type: "int", nullable: true),
                    Item = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProTenderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProTenderDetails_ProPurchaseOrderDetails_PurchaseOrderDetailsId",
                        column: x => x.PurchaseOrderDetailsId,
                        principalTable: "ProPurchaseOrderDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProTenderDetails_ProTender_TenderId",
                        column: x => x.TenderId,
                        principalTable: "ProTender",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProTenderSelections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderDetailsId = table.Column<int>(type: "int", nullable: false),
                    QuotationDetailsId = table.Column<int>(type: "int", nullable: false),
                    TechnicalPass = table.Column<bool>(type: "bit", nullable: false),
                    TechnicalScore = table.Column<int>(type: "int", nullable: false),
                    FinancialScore = table.Column<int>(type: "int", nullable: false),
                    TotalScore = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProTenderSelections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProTenderSelections_ProQuotationDetails_QuotationDetailsId",
                        column: x => x.QuotationDetailsId,
                        principalTable: "ProQuotationDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProTenderSelections_ProTenderDetails_TenderDetailsId",
                        column: x => x.TenderDetailsId,
                        principalTable: "ProTenderDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProPurchaseOrderDetails_PurchaseOrderId",
                table: "ProPurchaseOrderDetails",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProPurchaseOrderDetails_QuotationDetailsId",
                table: "ProPurchaseOrderDetails",
                column: "QuotationDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProPurchaseOrderDetails_TenderDetailsId",
                table: "ProPurchaseOrderDetails",
                column: "TenderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProPurchaseOrders_SellerId",
                table: "ProPurchaseOrders",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProPurchaseOrders_StoreId",
                table: "ProPurchaseOrders",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProPurchaseOrders_TenderId",
                table: "ProPurchaseOrders",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProQuotationDetails_QuotationId",
                table: "ProQuotationDetails",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProQuotations_SellerId",
                table: "ProQuotations",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProQuotations_TenderId",
                table: "ProQuotations",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderCommittees_EmployeeId",
                table: "ProTenderCommittees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderCommittees_TenderId",
                table: "ProTenderCommittees",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderDetails_PurchaseOrderDetailsId",
                table: "ProTenderDetails",
                column: "PurchaseOrderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderDetails_TenderId",
                table: "ProTenderDetails",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderOpenings_SellerId",
                table: "ProTenderOpenings",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderOpenings_StatusId",
                table: "ProTenderOpenings",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderOpenings_TenderId",
                table: "ProTenderOpenings",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderSelections_QuotationDetailsId",
                table: "ProTenderSelections",
                column: "QuotationDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderSelections_TenderDetailsId",
                table: "ProTenderSelections",
                column: "TenderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderSellerReqs_SellerId",
                table: "ProTenderSellerReqs",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderSellerReqs_TenderId",
                table: "ProTenderSellerReqs",
                column: "TenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProContractorTypes_ProContractorType_ContractorTypeId",
                table: "ProContractorTypes",
                column: "ContractorTypeId",
                principalTable: "ProContractorType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProContractorTypes_ProContractor_ContractorId",
                table: "ProContractorTypes",
                column: "ContractorId",
                principalTable: "ProContractor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProSellerTypes_ProSellerType_SellerTypeId",
                table: "ProSellerTypes",
                column: "SellerTypeId",
                principalTable: "ProSellerType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProSellerTypes_ProSeller_SellerId",
                table: "ProSellerTypes",
                column: "SellerId",
                principalTable: "ProSeller",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTender_ProOperationType_OperationTypeId",
                table: "ProTender",
                column: "OperationTypeId",
                principalTable: "ProOperationType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTender_ProPlantType_PlanTypeId",
                table: "ProTender",
                column: "PlanTypeId",
                principalTable: "ProPlantType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTender_ProTenderType_TenderTypeId",
                table: "ProTender",
                column: "TenderTypeId",
                principalTable: "ProTenderType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StrAddDetailsSerial_StrProductSerial_ProductSerialId",
                table: "StrAddDetailsSerial",
                column: "ProductSerialId",
                principalTable: "StrProductSerial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StrEmployeeExchangeSerial_StrProductSerial_ProductSerialId",
                table: "StrEmployeeExchangeSerial",
                column: "ProductSerialId",
                principalTable: "StrProductSerial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StrEmployeeOpeningCustodySerial_StrProductSerial_ProductSerialId",
                table: "StrEmployeeOpeningCustodySerial",
                column: "ProductSerialId",
                principalTable: "StrProductSerial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StrOpeningStockDetailsSerial_StrProductSerial_ProductSerialId",
                table: "StrOpeningStockDetailsSerial",
                column: "ProductSerialId",
                principalTable: "StrProductSerial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StrProduct_StrItem_ItemId",
                table: "StrProduct",
                column: "ItemId",
                principalTable: "StrItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StrProduct_StrModel_ModelId",
                table: "StrProduct",
                column: "ModelId",
                principalTable: "StrModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StrProduct_StrVendor_VendorId",
                table: "StrProduct",
                column: "VendorId",
                principalTable: "StrVendor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StrProductSerial_StrProduct_ProductId",
                table: "StrProductSerial",
                column: "ProductId",
                principalTable: "StrProduct",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StrWithDrawDetailsSerial_StrProductSerial_ProductSerialId",
                table: "StrWithDrawDetailsSerial",
                column: "ProductSerialId",
                principalTable: "StrProductSerial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProPurchaseOrderDetails_ProTenderDetails_TenderDetailsId",
                table: "ProPurchaseOrderDetails",
                column: "TenderDetailsId",
                principalTable: "ProTenderDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProContractorTypes_ProContractorType_ContractorTypeId",
                table: "ProContractorTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProContractorTypes_ProContractor_ContractorId",
                table: "ProContractorTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProSellerTypes_ProSellerType_SellerTypeId",
                table: "ProSellerTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProSellerTypes_ProSeller_SellerId",
                table: "ProSellerTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTender_ProOperationType_OperationTypeId",
                table: "ProTender");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTender_ProPlantType_PlanTypeId",
                table: "ProTender");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTender_ProTenderType_TenderTypeId",
                table: "ProTender");

            migrationBuilder.DropForeignKey(
                name: "FK_StrAddDetailsSerial_StrProductSerial_ProductSerialId",
                table: "StrAddDetailsSerial");

            migrationBuilder.DropForeignKey(
                name: "FK_StrEmployeeExchangeSerial_StrProductSerial_ProductSerialId",
                table: "StrEmployeeExchangeSerial");

            migrationBuilder.DropForeignKey(
                name: "FK_StrEmployeeOpeningCustodySerial_StrProductSerial_ProductSerialId",
                table: "StrEmployeeOpeningCustodySerial");

            migrationBuilder.DropForeignKey(
                name: "FK_StrOpeningStockDetailsSerial_StrProductSerial_ProductSerialId",
                table: "StrOpeningStockDetailsSerial");

            migrationBuilder.DropForeignKey(
                name: "FK_StrProduct_StrItem_ItemId",
                table: "StrProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_StrProduct_StrModel_ModelId",
                table: "StrProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_StrProduct_StrVendor_VendorId",
                table: "StrProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_StrProductSerial_StrProduct_ProductId",
                table: "StrProductSerial");

            migrationBuilder.DropForeignKey(
                name: "FK_StrWithDrawDetailsSerial_StrProductSerial_ProductSerialId",
                table: "StrWithDrawDetailsSerial");

            migrationBuilder.DropForeignKey(
                name: "FK_ProPurchaseOrderDetails_ProPurchaseOrders_PurchaseOrderId",
                table: "ProPurchaseOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProPurchaseOrderDetails_ProQuotationDetails_QuotationDetailsId",
                table: "ProPurchaseOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProPurchaseOrderDetails_ProTenderDetails_TenderDetailsId",
                table: "ProPurchaseOrderDetails");

            migrationBuilder.DropTable(
                name: "ProTenderCommittees");

            migrationBuilder.DropTable(
                name: "ProTenderOpenings");

            migrationBuilder.DropTable(
                name: "ProTenderSelections");

            migrationBuilder.DropTable(
                name: "ProTenderSellerReqs");

            migrationBuilder.DropTable(
                name: "ProTenderOpeningStatuses");

            migrationBuilder.DropTable(
                name: "ProPurchaseOrders");

            migrationBuilder.DropTable(
                name: "ProQuotationDetails");

            migrationBuilder.DropTable(
                name: "ProQuotations");

            migrationBuilder.DropTable(
                name: "ProTenderDetails");

            migrationBuilder.DropTable(
                name: "ProPurchaseOrderDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_ProContractorTypes_ProContractorType_ContractorTypeId",
                table: "ProContractorTypes",
                column: "ContractorTypeId",
                principalTable: "ProContractorType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProContractorTypes_ProContractor_ContractorId",
                table: "ProContractorTypes",
                column: "ContractorId",
                principalTable: "ProContractor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProSellerTypes_ProSellerType_SellerTypeId",
                table: "ProSellerTypes",
                column: "SellerTypeId",
                principalTable: "ProSellerType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProSellerTypes_ProSeller_SellerId",
                table: "ProSellerTypes",
                column: "SellerId",
                principalTable: "ProSeller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProTender_ProOperationType_OperationTypeId",
                table: "ProTender",
                column: "OperationTypeId",
                principalTable: "ProOperationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProTender_ProPlantType_PlanTypeId",
                table: "ProTender",
                column: "PlanTypeId",
                principalTable: "ProPlantType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProTender_ProTenderType_TenderTypeId",
                table: "ProTender",
                column: "TenderTypeId",
                principalTable: "ProTenderType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StrAddDetailsSerial_StrProductSerial_ProductSerialId",
                table: "StrAddDetailsSerial",
                column: "ProductSerialId",
                principalTable: "StrProductSerial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StrEmployeeExchangeSerial_StrProductSerial_ProductSerialId",
                table: "StrEmployeeExchangeSerial",
                column: "ProductSerialId",
                principalTable: "StrProductSerial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StrEmployeeOpeningCustodySerial_StrProductSerial_ProductSerialId",
                table: "StrEmployeeOpeningCustodySerial",
                column: "ProductSerialId",
                principalTable: "StrProductSerial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StrOpeningStockDetailsSerial_StrProductSerial_ProductSerialId",
                table: "StrOpeningStockDetailsSerial",
                column: "ProductSerialId",
                principalTable: "StrProductSerial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StrProduct_StrItem_ItemId",
                table: "StrProduct",
                column: "ItemId",
                principalTable: "StrItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StrProduct_StrModel_ModelId",
                table: "StrProduct",
                column: "ModelId",
                principalTable: "StrModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StrProduct_StrVendor_VendorId",
                table: "StrProduct",
                column: "VendorId",
                principalTable: "StrVendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StrProductSerial_StrProduct_ProductId",
                table: "StrProductSerial",
                column: "ProductId",
                principalTable: "StrProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StrWithDrawDetailsSerial_StrProductSerial_ProductSerialId",
                table: "StrWithDrawDetailsSerial",
                column: "ProductSerialId",
                principalTable: "StrProductSerial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
