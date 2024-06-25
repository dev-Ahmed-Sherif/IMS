using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProSupplierTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProContractorType_PrUser_CreatedByID",
                table: "ProContractorType");

            migrationBuilder.DropForeignKey(
                name: "FK_ProContractorType_PrUser_UpdateByID",
                table: "ProContractorType");

            migrationBuilder.DropForeignKey(
                name: "FK_ProContractorTypes_ProContractorType_ContractorTypeId",
                table: "ProContractorTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProSellerTypes_ProContractorType_SellerTypeId",
                table: "ProSellerTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProContractorType",
                table: "ProContractorType");

            migrationBuilder.RenameTable(
                name: "ProContractorType",
                newName: "ProSupplierTypes");

            migrationBuilder.RenameIndex(
                name: "IX_ProContractorType_UpdateByID",
                table: "ProSupplierTypes",
                newName: "IX_ProSupplierTypes_UpdateByID");

            migrationBuilder.RenameIndex(
                name: "IX_ProContractorType_CreatedByID",
                table: "ProSupplierTypes",
                newName: "IX_ProSupplierTypes_CreatedByID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProSupplierTypes",
                table: "ProSupplierTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProContractorTypes_ProSupplierTypes_ContractorTypeId",
                table: "ProContractorTypes",
                column: "ContractorTypeId",
                principalTable: "ProSupplierTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProSellerTypes_ProSupplierTypes_SellerTypeId",
                table: "ProSellerTypes",
                column: "SellerTypeId",
                principalTable: "ProSupplierTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProSupplierTypes_PrUser_CreatedByID",
                table: "ProSupplierTypes",
                column: "CreatedByID",
                principalTable: "PrUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProSupplierTypes_PrUser_UpdateByID",
                table: "ProSupplierTypes",
                column: "UpdateByID",
                principalTable: "PrUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProContractorTypes_ProSupplierTypes_ContractorTypeId",
                table: "ProContractorTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProSellerTypes_ProSupplierTypes_SellerTypeId",
                table: "ProSellerTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProSupplierTypes_PrUser_CreatedByID",
                table: "ProSupplierTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProSupplierTypes_PrUser_UpdateByID",
                table: "ProSupplierTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProSupplierTypes",
                table: "ProSupplierTypes");

            migrationBuilder.RenameTable(
                name: "ProSupplierTypes",
                newName: "ProContractorType");

            migrationBuilder.RenameIndex(
                name: "IX_ProSupplierTypes_UpdateByID",
                table: "ProContractorType",
                newName: "IX_ProContractorType_UpdateByID");

            migrationBuilder.RenameIndex(
                name: "IX_ProSupplierTypes_CreatedByID",
                table: "ProContractorType",
                newName: "IX_ProContractorType_CreatedByID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProContractorType",
                table: "ProContractorType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProContractorType_PrUser_CreatedByID",
                table: "ProContractorType",
                column: "CreatedByID",
                principalTable: "PrUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProContractorType_PrUser_UpdateByID",
                table: "ProContractorType",
                column: "UpdateByID",
                principalTable: "PrUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProContractorTypes_ProContractorType_ContractorTypeId",
                table: "ProContractorTypes",
                column: "ContractorTypeId",
                principalTable: "ProContractorType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProSellerTypes_ProContractorType_SellerTypeId",
                table: "ProSellerTypes",
                column: "SellerTypeId",
                principalTable: "ProContractorType",
                principalColumn: "Id");
        }
    }
}
