using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProAdjs3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiveType",
                table: "ProQuotations");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "ProTenderDetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Qty",
                table: "ProTenderDetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ProTenderDetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "ReceiveTypeId",
                table: "ProQuotations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ProQuotationDetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.CreateTable(
                name: "ProQuotationReceiveType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProQuotationReceiveType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProQuotations_ReceiveTypeId",
                table: "ProQuotations",
                column: "ReceiveTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProQuotations_ProQuotationReceiveType_ReceiveTypeId",
                table: "ProQuotations",
                column: "ReceiveTypeId",
                principalTable: "ProQuotationReceiveType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProQuotations_ProQuotationReceiveType_ReceiveTypeId",
                table: "ProQuotations");

            migrationBuilder.DropTable(
                name: "ProQuotationReceiveType");

            migrationBuilder.DropIndex(
                name: "IX_ProQuotations_ReceiveTypeId",
                table: "ProQuotations");

            migrationBuilder.DropColumn(
                name: "ReceiveTypeId",
                table: "ProQuotations");

            migrationBuilder.AlterColumn<double>(
                name: "Total",
                table: "ProTenderDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Qty",
                table: "ProTenderDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "ProTenderDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "ReceiveType",
                table: "ProQuotations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "ProQuotationDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
