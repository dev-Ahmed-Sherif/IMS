using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class VLModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VlDrivierLicenseTypes",
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
                    table.PrimaryKey("PK_VlDrivierLicenseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlGarages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlGarages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlItineraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlItineraries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlManufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlStaffPositions",
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
                    table.PrimaryKey("PK_VlStaffPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlStaffStatuses",
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
                    table.PrimaryKey("PK_VlStaffStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlVehicleStatuses",
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
                    table.PrimaryKey("PK_VlVehicleStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlStaff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VlStaff_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VlStaff_VlStaffPositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "VlStaffPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VlStaff_VlStaffStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "VlStaffStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VlVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardNo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ChassisNo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MotorNo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VlVehicles_VlManufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "VlManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VlVehicles_VlModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "VlModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VlVehicles_VlTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "VlTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VlVehicles_VlVehicleStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "VlVehicleStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VlDrivierLicenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlDrivierLicenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VlDrivierLicenses_VlDrivierLicenseTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "VlDrivierLicenseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VlDrivierLicenses_VlStaff_DriverId",
                        column: x => x.DriverId,
                        principalTable: "VlStaff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VlVehicleGarages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    GarageId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlVehicleGarages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VlVehicleGarages_VlGarages_GarageId",
                        column: x => x.GarageId,
                        principalTable: "VlGarages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VlVehicleGarages_VlVehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VlVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VlVehicleItineraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    ItineraryId = table.Column<int>(type: "int", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlVehicleItineraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VlVehicleItineraries_VlItineraries_ItineraryId",
                        column: x => x.ItineraryId,
                        principalTable: "VlItineraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VlVehicleItineraries_VlVehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VlVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VlVehicleJobOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: false),
                    GarageManagerId = table.Column<int>(type: "int", nullable: false),
                    ItineraryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Companion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeterStart = table.Column<int>(type: "int", nullable: false),
                    MeterEnd = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlVehicleJobOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VlVehicleJobOrders_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VlVehicleJobOrders_VlItineraries_ItineraryId",
                        column: x => x.ItineraryId,
                        principalTable: "VlItineraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VlVehicleJobOrders_VlStaff_DriverId",
                        column: x => x.DriverId,
                        principalTable: "VlStaff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VlVehicleJobOrders_VlStaff_GarageManagerId",
                        column: x => x.GarageManagerId,
                        principalTable: "VlStaff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VlVehicleJobOrders_VlStaff_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "VlStaff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VlVehicleJobOrders_VlVehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VlVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VlVehicleLicenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlVehicleLicenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VlVehicleLicenses_VlVehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VlVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VlDrivierLicenses_DriverId",
                table: "VlDrivierLicenses",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_VlDrivierLicenses_TypeId",
                table: "VlDrivierLicenses",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VlDrivierLicenseTypes_Name",
                table: "VlDrivierLicenseTypes",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VlGarages_Name",
                table: "VlGarages",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VlItineraries_Name",
                table: "VlItineraries",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VlManufacturers_Name",
                table: "VlManufacturers",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VlModels_Name",
                table: "VlModels",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VlStaff_EmployeeId",
                table: "VlStaff",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_VlStaff_PositionId",
                table: "VlStaff",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_VlStaff_StatusId",
                table: "VlStaff",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_VlStaffPositions_Name",
                table: "VlStaffPositions",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VlStaffStatuses_Name",
                table: "VlStaffStatuses",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VlTypes_Name",
                table: "VlTypes",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleGarages_GarageId",
                table: "VlVehicleGarages",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleGarages_VehicleId",
                table: "VlVehicleGarages",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleItineraries_ItineraryId",
                table: "VlVehicleItineraries",
                column: "ItineraryId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleItineraries_VehicleId",
                table: "VlVehicleItineraries",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleJobOrders_DriverId",
                table: "VlVehicleJobOrders",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleJobOrders_EmployeeId",
                table: "VlVehicleJobOrders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleJobOrders_GarageManagerId",
                table: "VlVehicleJobOrders",
                column: "GarageManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleJobOrders_ItineraryId",
                table: "VlVehicleJobOrders",
                column: "ItineraryId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleJobOrders_SupervisorId",
                table: "VlVehicleJobOrders",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleJobOrders_VehicleId",
                table: "VlVehicleJobOrders",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleLicenses_VehicleId",
                table: "VlVehicleLicenses",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicles_BoardNo_ChassisNo_MotorNo",
                table: "VlVehicles",
                columns: new[] { "BoardNo", "ChassisNo", "MotorNo" },
                unique: true,
                filter: "[BoardNo] IS NOT NULL AND [ChassisNo] IS NOT NULL AND [MotorNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicles_ManufacturerId",
                table: "VlVehicles",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicles_ModelId",
                table: "VlVehicles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicles_StatusId",
                table: "VlVehicles",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicles_TypeId",
                table: "VlVehicles",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VlVehicleStatuses_Name",
                table: "VlVehicleStatuses",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VlDrivierLicenses");

            migrationBuilder.DropTable(
                name: "VlVehicleGarages");

            migrationBuilder.DropTable(
                name: "VlVehicleItineraries");

            migrationBuilder.DropTable(
                name: "VlVehicleJobOrders");

            migrationBuilder.DropTable(
                name: "VlVehicleLicenses");

            migrationBuilder.DropTable(
                name: "VlDrivierLicenseTypes");

            migrationBuilder.DropTable(
                name: "VlGarages");

            migrationBuilder.DropTable(
                name: "VlItineraries");

            migrationBuilder.DropTable(
                name: "VlStaff");

            migrationBuilder.DropTable(
                name: "VlVehicles");

            migrationBuilder.DropTable(
                name: "VlStaffPositions");

            migrationBuilder.DropTable(
                name: "VlStaffStatuses");

            migrationBuilder.DropTable(
                name: "VlManufacturers");

            migrationBuilder.DropTable(
                name: "VlModels");

            migrationBuilder.DropTable(
                name: "VlTypes");

            migrationBuilder.DropTable(
                name: "VlVehicleStatuses");
        }
    }
}
