using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProSupplierType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProSellerTypes_ProSellerType_SellerTypeId",
                table: "ProSellerTypes");

            migrationBuilder.DropTable(
                name: "ProSellerType");

            migrationBuilder.AddForeignKey(
                name: "FK_ProSellerTypes_ProContractorType_SellerTypeId",
                table: "ProSellerTypes",
                column: "SellerTypeId",
                principalTable: "ProContractorType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProSellerTypes_ProContractorType_SellerTypeId",
                table: "ProSellerTypes");

            migrationBuilder.CreateTable(
                name: "ProSellerType",
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
                    table.PrimaryKey("PK_ProSellerType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProSellerType_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProSellerType_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProSellerType_CreatedByID",
                table: "ProSellerType",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProSellerType_UpdateByID",
                table: "ProSellerType",
                column: "UpdateByID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProSellerTypes_ProSellerType_SellerTypeId",
                table: "ProSellerTypes",
                column: "SellerTypeId",
                principalTable: "ProSellerType",
                principalColumn: "Id");
        }
    }
}
