using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProVendors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProPurchaseOrders_ProSeller_VendorId",
                table: "ProPurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProQuotations_ProSeller_VendorId",
                table: "ProQuotations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProSeller_HrCityState_CityStateId",
                table: "ProSeller");

            migrationBuilder.DropForeignKey(
                name: "FK_ProSeller_HrCity_CityId",
                table: "ProSeller");

            migrationBuilder.DropForeignKey(
                name: "FK_ProSeller_PrUser_CreatedByID",
                table: "ProSeller");

            migrationBuilder.DropForeignKey(
                name: "FK_ProSeller_PrUser_UpdateByID",
                table: "ProSeller");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderVendorReqs_ProSeller_VendorId",
                table: "ProTenderVendorReqs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProVendorsTypes_ProSeller_VendorId",
                table: "ProVendorsTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_StrAdd_ProSeller_VendorId",
                table: "StrAdd");

            migrationBuilder.DropIndex(
                name: "IX_ProVendorsTypes_VendorId",
                table: "ProVendorsTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProPurchaseOrders_VendorId",
                table: "ProPurchaseOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProSeller",
                table: "ProSeller");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "ProVendorsTypes");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "ProPurchaseOrders");

            migrationBuilder.RenameTable(
                name: "ProSeller",
                newName: "ProVendors");

            migrationBuilder.RenameIndex(
                name: "IX_ProSeller_UpdateByID",
                table: "ProVendors",
                newName: "IX_ProVendors_UpdateByID");

            migrationBuilder.RenameIndex(
                name: "IX_ProSeller_CreatedByID",
                table: "ProVendors",
                newName: "IX_ProVendors_CreatedByID");

            migrationBuilder.RenameIndex(
                name: "IX_ProSeller_CityStateId",
                table: "ProVendors",
                newName: "IX_ProVendors_CityStateId");

            migrationBuilder.RenameIndex(
                name: "IX_ProSeller_CityId",
                table: "ProVendors",
                newName: "IX_ProVendors_CityId");

            migrationBuilder.AddColumn<int>(
                name: "ProSellerId",
                table: "ProVendorsTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProVendors",
                table: "ProVendors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProVendorsTypes_ProSellerId",
                table: "ProVendorsTypes",
                column: "ProSellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProQuotations_ProVendors_VendorId",
                table: "ProQuotations",
                column: "VendorId",
                principalTable: "ProVendors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderVendorReqs_ProVendors_VendorId",
                table: "ProTenderVendorReqs",
                column: "VendorId",
                principalTable: "ProVendors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProVendors_HrCityState_CityStateId",
                table: "ProVendors",
                column: "CityStateId",
                principalTable: "HrCityState",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProVendors_HrCity_CityId",
                table: "ProVendors",
                column: "CityId",
                principalTable: "HrCity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProVendors_PrUser_CreatedByID",
                table: "ProVendors",
                column: "CreatedByID",
                principalTable: "PrUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProVendors_PrUser_UpdateByID",
                table: "ProVendors",
                column: "UpdateByID",
                principalTable: "PrUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProVendorsTypes_ProVendors_ProSellerId",
                table: "ProVendorsTypes",
                column: "ProSellerId",
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
                name: "FK_ProQuotations_ProVendors_VendorId",
                table: "ProQuotations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderVendorReqs_ProVendors_VendorId",
                table: "ProTenderVendorReqs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProVendors_HrCityState_CityStateId",
                table: "ProVendors");

            migrationBuilder.DropForeignKey(
                name: "FK_ProVendors_HrCity_CityId",
                table: "ProVendors");

            migrationBuilder.DropForeignKey(
                name: "FK_ProVendors_PrUser_CreatedByID",
                table: "ProVendors");

            migrationBuilder.DropForeignKey(
                name: "FK_ProVendors_PrUser_UpdateByID",
                table: "ProVendors");

            migrationBuilder.DropForeignKey(
                name: "FK_ProVendorsTypes_ProVendors_ProSellerId",
                table: "ProVendorsTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_StrAdd_ProVendors_VendorId",
                table: "StrAdd");

            migrationBuilder.DropIndex(
                name: "IX_ProVendorsTypes_ProSellerId",
                table: "ProVendorsTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProVendors",
                table: "ProVendors");

            migrationBuilder.DropColumn(
                name: "ProSellerId",
                table: "ProVendorsTypes");

            migrationBuilder.RenameTable(
                name: "ProVendors",
                newName: "ProSeller");

            migrationBuilder.RenameIndex(
                name: "IX_ProVendors_UpdateByID",
                table: "ProSeller",
                newName: "IX_ProSeller_UpdateByID");

            migrationBuilder.RenameIndex(
                name: "IX_ProVendors_CreatedByID",
                table: "ProSeller",
                newName: "IX_ProSeller_CreatedByID");

            migrationBuilder.RenameIndex(
                name: "IX_ProVendors_CityStateId",
                table: "ProSeller",
                newName: "IX_ProSeller_CityStateId");

            migrationBuilder.RenameIndex(
                name: "IX_ProVendors_CityId",
                table: "ProSeller",
                newName: "IX_ProSeller_CityId");

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "ProVendorsTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "ProPurchaseOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProSeller",
                table: "ProSeller",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProVendorsTypes_VendorId",
                table: "ProVendorsTypes",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProPurchaseOrders_VendorId",
                table: "ProPurchaseOrders",
                column: "VendorId");

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
                name: "FK_ProSeller_HrCityState_CityStateId",
                table: "ProSeller",
                column: "CityStateId",
                principalTable: "HrCityState",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProSeller_HrCity_CityId",
                table: "ProSeller",
                column: "CityId",
                principalTable: "HrCity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProSeller_PrUser_CreatedByID",
                table: "ProSeller",
                column: "CreatedByID",
                principalTable: "PrUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProSeller_PrUser_UpdateByID",
                table: "ProSeller",
                column: "UpdateByID",
                principalTable: "PrUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderVendorReqs_ProSeller_VendorId",
                table: "ProTenderVendorReqs",
                column: "VendorId",
                principalTable: "ProSeller",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProVendorsTypes_ProSeller_VendorId",
                table: "ProVendorsTypes",
                column: "VendorId",
                principalTable: "ProSeller",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StrAdd_ProSeller_VendorId",
                table: "StrAdd",
                column: "VendorId",
                principalTable: "ProSeller",
                principalColumn: "Id");
        }
    }
}
