using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class FiAccountBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FiAccountBalances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiAccountBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiAccountBalances_FiAccount_AccountId",
                        column: x => x.AccountId,
                        principalTable: "FiAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FiAccountBalances_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FiAccountBalances_AccountId",
                table: "FiAccountBalances",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FiAccountBalances_FiscalYearId",
                table: "FiAccountBalances",
                column: "FiscalYearId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FiAccountBalances");
        }
    }
}
