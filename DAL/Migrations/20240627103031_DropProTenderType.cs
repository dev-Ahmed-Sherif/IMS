using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class DropProTenderType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProTender_ProTenderType_TenderTypeId",
                table: "ProTender");

            migrationBuilder.DropTable(
                name: "ProTenderType");

            migrationBuilder.DropIndex(
                name: "IX_ProTender_TenderTypeId",
                table: "ProTender");

            migrationBuilder.DropColumn(
                name: "TenderTypeId",
                table: "ProTender");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenderTypeId",
                table: "ProTender",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProTenderType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProTenderType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProTenderType_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProTenderType_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProTender_TenderTypeId",
                table: "ProTender",
                column: "TenderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderType_CreatedByID",
                table: "ProTenderType",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderType_UpdateByID",
                table: "ProTenderType",
                column: "UpdateByID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTender_ProTenderType_TenderTypeId",
                table: "ProTender",
                column: "TenderTypeId",
                principalTable: "ProTenderType",
                principalColumn: "Id");
        }
    }
}
