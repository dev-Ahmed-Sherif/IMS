using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CostCenterCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CostCenterCategoryId",
                table: "FiJournal",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CcCostCenterCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CcCostCenterCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FiJournal_CostCenterCategoryId",
                table: "FiJournal",
                column: "CostCenterCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FiJournal_CcCostCenterCategory_CostCenterCategoryId",
                table: "FiJournal",
                column: "CostCenterCategoryId",
                principalTable: "CcCostCenterCategory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FiJournal_CcCostCenterCategory_CostCenterCategoryId",
                table: "FiJournal");

            migrationBuilder.DropTable(
                name: "CcCostCenterCategory");

            migrationBuilder.DropIndex(
                name: "IX_FiJournal_CostCenterCategoryId",
                table: "FiJournal");

            migrationBuilder.DropColumn(
                name: "CostCenterCategoryId",
                table: "FiJournal");
        }
    }
}
