using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DAL.Migrations
{
    public partial class FiCurrency_Report : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "FiJournal",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FiCurrencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiCurrencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FiJournalTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JournalType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiJournalTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FiCurrencyPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiCurrencyPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiCurrencyPrices_FiCurrencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "FiCurrencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FiJournal_TypeId",
                table: "FiJournal",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FiCurrencyPrices_CurrencyId",
                table: "FiCurrencyPrices",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_FiJournal_FiJournalTypes_TypeId",
                table: "FiJournal",
                column: "TypeId",
                principalTable: "FiJournalTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FiJournal_FiJournalTypes_TypeId",
                table: "FiJournal");

            migrationBuilder.DropTable(
                name: "FiCurrencyPrices");

            migrationBuilder.DropTable(
                name: "FiJournalTypes");

            migrationBuilder.DropTable(
                name: "FiCurrencies");

            migrationBuilder.DropIndex(
                name: "IX_FiJournal_TypeId",
                table: "FiJournal");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "FiJournal");
        }
    }
}
