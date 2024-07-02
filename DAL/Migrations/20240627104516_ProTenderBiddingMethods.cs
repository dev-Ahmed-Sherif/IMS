using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProTenderBiddingMethods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProTenderBiddingMethods",
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
                    table.PrimaryKey("PK_ProTenderBiddingMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProTenderBiddingMethods_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProTenderBiddingMethods_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderBiddingMethods_CreatedByID",
                table: "ProTenderBiddingMethods",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderBiddingMethods_UpdateByID",
                table: "ProTenderBiddingMethods",
                column: "UpdateByID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProTenderBiddingMethods");
        }
    }
}
