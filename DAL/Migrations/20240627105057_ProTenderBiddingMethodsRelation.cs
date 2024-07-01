using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProTenderBiddingMethodsRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BiddingMethodId",
                table: "ProTender",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProTender_BiddingMethodId",
                table: "ProTender",
                column: "BiddingMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTender_ProTenderBiddingMethods_BiddingMethodId",
                table: "ProTender",
                column: "BiddingMethodId",
                principalTable: "ProTenderBiddingMethods",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProTender_ProTenderBiddingMethods_BiddingMethodId",
                table: "ProTender");

            migrationBuilder.DropIndex(
                name: "IX_ProTender_BiddingMethodId",
                table: "ProTender");

            migrationBuilder.DropColumn(
                name: "BiddingMethodId",
                table: "ProTender");
        }
    }
}
