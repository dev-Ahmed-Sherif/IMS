using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProPurchaseOrderDetailsQuotationDetailsTenderRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProPurchaseOrderDetails_ProTenderDetails_TenderDetailsId",
                table: "ProPurchaseOrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProPurchaseOrderDetails_TenderDetailsId",
                table: "ProPurchaseOrderDetails");

            migrationBuilder.DropColumn(
                name: "TenderDetailsId",
                table: "ProPurchaseOrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseOrderDetailsId",
                table: "ProTenderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderDetails_PurchaseOrderDetailsId",
                table: "ProTenderDetails",
                column: "PurchaseOrderDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderDetails_ProPurchaseOrderDetails_PurchaseOrderDetailsId",
                table: "ProTenderDetails",
                column: "PurchaseOrderDetailsId",
                principalTable: "ProPurchaseOrderDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderDetails_ProPurchaseOrderDetails_PurchaseOrderDetailsId",
                table: "ProTenderDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProTenderDetails_PurchaseOrderDetailsId",
                table: "ProTenderDetails");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderDetailsId",
                table: "ProTenderDetails");

            migrationBuilder.AddColumn<int>(
                name: "TenderDetailsId",
                table: "ProPurchaseOrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProPurchaseOrderDetails_TenderDetailsId",
                table: "ProPurchaseOrderDetails",
                column: "TenderDetailsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProPurchaseOrderDetails_ProTenderDetails_TenderDetailsId",
                table: "ProPurchaseOrderDetails",
                column: "TenderDetailsId",
                principalTable: "ProTenderDetails",
                principalColumn: "Id");
        }
    }
}
