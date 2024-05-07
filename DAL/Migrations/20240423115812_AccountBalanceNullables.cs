using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AccountBalanceNullables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FiAccountBalances_FiAccount_AccountId",
                table: "FiAccountBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_FiAccountBalances_FiscalYear_FiscalYearId",
                table: "FiAccountBalances");

            migrationBuilder.AlterColumn<int>(
                name: "FiscalYearId",
                table: "FiAccountBalances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "FiAccountBalances",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "FiAccountBalances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FiAccountBalances_FiAccount_AccountId",
                table: "FiAccountBalances",
                column: "AccountId",
                principalTable: "FiAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FiAccountBalances_FiscalYear_FiscalYearId",
                table: "FiAccountBalances",
                column: "FiscalYearId",
                principalTable: "FiscalYear",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FiAccountBalances_FiAccount_AccountId",
                table: "FiAccountBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_FiAccountBalances_FiscalYear_FiscalYearId",
                table: "FiAccountBalances");

            migrationBuilder.AlterColumn<int>(
                name: "FiscalYearId",
                table: "FiAccountBalances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "FiAccountBalances",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "FiAccountBalances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FiAccountBalances_FiAccount_AccountId",
                table: "FiAccountBalances",
                column: "AccountId",
                principalTable: "FiAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FiAccountBalances_FiscalYear_FiscalYearId",
                table: "FiAccountBalances",
                column: "FiscalYearId",
                principalTable: "FiscalYear",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
