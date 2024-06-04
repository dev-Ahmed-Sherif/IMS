using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProtenderSellerAndDetailsAdjustance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendType",
                table: "ProTenderSellerReqs");

            migrationBuilder.RenameColumn(
                name: "Item",
                table: "ProTenderDetails",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "SendTypeId",
                table: "ProTenderSellerReqs",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "QualificationDate",
                table: "HrEmployee",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceNumber",
                table: "HrEmployee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProTenderSellerReqSendType",
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
                    table.PrimaryKey("PK_ProTenderSellerReqSendType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderSellerReqs_SendTypeId",
                table: "ProTenderSellerReqs",
                column: "SendTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProTenderSellerReqs_ProTenderSellerReqSendType_SendTypeId",
                table: "ProTenderSellerReqs",
                column: "SendTypeId",
                principalTable: "ProTenderSellerReqSendType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProTenderSellerReqs_ProTenderSellerReqSendType_SendTypeId",
                table: "ProTenderSellerReqs");

            migrationBuilder.DropTable(
                name: "ProTenderSellerReqSendType");

            migrationBuilder.DropIndex(
                name: "IX_ProTenderSellerReqs_SendTypeId",
                table: "ProTenderSellerReqs");

            migrationBuilder.DropColumn(
                name: "SendTypeId",
                table: "ProTenderSellerReqs");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProTenderDetails",
                newName: "Item");

            migrationBuilder.AddColumn<string>(
                name: "SendType",
                table: "ProTenderSellerReqs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "QualificationDate",
                table: "HrEmployee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceNumber",
                table: "HrEmployee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
