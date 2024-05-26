using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class HrFinancialDegreeUD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "HrFinancialDegree",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "FiJournal",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FiscalYearId",
                table: "CcEntry",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "JournalId",
                table: "CcEntry",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CcEntry_JournalId",
                table: "CcEntry",
                column: "JournalId");

            migrationBuilder.AddForeignKey(
                name: "FK_CcEntry_FiJournal_JournalId",
                table: "CcEntry",
                column: "JournalId",
                principalTable: "FiJournal",
                principalColumn: "Id");




        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CcEntry_FiJournal_JournalId",
                table: "CcEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_CcEntry_FiscalYear_FiscalYearId",
                table: "CcEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_FiJournal_FiJournalTypes_TypeId",
                table: "FiJournal");

            migrationBuilder.DropIndex(
                name: "IX_CcEntry_JournalId",
                table: "CcEntry");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "HrFinancialDegree");

            migrationBuilder.DropColumn(
                name: "JournalId",
                table: "CcEntry");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "FiJournal",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FiscalYearId",
                table: "CcEntry",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CcEntry_FiscalYear_FiscalYearId",
                table: "CcEntry",
                column: "FiscalYearId",
                principalTable: "FiscalYear",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FiJournal_FiJournalTypes_TypeId",
                table: "FiJournal",
                column: "TypeId",
                principalTable: "FiJournalTypes",
                principalColumn: "Id");
        }
    }
}
