using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserEmployeeRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "HrEmployee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_UserId",
                table: "HrEmployee",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmployee_PrUser_UserId",
                table: "HrEmployee",
                column: "UserId",
                principalTable: "PrUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HrEmployee_PrUser_UserId",
                table: "HrEmployee");

            migrationBuilder.DropIndex(
                name: "IX_HrEmployee_UserId",
                table: "HrEmployee");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HrEmployee");
        }
    }
}
