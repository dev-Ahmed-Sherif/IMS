using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SectionDuplications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FiEntry_ImsSection_SectionId",
                table: "FiEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_PrGroup_ImsSection_SectionId",
                table: "PrGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_StrOpeningStock_ImsSection_SectionId",
                table: "StrOpeningStock");

            migrationBuilder.DropIndex(
                name: "IX_StrOpeningStock_SectionId",
                table: "StrOpeningStock");

            migrationBuilder.DropIndex(
                name: "IX_PrGroup_SectionId",
                table: "PrGroup");

            migrationBuilder.DropIndex(
                name: "IX_FiEntry_SectionId",
                table: "FiEntry");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "StrOpeningStock");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "PrGroup");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "FiEntry");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "StrOpeningStock",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "PrGroup",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "FiEntry",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StrOpeningStock_SectionId",
                table: "StrOpeningStock",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PrGroup_SectionId",
                table: "PrGroup",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FiEntry_SectionId",
                table: "FiEntry",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_FiEntry_ImsSection_SectionId",
                table: "FiEntry",
                column: "SectionId",
                principalTable: "ImsSection",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrGroup_ImsSection_SectionId",
                table: "PrGroup",
                column: "SectionId",
                principalTable: "ImsSection",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StrOpeningStock_ImsSection_SectionId",
                table: "StrOpeningStock",
                column: "SectionId",
                principalTable: "ImsSection",
                principalColumn: "Id");
        }
    }
}
