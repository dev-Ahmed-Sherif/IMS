using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AttachmentUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Attachment",
                table: "ProQuotations",
                newName: "AttachmentUrl");

            migrationBuilder.RenameColumn(
                name: "Attachment",
                table: "ProQuotationDetails",
                newName: "AttachmentUrl");

            migrationBuilder.RenameColumn(
                name: "Attachment",
                table: "ProPurchaseOrders",
                newName: "AttachmentUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AttachmentUrl",
                table: "ProQuotations",
                newName: "Attachment");

            migrationBuilder.RenameColumn(
                name: "AttachmentUrl",
                table: "ProQuotationDetails",
                newName: "Attachment");

            migrationBuilder.RenameColumn(
                name: "AttachmentUrl",
                table: "ProPurchaseOrders",
                newName: "Attachment");
        }
    }
}
