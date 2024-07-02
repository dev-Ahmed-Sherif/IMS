using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProRelationsAdjustance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderDetails_ProPurchaseOrderDetails_PurchaseOrderDetailsId",
                table: "ProTenderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderDetails_ProTenderOpenings_TenderOpeningId",
                table: "ProTenderDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProTenderDetails_PurchaseOrderDetailsId",
                table: "ProTenderDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProTenderDetails_TenderOpeningId",
                table: "ProTenderDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProPurchaseOrderDetails_QuotationDetailsId",
                table: "ProPurchaseOrderDetails");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderDetailsId",
                table: "ProTenderDetails");

            migrationBuilder.DropColumn(
                name: "TenderOpeningId",
                table: "ProTenderDetails");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseOrderDetailsId",
                table: "ProQuotationDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProPurchaseOrderDetails_QuotationDetailsId",
                table: "ProPurchaseOrderDetails",
                column: "QuotationDetailsId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProPurchaseOrderDetails_QuotationDetailsId",
                table: "ProPurchaseOrderDetails");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderDetailsId",
                table: "ProQuotationDetails");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseOrderDetailsId",
                table: "ProTenderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenderOpeningId",
                table: "ProTenderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderDetails_PurchaseOrderDetailsId",
                table: "ProTenderDetails",
                column: "PurchaseOrderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderDetails_TenderOpeningId",
                table: "ProTenderDetails",
                column: "TenderOpeningId");

            migrationBuilder.CreateIndex(
                name: "IX_ProPurchaseOrderDetails_QuotationDetailsId",
                table: "ProPurchaseOrderDetails",
                column: "QuotationDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderDetails_ProPurchaseOrderDetails_PurchaseOrderDetailsId",
                table: "ProTenderDetails",
                column: "PurchaseOrderDetailsId",
                principalTable: "ProPurchaseOrderDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderDetails_ProTenderOpenings_TenderOpeningId",
                table: "ProTenderDetails",
                column: "TenderOpeningId",
                principalTable: "ProTenderOpenings",
                principalColumn: "Id");
        }
    }
}
