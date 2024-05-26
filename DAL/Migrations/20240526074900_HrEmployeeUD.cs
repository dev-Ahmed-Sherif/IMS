using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class HrEmployeeUD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "HrEmployee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PayMethodId",
                table: "HrEmployee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalaryStatusId",
                table: "HrEmployee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "HrBank",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Department",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_BankId",
                table: "HrEmployee",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_PayMethodId",
                table: "HrEmployee",
                column: "PayMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_SalaryStatusId",
                table: "HrEmployee",
                column: "SalaryStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmployee_HrBank_BankId",
                table: "HrEmployee",
                column: "BankId",
                principalTable: "HrBank",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmployee_HrPayMethod_PayMethodId",
                table: "HrEmployee",
                column: "PayMethodId",
                principalTable: "HrPayMethod",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmployee_HrSalaryStatus_SalaryStatusId",
                table: "HrEmployee",
                column: "SalaryStatusId",
                principalTable: "HrSalaryStatus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HrEmployee_HrBank_BankId",
                table: "HrEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_HrEmployee_HrPayMethod_PayMethodId",
                table: "HrEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_HrEmployee_HrSalaryStatus_SalaryStatusId",
                table: "HrEmployee");

            migrationBuilder.DropIndex(
                name: "IX_HrEmployee_BankId",
                table: "HrEmployee");

            migrationBuilder.DropIndex(
                name: "IX_HrEmployee_PayMethodId",
                table: "HrEmployee");

            migrationBuilder.DropIndex(
                name: "IX_HrEmployee_SalaryStatusId",
                table: "HrEmployee");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "HrEmployee");

            migrationBuilder.DropColumn(
                name: "PayMethodId",
                table: "HrEmployee");

            migrationBuilder.DropColumn(
                name: "SalaryStatusId",
                table: "HrEmployee");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "HrBank");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Department");
        }
    }
}
