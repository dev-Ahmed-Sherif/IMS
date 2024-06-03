using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AdjustProModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderDetails_ProPurchaseOrderDetails_PurchaseOrderDetailsId",
                table: "ProTenderDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProTenderDetails_PurchaseOrderDetailsId",
                table: "ProTenderDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProPurchaseOrderDetails_TenderDetailsId",
                table: "ProPurchaseOrderDetails");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderDetailsId",
                table: "ProTenderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceNumber",
                table: "HrEmployee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ProPurchaseOrderDetails_TenderDetailsId",
                table: "ProPurchaseOrderDetails",
                column: "TenderDetailsId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProPurchaseOrderDetails_TenderDetailsId",
                table: "ProPurchaseOrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseOrderDetailsId",
                table: "ProTenderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceNumber",
                table: "HrEmployee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderDetails_PurchaseOrderDetailsId",
                table: "ProTenderDetails",
                column: "PurchaseOrderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProPurchaseOrderDetails_TenderDetailsId",
                table: "ProPurchaseOrderDetails",
                column: "TenderDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderDetails_ProPurchaseOrderDetails_PurchaseOrderDetailsId",
                table: "ProTenderDetails",
                column: "PurchaseOrderDetailsId",
                principalTable: "ProPurchaseOrderDetails",
                principalColumn: "Id");
        }
    }
}
