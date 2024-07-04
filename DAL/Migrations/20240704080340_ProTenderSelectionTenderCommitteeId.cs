using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProTenderSelectionTenderCommitteeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderSelections_ProTenderCommittees_CommitteeId",
                table: "ProTenderSelections");

            migrationBuilder.RenameColumn(
                name: "CommitteeId",
                table: "ProTenderSelections",
                newName: "TenderCommitteeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProTenderSelections_CommitteeId",
                table: "ProTenderSelections",
                newName: "IX_ProTenderSelections_TenderCommitteeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderSelections_ProTenderCommittees_TenderCommitteeId",
                table: "ProTenderSelections",
                column: "TenderCommitteeId",
                principalTable: "ProTenderCommittees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderSelections_ProTenderCommittees_TenderCommitteeId",
                table: "ProTenderSelections");

            migrationBuilder.RenameColumn(
                name: "TenderCommitteeId",
                table: "ProTenderSelections",
                newName: "CommitteeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProTenderSelections_TenderCommitteeId",
                table: "ProTenderSelections",
                newName: "IX_ProTenderSelections_CommitteeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderSelections_ProTenderCommittees_CommitteeId",
                table: "ProTenderSelections",
                column: "CommitteeId",
                principalTable: "ProTenderCommittees",
                principalColumn: "Id");
        }
    }
}
