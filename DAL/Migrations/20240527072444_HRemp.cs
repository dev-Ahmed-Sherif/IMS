using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class HRemp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeFinancialDegree_HrFinancialDegree_FinancialDegreeId",
                table: "EmployeeFinancialDegree");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeFinancialDegree_PrUser_CreatedByID",
                table: "EmployeeFinancialDegree");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeFinancialDegree_PrUser_UpdateByID",
                table: "EmployeeFinancialDegree");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeFinancialDegree",
                table: "EmployeeFinancialDegree");

            migrationBuilder.RenameTable(
                name: "EmployeeFinancialDegree",
                newName: "HrEmployeeFinancialDegree");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeFinancialDegree_UpdateByID",
                table: "HrEmployeeFinancialDegree",
                newName: "IX_HrEmployeeFinancialDegree_UpdateByID");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeFinancialDegree_FinancialDegreeId",
                table: "HrEmployeeFinancialDegree",
                newName: "IX_HrEmployeeFinancialDegree_FinancialDegreeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeFinancialDegree_CreatedByID",
                table: "HrEmployeeFinancialDegree",
                newName: "IX_HrEmployeeFinancialDegree_CreatedByID");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "HrEmployeeFinancialDegree",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HrEmployeeFinancialDegree",
                table: "HrEmployeeFinancialDegree",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeFinancialDegree_EmployeeId",
                table: "HrEmployeeFinancialDegree",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmployeeFinancialDegree_HrEmployee_EmployeeId",
                table: "HrEmployeeFinancialDegree",
                column: "EmployeeId",
                principalTable: "HrEmployee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmployeeFinancialDegree_HrFinancialDegree_FinancialDegreeId",
                table: "HrEmployeeFinancialDegree",
                column: "FinancialDegreeId",
                principalTable: "HrFinancialDegree",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmployeeFinancialDegree_PrUser_CreatedByID",
                table: "HrEmployeeFinancialDegree",
                column: "CreatedByID",
                principalTable: "PrUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmployeeFinancialDegree_PrUser_UpdateByID",
                table: "HrEmployeeFinancialDegree",
                column: "UpdateByID",
                principalTable: "PrUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HrEmployeeFinancialDegree_HrEmployee_EmployeeId",
                table: "HrEmployeeFinancialDegree");

            migrationBuilder.DropForeignKey(
                name: "FK_HrEmployeeFinancialDegree_HrFinancialDegree_FinancialDegreeId",
                table: "HrEmployeeFinancialDegree");

            migrationBuilder.DropForeignKey(
                name: "FK_HrEmployeeFinancialDegree_PrUser_CreatedByID",
                table: "HrEmployeeFinancialDegree");

            migrationBuilder.DropForeignKey(
                name: "FK_HrEmployeeFinancialDegree_PrUser_UpdateByID",
                table: "HrEmployeeFinancialDegree");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HrEmployeeFinancialDegree",
                table: "HrEmployeeFinancialDegree");

            migrationBuilder.DropIndex(
                name: "IX_HrEmployeeFinancialDegree_EmployeeId",
                table: "HrEmployeeFinancialDegree");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "HrEmployeeFinancialDegree");

            migrationBuilder.RenameTable(
                name: "HrEmployeeFinancialDegree",
                newName: "EmployeeFinancialDegree");

            migrationBuilder.RenameIndex(
                name: "IX_HrEmployeeFinancialDegree_UpdateByID",
                table: "EmployeeFinancialDegree",
                newName: "IX_EmployeeFinancialDegree_UpdateByID");

            migrationBuilder.RenameIndex(
                name: "IX_HrEmployeeFinancialDegree_FinancialDegreeId",
                table: "EmployeeFinancialDegree",
                newName: "IX_EmployeeFinancialDegree_FinancialDegreeId");

            migrationBuilder.RenameIndex(
                name: "IX_HrEmployeeFinancialDegree_CreatedByID",
                table: "EmployeeFinancialDegree",
                newName: "IX_EmployeeFinancialDegree_CreatedByID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeFinancialDegree",
                table: "EmployeeFinancialDegree",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeFinancialDegree_HrFinancialDegree_FinancialDegreeId",
                table: "EmployeeFinancialDegree",
                column: "FinancialDegreeId",
                principalTable: "HrFinancialDegree",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeFinancialDegree_PrUser_CreatedByID",
                table: "EmployeeFinancialDegree",
                column: "CreatedByID",
                principalTable: "PrUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeFinancialDegree_PrUser_UpdateByID",
                table: "EmployeeFinancialDegree",
                column: "UpdateByID",
                principalTable: "PrUser",
                principalColumn: "Id");
        }
    }
}
