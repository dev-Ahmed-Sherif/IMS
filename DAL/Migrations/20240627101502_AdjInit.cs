using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AdjInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProVendorAttachment_ProVendors_ProSellerId",
                table: "ProVendorAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_ProVendorsTypes_ProVendors_ProSellerId",
                table: "ProVendorsTypes");

            migrationBuilder.RenameColumn(
                name: "ProSellerId",
                table: "ProVendorsTypes",
                newName: "ProVendorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProVendorsTypes_ProSellerId",
                table: "ProVendorsTypes",
                newName: "IX_ProVendorsTypes_ProVendorId");

            migrationBuilder.RenameColumn(
                name: "ProSellerId",
                table: "ProVendorAttachment",
                newName: "ProVendorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProVendorAttachment_ProSellerId",
                table: "ProVendorAttachment",
                newName: "IX_ProVendorAttachment_ProVendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProVendorAttachment_ProVendors_ProVendorId",
                table: "ProVendorAttachment",
                column: "ProVendorId",
                principalTable: "ProVendors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProVendorsTypes_ProVendors_ProVendorId",
                table: "ProVendorsTypes",
                column: "ProVendorId",
                principalTable: "ProVendors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProVendorAttachment_ProVendors_ProVendorId",
                table: "ProVendorAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_ProVendorsTypes_ProVendors_ProVendorId",
                table: "ProVendorsTypes");

            migrationBuilder.RenameColumn(
                name: "ProVendorId",
                table: "ProVendorsTypes",
                newName: "ProSellerId");

            migrationBuilder.RenameIndex(
                name: "IX_ProVendorsTypes_ProVendorId",
                table: "ProVendorsTypes",
                newName: "IX_ProVendorsTypes_ProSellerId");

            migrationBuilder.RenameColumn(
                name: "ProVendorId",
                table: "ProVendorAttachment",
                newName: "ProSellerId");

            migrationBuilder.RenameIndex(
                name: "IX_ProVendorAttachment_ProVendorId",
                table: "ProVendorAttachment",
                newName: "IX_ProVendorAttachment_ProSellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProVendorAttachment_ProVendors_ProSellerId",
                table: "ProVendorAttachment",
                column: "ProSellerId",
                principalTable: "ProVendors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProVendorsTypes_ProVendors_ProSellerId",
                table: "ProVendorsTypes",
                column: "ProSellerId",
                principalTable: "ProVendors",
                principalColumn: "Id");
        }
    }
}
