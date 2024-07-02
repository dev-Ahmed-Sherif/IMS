using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProAndVendorAdjustment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AdditionDate",
                table: "ProPurchaseOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attachment",
                table: "ProPurchaseOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliverDelayInDays",
                table: "ProPurchaseOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Delivered",
                table: "ProPurchaseOrders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "InspectionDate",
                table: "ProPurchaseOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StoreDeliverDate",
                table: "ProPurchaseOrders",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionDate",
                table: "ProPurchaseOrders");

            migrationBuilder.DropColumn(
                name: "Attachment",
                table: "ProPurchaseOrders");

            migrationBuilder.DropColumn(
                name: "DeliverDelayInDays",
                table: "ProPurchaseOrders");

            migrationBuilder.DropColumn(
                name: "Delivered",
                table: "ProPurchaseOrders");

            migrationBuilder.DropColumn(
                name: "InspectionDate",
                table: "ProPurchaseOrders");

            migrationBuilder.DropColumn(
                name: "StoreDeliverDate",
                table: "ProPurchaseOrders");
        }
    }
}
