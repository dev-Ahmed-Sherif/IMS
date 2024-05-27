using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CcEntryUD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReligionId",
                table: "HrEmployee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FiscalYearId",
                table: "CcEntry",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_ReligionId",
                table: "HrEmployee",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_CcEntry_FiscalYearId",
                table: "CcEntry",
                column: "FiscalYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_CcEntry_FiscalYear_FiscalYearId",
                table: "CcEntry",
                column: "FiscalYearId",
                principalTable: "FiscalYear",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmployee_HrReligion_ReligionId",
                table: "HrEmployee",
                column: "ReligionId",
                principalTable: "HrReligion",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CcEntry_FiscalYear_FiscalYearId",
                table: "CcEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_HrEmployee_HrReligion_ReligionId",
                table: "HrEmployee");

            migrationBuilder.DropIndex(
                name: "IX_HrEmployee_ReligionId",
                table: "HrEmployee");

            migrationBuilder.DropIndex(
                name: "IX_CcEntry_FiscalYearId",
                table: "CcEntry");

            migrationBuilder.DropColumn(
                name: "ReligionId",
                table: "HrEmployee");

            migrationBuilder.DropColumn(
                name: "FiscalYearId",
                table: "CcEntry");
        }
    }
}
