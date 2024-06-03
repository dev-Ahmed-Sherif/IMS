using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AdjustProModels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProPurchaseOrderDetails_QuotationDetailsId",
                table: "ProPurchaseOrderDetails");

            migrationBuilder.RenameColumn(
                name: "PurchaseOrderDetailsId",
                table: "ProQuotationDetails",
                newName: "TenderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProQuotationDetails_TenderDetailsId",
                table: "ProQuotationDetails",
                column: "TenderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProPurchaseOrderDetails_QuotationDetailsId",
                table: "ProPurchaseOrderDetails",
                column: "QuotationDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProQuotationDetails_ProTenderDetails_TenderDetailsId",
                table: "ProQuotationDetails",
                column: "TenderDetailsId",
                principalTable: "ProTenderDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProQuotationDetails_ProTenderDetails_TenderDetailsId",
                table: "ProQuotationDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProQuotationDetails_TenderDetailsId",
                table: "ProQuotationDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProPurchaseOrderDetails_QuotationDetailsId",
                table: "ProPurchaseOrderDetails");

            migrationBuilder.RenameColumn(
                name: "TenderDetailsId",
                table: "ProQuotationDetails",
                newName: "PurchaseOrderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProPurchaseOrderDetails_QuotationDetailsId",
                table: "ProPurchaseOrderDetails",
                column: "QuotationDetailsId",
                unique: true);
        }
    }
}
