using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CommitteeRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "ProTenderCommittees");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "ProTenderCommittees",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProTenderCommitteeRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProTenderCommitteeRoles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderCommittees_RoleId",
                table: "ProTenderCommittees",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderCommittees_ProTenderCommitteeRoles_RoleId",
                table: "ProTenderCommittees",
                column: "RoleId",
                principalTable: "ProTenderCommitteeRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderCommittees_ProTenderCommitteeRoles_RoleId",
                table: "ProTenderCommittees");

            migrationBuilder.DropTable(
                name: "ProTenderCommitteeRoles");

            migrationBuilder.DropIndex(
                name: "IX_ProTenderCommittees_RoleId",
                table: "ProTenderCommittees");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "ProTenderCommittees");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "ProTenderCommittees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
