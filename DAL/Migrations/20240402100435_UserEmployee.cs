using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HrEmployee_PrUser_UserId",
                table: "HrEmployee");

            migrationBuilder.DropIndex(
                name: "IX_HrEmployee_UserId",
                table: "HrEmployee");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "PrUser",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrUser_EmployeeId",
                table: "PrUser",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PrUser_HrEmployee_EmployeeId",
                table: "PrUser",
                column: "EmployeeId",
                principalTable: "HrEmployee",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrUser_HrEmployee_EmployeeId",
                table: "PrUser");

            migrationBuilder.DropIndex(
                name: "IX_PrUser_EmployeeId",
                table: "PrUser");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "PrUser");

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
    }
}
