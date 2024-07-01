using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "ProVendors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "ProTender",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProVendors_TypeId",
                table: "ProVendors",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTender_TypeId",
                table: "ProTender",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTypes_Name_Code",
                table: "ProTypes",
                columns: new[] { "Name", "Code" },
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTender_ProTypes_TypeId",
                table: "ProTender",
                column: "TypeId",
                principalTable: "ProTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProVendors_ProTypes_TypeId",
                table: "ProVendors",
                column: "TypeId",
                principalTable: "ProTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProTender_ProTypes_TypeId",
                table: "ProTender");

            migrationBuilder.DropForeignKey(
                name: "FK_ProVendors_ProTypes_TypeId",
                table: "ProVendors");

            migrationBuilder.DropTable(
                name: "ProTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProVendors_TypeId",
                table: "ProVendors");

            migrationBuilder.DropIndex(
                name: "IX_ProTender_TypeId",
                table: "ProTender");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "ProVendors");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "ProTender");
        }
    }
}
