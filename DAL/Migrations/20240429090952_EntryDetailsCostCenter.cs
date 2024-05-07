using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class EntryDetailsCostCenter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FiJournal_CcCostCenterCategory_CostCenterCategoryId",
                table: "FiJournal");

            migrationBuilder.DropIndex(
                name: "IX_FiJournal_CostCenterCategoryId",
                table: "FiJournal");

            migrationBuilder.DropColumn(
                name: "CostCenterCategoryId",
                table: "FiJournal");

            migrationBuilder.AddColumn<int>(
                name: "CostCenterId",
                table: "FiEntryDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CostCenterCategoryId",
                table: "CcCostCenter",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FiEntryDetails_CostCenterId",
                table: "FiEntryDetails",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_CcCostCenter_CostCenterCategoryId",
                table: "CcCostCenter",
                column: "CostCenterCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CcCostCenter_CcCostCenterCategory_CostCenterCategoryId",
                table: "CcCostCenter",
                column: "CostCenterCategoryId",
                principalTable: "CcCostCenterCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FiEntryDetails_CcCostCenter_CostCenterId",
                table: "FiEntryDetails",
                column: "CostCenterId",
                principalTable: "CcCostCenter",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CcCostCenter_CcCostCenterCategory_CostCenterCategoryId",
                table: "CcCostCenter");

            migrationBuilder.DropForeignKey(
                name: "FK_FiEntryDetails_CcCostCenter_CostCenterId",
                table: "FiEntryDetails");

            migrationBuilder.DropIndex(
                name: "IX_FiEntryDetails_CostCenterId",
                table: "FiEntryDetails");

            migrationBuilder.DropIndex(
                name: "IX_CcCostCenter_CostCenterCategoryId",
                table: "CcCostCenter");

            migrationBuilder.DropColumn(
                name: "CostCenterId",
                table: "FiEntryDetails");

            migrationBuilder.DropColumn(
                name: "CostCenterCategoryId",
                table: "CcCostCenter");

            migrationBuilder.AddColumn<int>(
                name: "CostCenterCategoryId",
                table: "FiJournal",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FiJournal_CostCenterCategoryId",
                table: "FiJournal",
                column: "CostCenterCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FiJournal_CcCostCenterCategory_CostCenterCategoryId",
                table: "FiJournal",
                column: "CostCenterCategoryId",
                principalTable: "CcCostCenterCategory",
                principalColumn: "Id");
        }
    }
}
