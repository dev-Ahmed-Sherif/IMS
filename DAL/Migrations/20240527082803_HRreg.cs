using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class HRreg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HrEmployee_HrReligion_ReligionId",
                table: "HrEmployee");

            migrationBuilder.DropIndex(
                name: "IX_HrEmployee_ReligionId",
                table: "HrEmployee");

            migrationBuilder.DropColumn(
                name: "ReligionId",
                table: "HrEmployee");

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "HrEmployee",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Religion",
                table: "HrEmployee");

            migrationBuilder.AddColumn<int>(
                name: "ReligionId",
                table: "HrEmployee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_ReligionId",
                table: "HrEmployee",
                column: "ReligionId");

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmployee_HrReligion_ReligionId",
                table: "HrEmployee",
                column: "ReligionId",
                principalTable: "HrReligion",
                principalColumn: "Id");
        }
    }
}
