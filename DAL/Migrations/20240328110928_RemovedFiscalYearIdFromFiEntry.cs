using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemovedFiscalYearIdFromFiEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FiEntry_FiscalYear_FiscalYearId",
                table: "FiEntry");

            migrationBuilder.DropIndex(
                name: "IX_FiEntry_FiscalYearId",
                table: "FiEntry");

            migrationBuilder.DropColumn(
                name: "FiscalYearId",
                table: "FiEntry");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FiscalYearId",
                table: "FiEntry",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FiEntry_FiscalYearId",
                table: "FiEntry",
                column: "FiscalYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_FiEntry_FiscalYear_FiscalYearId",
                table: "FiEntry",
                column: "FiscalYearId",
                principalTable: "FiscalYear",
                principalColumn: "Id");
        }
    }
}
