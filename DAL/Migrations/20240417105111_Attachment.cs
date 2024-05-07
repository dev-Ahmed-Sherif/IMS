using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Attachment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Attachment",
                table: "StrStockTaking",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attachment",
                table: "StrOpeningStock",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attachment",
                table: "StrEmployeeOpeningCustody",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attachment",
                table: "StrEmployeeExchange",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attachment",
                table: "StrStockTaking");

            migrationBuilder.DropColumn(
                name: "Attachment",
                table: "StrOpeningStock");

            migrationBuilder.DropColumn(
                name: "Attachment",
                table: "StrEmployeeOpeningCustody");

            migrationBuilder.DropColumn(
                name: "Attachment",
                table: "StrEmployeeExchange");
        }
    }
}
