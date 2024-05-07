using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CcActivity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CcActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CcActivity_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcActivity_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CcEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreditTotal = table.Column<float>(type: "real", nullable: true),
                    DebitTotal = table.Column<float>(type: "real", nullable: true),
                    Balance = table.Column<float>(type: "real", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CcEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CcEntry_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcEntry_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CcFunction",
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
                    table.PrimaryKey("PK_CcFunction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CcFunction_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcFunction_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CcPlantComponent",
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
                    table.PrimaryKey("PK_CcPlantComponent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CcPlantComponent_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcPlantComponent_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CcRegion",
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
                    table.PrimaryKey("PK_CcRegion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CcRegion_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcRegion_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FaCategoryFirst",
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
                    table.PrimaryKey("PK_FaCategoryFirst", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaCategoryFirst_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FaCategoryFirst_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FaCategorySecond",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaCategorySecond", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaCategorySecond_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FaCategorySecond_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FaCategoryThird",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaCategoryThird", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaCategoryThird_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FaCategoryThird_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FiAccountHierarchy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiAccountHierarchy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiAccountHierarchy_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiAccountHierarchy_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FiAccountItemCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiAccountItemCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiAccountItemCategory_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiAccountItemCategory_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FiEntrySource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiEntrySource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiEntrySource_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiEntrySource_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FiscalYear",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fiscalyear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalYear", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiscalYear_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiscalYear_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GeneralDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralDepartment_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GeneralDepartment_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrAttendanceMachine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrAttendanceMachine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrAttendanceMachine_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrAttendanceMachine_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrAttendancePermission",
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
                    table.PrimaryKey("PK_HrAttendancePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrAttendancePermission_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrAttendancePermission_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrAttendanceSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WrkHours = table.Column<int>(type: "int", nullable: false),
                    AttendanceTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AttendanceAllowance = table.Column<int>(type: "int", nullable: false),
                    DepartureAllowance = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrAttendanceSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrAttendanceSchedule_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrAttendanceSchedule_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrCity",
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
                    table.PrimaryKey("PK_HrCity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrCity_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrCity_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrDisciplinary",
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
                    table.PrimaryKey("PK_HrDisciplinary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrDisciplinary_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrDisciplinary_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrFinancialDegree",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NoYear = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrFinancialDegree", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrFinancialDegree_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrFinancialDegree_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrHiringType",
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
                    table.PrimaryKey("PK_HrHiringType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrHiringType_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrHiringType_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrHoliday",
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
                    table.PrimaryKey("PK_HrHoliday", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrHoliday_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrHoliday_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrJobTitle",
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
                    table.PrimaryKey("PK_HrJobTitle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrJobTitle_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrJobTitle_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrMillitryState",
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
                    table.PrimaryKey("PK_HrMillitryState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrMillitryState_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrMillitryState_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrPosition",
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
                    table.PrimaryKey("PK_HrPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrPosition_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrPosition_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrQualificationLevel",
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
                    table.PrimaryKey("PK_HrQualificationLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrQualificationLevel_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrQualificationLevel_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrQualitativeGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrQualitativeGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrQualitativeGroup_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrQualitativeGroup_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrSeveranceReason",
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
                    table.PrimaryKey("PK_HrSeveranceReason", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrSeveranceReason_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrSeveranceReason_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrVacation",
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
                    table.PrimaryKey("PK_HrVacation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrVacation_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrVacation_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ImsSection",
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
                    table.PrimaryKey("PK_ImsSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImsSection_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ImsSection_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PrModule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrModule_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrModule_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProContractorType",
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
                    table.PrimaryKey("PK_ProContractorType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProContractorType_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProContractorType_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProOperationType",
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
                    table.PrimaryKey("PK_ProOperationType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProOperationType_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProOperationType_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProPlantType",
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
                    table.PrimaryKey("PK_ProPlantType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProPlantType_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProPlantType_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProSellerType",
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
                    table.PrimaryKey("PK_ProSellerType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProSellerType_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProSellerType_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProTenderType",
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
                    table.PrimaryKey("PK_ProTenderType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProTenderType_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProTenderType_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PrPrivileges",
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
                    table.PrimaryKey("PK_PrPrivileges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrPrivileges_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrPrivileges_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PyItemCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PyItemCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PyItemCategory_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PyItemCategory_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PyItemGroup",
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
                    table.PrimaryKey("PK_PyItemGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PyItemGroup_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PyItemGroup_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PyTaxBracket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<float>(type: "real", nullable: false),
                    Ratio = table.Column<float>(type: "real", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PyTaxBracket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PyTaxBracket_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PyTaxBracket_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrApprovalStatus",
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
                    table.PrimaryKey("PK_StrApprovalStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrApprovalStatus_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrApprovalStatus_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrUnit",
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
                    table.PrimaryKey("PK_StrUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrUnit_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrUnit_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrVendor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrVendor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrVendor_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrVendor_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrCourseCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrCourseCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrCourseCategory_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrCourseCategory_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrCourseType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrCourseType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrCourseType_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrCourseType_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrFinancier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrFinancier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrFinancier_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrFinancier_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrPurpose",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPurpose", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrPurpose_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrPurpose_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrTrack",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrTrack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrTrack_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrTrack_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CcSource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FunctionId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CcSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CcSource_CcFunction_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "CcFunction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcSource_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcSource_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CcSubRegion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CcSubRegion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CcSubRegion_CcRegion_RegionId",
                        column: x => x.RegionId,
                        principalTable: "CcRegion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcSubRegion_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcSubRegion_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FiAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiAccountHierarchyId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiAccount_FiAccountHierarchy_FiAccountHierarchyId",
                        column: x => x.FiAccountHierarchyId,
                        principalTable: "FiAccountHierarchy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiAccount_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiAccount_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FiEntrySourceType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntrySourceId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiEntrySourceType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiEntrySourceType_FiEntrySource_EntrySourceId",
                        column: x => x.EntrySourceId,
                        principalTable: "FiEntrySource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiEntrySourceType_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiEntrySourceType_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PyExchange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PyExchange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PyExchange_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PyExchange_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PyExchange_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GeneralDepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_GeneralDepartment_GeneralDepartmentId",
                        column: x => x.GeneralDepartmentId,
                        principalTable: "GeneralDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Department_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Department_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrCityState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrCityState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrCityState_HrCity_CityId",
                        column: x => x.CityId,
                        principalTable: "HrCity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrCityState_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrCityState_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrCorporateCLient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrCorporateCLient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrCorporateCLient_HrCity_CityId",
                        column: x => x.CityId,
                        principalTable: "HrCity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrCorporateCLient_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrCorporateCLient_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrInstructorData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrInstructorData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrInstructorData_HrCity_CityId",
                        column: x => x.CityId,
                        principalTable: "HrCity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrInstructorData_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrInstructorData_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrTrainingCenter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrTrainingCenter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrTrainingCenter_HrCity_CityId",
                        column: x => x.CityId,
                        principalTable: "HrCity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrTrainingCenter_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrTrainingCenter_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeFinancialDegree",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinancialDegreeId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    FinancialDegreeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeFinancialDegree", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeFinancialDegree_HrFinancialDegree_FinancialDegreeId",
                        column: x => x.FinancialDegreeId,
                        principalTable: "HrFinancialDegree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeFinancialDegree_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeFinancialDegree_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrFinancialDegreeSalary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FinancialDegreeId = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrFinancialDegreeSalary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrFinancialDegreeSalary_HrFinancialDegree_FinancialDegreeId",
                        column: x => x.FinancialDegreeId,
                        principalTable: "HrFinancialDegree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrFinancialDegreeSalary_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrFinancialDegreeSalary_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrHolidaySchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    HolidayId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrHolidaySchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrHolidaySchedule_HrHoliday_HolidayId",
                        column: x => x.HolidayId,
                        principalTable: "HrHoliday",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrHolidaySchedule_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrHolidaySchedule_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrQualification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QualitativeGroupId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrQualification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrQualification_HrQualitativeGroup_QualitativeGroupId",
                        column: x => x.QualitativeGroupId,
                        principalTable: "HrQualitativeGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrQualification_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrQualification_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FiJournal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FiscalYearId = table.Column<int>(type: "int", nullable: true),
                    SectionId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiJournal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiJournal_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiJournal_ImsSection_SectionId",
                        column: x => x.SectionId,
                        principalTable: "ImsSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiJournal_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiJournal_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PrGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SectionId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrGroup_ImsSection_SectionId",
                        column: x => x.SectionId,
                        principalTable: "ImsSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrGroup_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrGroup_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PrRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrRole_PrModule_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "PrModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrRole_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrRole_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PrUserModule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrUserModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrUserModule_PrModule_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "PrModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrUserModule_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrUserModule_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrUserModule_PrUser_UserId",
                        column: x => x.UserId,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PyItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Manner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalcType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Party = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Equation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Round = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    MinValue = table.Column<float>(type: "real", nullable: false),
                    MaxValue = table.Column<float>(type: "real", nullable: false),
                    ResetValue = table.Column<float>(type: "real", nullable: false),
                    Visibility = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PyItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PyItem_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PyItem_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PyItem_PyItemCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "PyItemCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrModel_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrModel_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrModel_StrVendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "StrVendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrCourse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CourseTypeId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrCourse_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrCourse_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrCourse_TrCourseCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TrCourseCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrCourse_TrCourseType_CourseTypeId",
                        column: x => x.CourseTypeId,
                        principalTable: "TrCourseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CcPlant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    SubRegionId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CcPlant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CcPlant_CcSubRegion_SubRegionId",
                        column: x => x.SubRegionId,
                        principalTable: "CcSubRegion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcPlant_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcPlant_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FiAccountItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AccountItemCategoryId = table.Column<int>(type: "int", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiAccountItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiAccountItem_FiAccount_AccountId",
                        column: x => x.AccountId,
                        principalTable: "FiAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiAccountItem_FiAccountItemCategory_AccountItemCategoryId",
                        column: x => x.AccountItemCategoryId,
                        principalTable: "FiAccountItemCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiAccountItem_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiAccountItem_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FiAccountParent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiAccountParent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiAccountParent_FiAccount_AccountId",
                        column: x => x.AccountId,
                        principalTable: "FiAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FiAccountParent_FiAccount_ParentId",
                        column: x => x.ParentId,
                        principalTable: "FiAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FiAccountParent_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiAccountParent_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrAddType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrAddType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrAddType_FiAccount_AccountId",
                        column: x => x.AccountId,
                        principalTable: "FiAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrAddType_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrAddType_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrCommodity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrCommodity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrCommodity_FiAccount_AccountId",
                        column: x => x.AccountId,
                        principalTable: "FiAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrCommodity_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrCommodity_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrWithDrawType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrWithDrawType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrWithDrawType_FiAccount_AccountId",
                        column: x => x.AccountId,
                        principalTable: "FiAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrWithDrawType_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrWithDrawType_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrWorkPlace",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CityStateId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrWorkPlace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrWorkPlace_HrCityState_CityStateId",
                        column: x => x.CityStateId,
                        principalTable: "HrCityState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrWorkPlace_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrWorkPlace_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProContractor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    TheLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxCard = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CityStateId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IndusterialRegister = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProContractor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProContractor_HrCity_CityId",
                        column: x => x.CityId,
                        principalTable: "HrCity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProContractor_HrCityState_CityStateId",
                        column: x => x.CityStateId,
                        principalTable: "HrCityState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProContractor_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProContractor_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProSeller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CityStateId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CommericalRegister = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxCard = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProSeller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProSeller_HrCity_CityId",
                        column: x => x.CityId,
                        principalTable: "HrCity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProSeller_HrCityState_CityStateId",
                        column: x => x.CityStateId,
                        principalTable: "HrCityState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProSeller_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProSeller_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProTender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityStateId = table.Column<int>(type: "int", nullable: true),
                    OperationTypeId = table.Column<int>(type: "int", nullable: false),
                    TenderTypeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    PlanTypeId = table.Column<int>(type: "int", nullable: false),
                    Period = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TORValue = table.Column<float>(type: "real", nullable: true),
                    TenderBondValue = table.Column<float>(type: "real", nullable: true),
                    TechnicalOpeningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TechnicalSelectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinancialOpeningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinancialSelectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstimatingValue = table.Column<float>(type: "real", nullable: true),
                    AwardValue = table.Column<float>(type: "real", nullable: true),
                    AwardLetterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkOrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProTender", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProTender_HrCityState_CityStateId",
                        column: x => x.CityStateId,
                        principalTable: "HrCityState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProTender_ProOperationType_OperationTypeId",
                        column: x => x.OperationTypeId,
                        principalTable: "ProOperationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProTender_ProPlantType_PlanTypeId",
                        column: x => x.PlanTypeId,
                        principalTable: "ProPlantType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProTender_ProTenderType_TenderTypeId",
                        column: x => x.TenderTypeId,
                        principalTable: "ProTenderType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProTender_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProTender_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrTrainee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CityStateId = table.Column<int>(type: "int", nullable: true),
                    CorporationCLientId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrTrainee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrTrainee_HrCity_CityId",
                        column: x => x.CityId,
                        principalTable: "HrCity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrTrainee_HrCityState_CityStateId",
                        column: x => x.CityStateId,
                        principalTable: "HrCityState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrTrainee_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrTrainee_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrTrainee_TrCorporateCLient_CorporationCLientId",
                        column: x => x.CorporationCLientId,
                        principalTable: "TrCorporateCLient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrClassRoom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainingCenterId = table.Column<int>(type: "int", nullable: false),
                    CityStateId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrClassRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrClassRoom_HrCityState_CityStateId",
                        column: x => x.CityStateId,
                        principalTable: "HrCityState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrClassRoom_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrClassRoom_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrClassRoom_TrTrainingCenter_TrainingCenterId",
                        column: x => x.TrainingCenterId,
                        principalTable: "TrTrainingCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrSpecialization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QualificationId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrSpecialization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrSpecialization_HrQualification_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "HrQualification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrSpecialization_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrSpecialization_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FiEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JournalId = table.Column<int>(type: "int", nullable: false),
                    FiEntrySourceTypeId = table.Column<int>(type: "int", nullable: true),
                    No = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreditTotal = table.Column<float>(type: "real", nullable: false),
                    DebitTotal = table.Column<float>(type: "real", nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FiscalYearId = table.Column<int>(type: "int", nullable: true),
                    SectionId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiEntry_FiEntrySourceType_FiEntrySourceTypeId",
                        column: x => x.FiEntrySourceTypeId,
                        principalTable: "FiEntrySourceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiEntry_FiJournal_JournalId",
                        column: x => x.JournalId,
                        principalTable: "FiJournal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiEntry_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiEntry_ImsSection_SectionId",
                        column: x => x.SectionId,
                        principalTable: "ImsSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiEntry_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiEntry_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PrGroupPrivileges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    PrivilegesId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrGroupPrivileges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrGroupPrivileges_PrGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "PrGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrGroupPrivileges_PrPrivileges_PrivilegesId",
                        column: x => x.PrivilegesId,
                        principalTable: "PrPrivileges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrGroupPrivileges_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrGroupPrivileges_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PrUserGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrUserGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrUserGroup_PrGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "PrGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrUserGroup_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrUserGroup_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrUserGroup_PrUser_UserId",
                        column: x => x.UserId,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PrGroupRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CanView = table.Column<bool>(type: "bit", nullable: false),
                    CanEdit = table.Column<bool>(type: "bit", nullable: false),
                    CanDelete = table.Column<bool>(type: "bit", nullable: false),
                    CanInsert = table.Column<bool>(type: "bit", nullable: false),
                    CanPrint = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrGroupRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrGroupRole_PrGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "PrGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrGroupRole_PrRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "PrRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrGroupRole_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrGroupRole_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PyItemGroupDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PyItemId = table.Column<int>(type: "int", nullable: false),
                    ItemGroupId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PyItemGroupDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PyItemGroupDetails_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PyItemGroupDetails_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PyItemGroupDetails_PyItem_PyItemId",
                        column: x => x.PyItemId,
                        principalTable: "PyItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PyItemGroupDetails_PyItemGroup_ItemGroupId",
                        column: x => x.ItemGroupId,
                        principalTable: "PyItemGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrBudget",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoTrainee = table.Column<int>(type: "int", nullable: true),
                    NoHour = table.Column<int>(type: "int", nullable: true),
                    InstructorHourFee = table.Column<float>(type: "real", nullable: true),
                    InstructorTotalFee = table.Column<float>(type: "real", nullable: true),
                    SuperVisingFee = table.Column<float>(type: "real", nullable: true),
                    OtherFee = table.Column<float>(type: "real", nullable: true),
                    SalaryTotal = table.Column<float>(type: "real", nullable: true),
                    SuppliesCost = table.Column<float>(type: "real", nullable: true),
                    TransportCost = table.Column<float>(type: "real", nullable: true),
                    ServiceTotal = table.Column<float>(type: "real", nullable: true),
                    CourseTotal = table.Column<float>(type: "real", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrBudget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrBudget_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrBudget_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrBudget_TrCourse_CourseId",
                        column: x => x.CourseId,
                        principalTable: "TrCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrPlanCourseData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMinimum = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    TR_CourseId = table.Column<int>(type: "int", nullable: true),
                    PositionId = table.Column<int>(type: "int", nullable: true),
                    Hr_PositionId = table.Column<int>(type: "int", nullable: true),
                    FinancialDegreeId = table.Column<int>(type: "int", nullable: true),
                    Hr_FinancialDegreeId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPlanCourseData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrPlanCourseData_HrFinancialDegree_Hr_FinancialDegreeId",
                        column: x => x.Hr_FinancialDegreeId,
                        principalTable: "HrFinancialDegree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrPlanCourseData_HrPosition_Hr_PositionId",
                        column: x => x.Hr_PositionId,
                        principalTable: "HrPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrPlanCourseData_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrPlanCourseData_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrPlanCourseData_TrCourse_TR_CourseId",
                        column: x => x.TR_CourseId,
                        principalTable: "TrCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrTrackDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    TrackId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrTrackDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrTrackDetails_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrTrackDetails_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrTrackDetails_TrCourse_CourseId",
                        column: x => x.CourseId,
                        principalTable: "TrCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrTrackDetails_TrTrack_TrackId",
                        column: x => x.TrackId,
                        principalTable: "TrTrack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrTrainingCenterCourse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    TrainingCenterId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrTrainingCenterCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrTrainingCenterCourse_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrTrainingCenterCourse_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrTrainingCenterCourse_TrCourse_CourseId",
                        column: x => x.CourseId,
                        principalTable: "TrCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrTrainingCenterCourse_TrTrainingCenter_TrainingCenterId",
                        column: x => x.TrainingCenterId,
                        principalTable: "TrTrainingCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CcCostCenter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FunctionId = table.Column<int>(type: "int", nullable: false),
                    SourceId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    SubRegionId = table.Column<int>(type: "int", nullable: false),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    PlantComponentId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CcCostCenter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CcCostCenter_CcActivity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "CcActivity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcCostCenter_CcFunction_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "CcFunction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcCostCenter_CcPlant_PlantId",
                        column: x => x.PlantId,
                        principalTable: "CcPlant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcCostCenter_CcPlantComponent_PlantComponentId",
                        column: x => x.PlantComponentId,
                        principalTable: "CcPlantComponent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcCostCenter_CcRegion_RegionId",
                        column: x => x.RegionId,
                        principalTable: "CcRegion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcCostCenter_CcSource_SourceId",
                        column: x => x.SourceId,
                        principalTable: "CcSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcCostCenter_CcSubRegion_SubRegionId",
                        column: x => x.SubRegionId,
                        principalTable: "CcSubRegion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcCostCenter_ImsSection_SectionId",
                        column: x => x.SectionId,
                        principalTable: "ImsSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcCostCenter_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcCostCenter_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrAttendanceMachineWorkPlace",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AttendanceMachineId = table.Column<int>(type: "int", nullable: false),
                    WorkPlaceId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrAttendanceMachineWorkPlace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrAttendanceMachineWorkPlace_HrAttendanceMachine_AttendanceMachineId",
                        column: x => x.AttendanceMachineId,
                        principalTable: "HrAttendanceMachine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrAttendanceMachineWorkPlace_HrWorkPlace_WorkPlaceId",
                        column: x => x.WorkPlaceId,
                        principalTable: "HrWorkPlace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrAttendanceMachineWorkPlace_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrAttendanceMachineWorkPlace_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProContractorTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractorId = table.Column<int>(type: "int", nullable: false),
                    ContractorTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    HrCityStateId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProContractorTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProContractorTypes_HrCityState_HrCityStateId",
                        column: x => x.HrCityStateId,
                        principalTable: "HrCityState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProContractorTypes_ProContractor_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "ProContractor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProContractorTypes_ProContractorType_ContractorTypeId",
                        column: x => x.ContractorTypeId,
                        principalTable: "ProContractorType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProContractorTypes_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProContractorTypes_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProSellerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    SellerTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProSellerTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProSellerTypes_ProSeller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "ProSeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProSellerTypes_ProSellerType_SellerTypeId",
                        column: x => x.SellerTypeId,
                        principalTable: "ProSellerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProSellerTypes_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProSellerTypes_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tittle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Days = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NoTrainee = table.Column<int>(type: "int", nullable: true),
                    TrainingCenterId = table.Column<int>(type: "int", nullable: true),
                    ClassRoomId = table.Column<int>(type: "int", nullable: true),
                    FiscalYearId = table.Column<int>(type: "int", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    PurposeId = table.Column<int>(type: "int", nullable: true),
                    FinanacielDegreeId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrPlan_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrPlan_HrFinancialDegree_FinanacielDegreeId",
                        column: x => x.FinanacielDegreeId,
                        principalTable: "HrFinancialDegree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrPlan_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrPlan_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrPlan_TrClassRoom_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "TrClassRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrPlan_TrCourse_CourseId",
                        column: x => x.CourseId,
                        principalTable: "TrCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrPlan_TrPurpose_PurposeId",
                        column: x => x.PurposeId,
                        principalTable: "TrPurpose",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrPlan_TrTrainingCenter_TrainingCenterId",
                        column: x => x.TrainingCenterId,
                        principalTable: "TrTrainingCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FiEntryDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Credit = table.Column<double>(type: "float", nullable: false),
                    Debit = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    FiAccountItemId = table.Column<int>(type: "int", nullable: true),
                    CheckNo = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiEntryDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiEntryDetails_FiAccount_AccountId",
                        column: x => x.AccountId,
                        principalTable: "FiAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiEntryDetails_FiAccountItem_FiAccountItemId",
                        column: x => x.FiAccountItemId,
                        principalTable: "FiAccountItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiEntryDetails_FiEntry_EntryId",
                        column: x => x.EntryId,
                        principalTable: "FiEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiEntryDetails_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FiEntryDetails_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CcEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenterId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CcEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CcEquipment_CcCostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "CcCostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcEquipment_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcEquipment_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FaFixedAsset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Place = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CategoryFirstId = table.Column<int>(type: "int", nullable: false),
                    CategorySecondId = table.Column<int>(type: "int", nullable: false),
                    CategoryThirdId = table.Column<int>(type: "int", nullable: false),
                    No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CostCenterId = table.Column<int>(type: "int", nullable: true),
                    EntryId = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BuyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InitialValue = table.Column<float>(type: "real", nullable: false),
                    BookValue = table.Column<float>(type: "real", nullable: true),
                    DepreciationRate = table.Column<float>(type: "real", nullable: false),
                    SpeculateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SpeculateValue = table.Column<float>(type: "real", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaFixedAsset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaFixedAsset_CcCostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "CcCostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FaFixedAsset_FaCategoryFirst_CategoryFirstId",
                        column: x => x.CategoryFirstId,
                        principalTable: "FaCategoryFirst",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FaFixedAsset_FaCategorySecond_CategorySecondId",
                        column: x => x.CategorySecondId,
                        principalTable: "FaCategorySecond",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FaFixedAsset_FaCategoryThird_CategoryThirdId",
                        column: x => x.CategoryThirdId,
                        principalTable: "FaCategoryThird",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FaFixedAsset_FiEntry_EntryId",
                        column: x => x.EntryId,
                        principalTable: "FiEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FaFixedAsset_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FaFixedAsset_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrEmployee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    National_Code = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    Birth_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QualificationId = table.Column<int>(type: "int", nullable: false),
                    QualificationLevelId = table.Column<int>(type: "int", nullable: false),
                    SpecializationId = table.Column<int>(type: "int", nullable: false),
                    QualificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HiringDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkingStateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobTitleId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    MillitryStateId = table.Column<int>(type: "int", nullable: false),
                    HiringTypeId = table.Column<int>(type: "int", nullable: false),
                    FinancialDegreeId = table.Column<int>(type: "int", nullable: false),
                    FinancialDegreeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityStateId = table.Column<int>(type: "int", nullable: false),
                    WorkPlaceId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeveranceReasonId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    SectionId = table.Column<int>(type: "int", nullable: true),
                    CostCenterId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrEmployee_CcCostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "CcCostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployee_HrCityState_CityStateId",
                        column: x => x.CityStateId,
                        principalTable: "HrCityState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployee_HrFinancialDegree_FinancialDegreeId",
                        column: x => x.FinancialDegreeId,
                        principalTable: "HrFinancialDegree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployee_HrHiringType_HiringTypeId",
                        column: x => x.HiringTypeId,
                        principalTable: "HrHiringType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployee_HrJobTitle_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "HrJobTitle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployee_HrMillitryState_MillitryStateId",
                        column: x => x.MillitryStateId,
                        principalTable: "HrMillitryState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployee_HrPosition_PositionId",
                        column: x => x.PositionId,
                        principalTable: "HrPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployee_HrQualification_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "HrQualification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployee_HrQualificationLevel_QualificationLevelId",
                        column: x => x.QualificationLevelId,
                        principalTable: "HrQualificationLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployee_HrSeveranceReason_SeveranceReasonId",
                        column: x => x.SeveranceReasonId,
                        principalTable: "HrSeveranceReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployee_HrSpecialization_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "HrSpecialization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployee_HrWorkPlace_WorkPlaceId",
                        column: x => x.WorkPlaceId,
                        principalTable: "HrWorkPlace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployee_ImsSection_SectionId",
                        column: x => x.SectionId,
                        principalTable: "ImsSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployee_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployee_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrPlanFinancier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    PlanId = table.Column<int>(type: "int", nullable: true),
                    FinancierId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPlanFinancier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrPlanFinancier_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrPlanFinancier_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrPlanFinancier_TrFinancier_FinancierId",
                        column: x => x.FinancierId,
                        principalTable: "TrFinancier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrPlanFinancier_TrPlan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "TrPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrPlanPosition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPlanPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrPlanPosition_HrPosition_PositionId",
                        column: x => x.PositionId,
                        principalTable: "HrPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrPlanPosition_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrPlanPosition_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrPlanPosition_TrPlan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "TrPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CcEntryDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    CostCenterId = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: true),
                    Credit = table.Column<float>(type: "real", nullable: true),
                    Debit = table.Column<float>(type: "real", nullable: true),
                    Qty = table.Column<float>(type: "real", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CcEntryDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CcEntryDetails_CcActivity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "CcActivity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcEntryDetails_CcCostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "CcCostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcEntryDetails_CcEntry_EntryId",
                        column: x => x.EntryId,
                        principalTable: "CcEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcEntryDetails_CcEquipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "CcEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcEntryDetails_FiAccount_AccountId",
                        column: x => x.AccountId,
                        principalTable: "FiAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcEntryDetails_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CcEntryDetails_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FaMoveFixedAsset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Move_Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Move_No = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Statement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Document_NO = table.Column<int>(type: "int", nullable: true),
                    Document_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    CostCenterId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    FixedAssetId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaMoveFixedAsset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaMoveFixedAsset_CcActivity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "CcActivity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FaMoveFixedAsset_CcCostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "CcCostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FaMoveFixedAsset_FaFixedAsset_FixedAssetId",
                        column: x => x.FixedAssetId,
                        principalTable: "FaFixedAsset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FaMoveFixedAsset_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FaMoveFixedAsset_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrEmployeeAppraisal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Appraisal = table.Column<int>(type: "int", nullable: false),
                    Attachment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrEmployeeAppraisal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrEmployeeAppraisal_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeAppraisal_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeAppraisal_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrEmployeeAttendance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendanceMachineId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Attendance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Departure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrEmployeeAttendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrEmployeeAttendance_HrAttendanceMachine_AttendanceMachineId",
                        column: x => x.AttendanceMachineId,
                        principalTable: "HrAttendanceMachine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeAttendance_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeAttendance_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeAttendance_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrEmployeeAttendancePermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    AttendancePermissionId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrEmployeeAttendancePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrEmployeeAttendancePermission_HrAttendancePermission_AttendancePermissionId",
                        column: x => x.AttendancePermissionId,
                        principalTable: "HrAttendancePermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeAttendancePermission_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeAttendancePermission_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeAttendancePermission_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrEmployeeAttendanceSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    AttendanceScheduleId = table.Column<int>(type: "int", nullable: false),
                    AttendancePermissionId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrEmployeeAttendanceSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrEmployeeAttendanceSchedule_HrAttendancePermission_AttendancePermissionId",
                        column: x => x.AttendancePermissionId,
                        principalTable: "HrAttendancePermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeAttendanceSchedule_HrAttendanceSchedule_AttendanceScheduleId",
                        column: x => x.AttendanceScheduleId,
                        principalTable: "HrAttendanceSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeAttendanceSchedule_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeAttendanceSchedule_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeAttendanceSchedule_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrEmployeeDisciplinary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    DisciplinaryId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    NoDays = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrEmployeeDisciplinary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrEmployeeDisciplinary_HrDisciplinary_DisciplinaryId",
                        column: x => x.DisciplinaryId,
                        principalTable: "HrDisciplinary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeDisciplinary_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeDisciplinary_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeDisciplinary_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrEmployeePosition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    WorkPlaceId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrEmployeePosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrEmployeePosition_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeePosition_HrPosition_PositionId",
                        column: x => x.PositionId,
                        principalTable: "HrPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeePosition_HrWorkPlace_WorkPlaceId",
                        column: x => x.WorkPlaceId,
                        principalTable: "HrWorkPlace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeePosition_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeePosition_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrEmployeeQualification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    QualificationId = table.Column<int>(type: "int", nullable: false),
                    QualificationLevelId = table.Column<int>(type: "int", nullable: false),
                    SpecializationId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrEmployeeQualification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrEmployeeQualification_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeQualification_HrQualification_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "HrQualification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeQualification_HrQualificationLevel_QualificationLevelId",
                        column: x => x.QualificationLevelId,
                        principalTable: "HrQualificationLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeQualification_HrSpecialization_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "HrSpecialization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeQualification_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeQualification_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrEmployeeVacation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    VacationId = table.Column<int>(type: "int", nullable: false),
                    NodDays = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubstituteEmpolyeeId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrEmployeeVacation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrEmployeeVacation_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HrEmployeeVacation_HrEmployee_SubstituteEmpolyeeId",
                        column: x => x.SubstituteEmpolyeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HrEmployeeVacation_HrVacation_VacationId",
                        column: x => x.VacationId,
                        principalTable: "HrVacation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeVacation_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeVacation_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrEmployeeVacationBalance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    VacationId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrEmployeeVacationBalance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrEmployeeVacationBalance_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeVacationBalance_HrVacation_VacationId",
                        column: x => x.VacationId,
                        principalTable: "HrVacation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeVacationBalance_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrEmployeeVacationBalance_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HrIncentiveAllowance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrIncentiveAllowance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrIncentiveAllowance_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrIncentiveAllowance_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrIncentiveAllowance_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HrIncentiveAllowance_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PyExchangeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<float>(type: "real", maxLength: 50, nullable: false),
                    ExChangeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PyItemId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PyExchangeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PyExchangeDetails_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PyExchangeDetails_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PyExchangeDetails_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PyExchangeDetails_PyExchange_ExChangeId",
                        column: x => x.ExChangeId,
                        principalTable: "PyExchange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PyExchangeDetails_PyItem_PyItemId",
                        column: x => x.PyItemId,
                        principalTable: "PyItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PyInstallment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    InstallmentValue = table.Column<float>(type: "real", nullable: false),
                    InstallmentNo = table.Column<int>(type: "int", nullable: false),
                    PaiedSum = table.Column<float>(type: "real", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PyItemId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PyInstallment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PyInstallment_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PyInstallment_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PyInstallment_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PyInstallment_PyItem_PyItemId",
                        column: x => x.PyItemId,
                        principalTable: "PyItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PyItemGroupEmployee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ItemGroupId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PyItemGroupEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PyItemGroupEmployee_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PyItemGroupEmployee_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PyItemGroupEmployee_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PyItemGroupEmployee_PyItemGroup_ItemGroupId",
                        column: x => x.ItemGroupId,
                        principalTable: "PyItemGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrEmployeeExchange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DestEmployeeId = table.Column<int>(type: "int", nullable: false),
                    CostCenterId = table.Column<int>(type: "int", nullable: false),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrEmployeeExchange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrEmployeeExchange_CcCostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "CcCostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrEmployeeExchange_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrEmployeeExchange_HrEmployee_DestEmployeeId",
                        column: x => x.DestEmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrEmployeeExchange_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrEmployeeExchange_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrEmployeeExchange_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrEmployeeOpeningCustody",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    CostCenterId = table.Column<int>(type: "int", nullable: true),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrEmployeeOpeningCustody", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrEmployeeOpeningCustody_CcCostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "CcCostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrEmployeeOpeningCustody_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrEmployeeOpeningCustody_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrEmployeeOpeningCustody_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrEmployeeOpeningCustody_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrStore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    StorekeeperId = table.Column<int>(type: "int", nullable: true),
                    SectionId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrStore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrStore_HrEmployee_StorekeeperId",
                        column: x => x.StorekeeperId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrStore_ImsSection_SectionId",
                        column: x => x.SectionId,
                        principalTable: "ImsSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrStore_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrStore_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrExcuted",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Days = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NoTrainee = table.Column<int>(type: "int", nullable: true),
                    NoTraineeCorporate = table.Column<int>(type: "int", nullable: true),
                    NoTraineeTotal = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costplaned = table.Column<float>(type: "real", nullable: true),
                    Cost = table.Column<float>(type: "real", nullable: true),
                    TrainingCenterId = table.Column<int>(type: "int", nullable: true),
                    ClassRoomId = table.Column<int>(type: "int", nullable: true),
                    FiscalYearId = table.Column<int>(type: "int", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    PurposeId = table.Column<int>(type: "int", nullable: true),
                    MaterialPurposeId = table.Column<int>(type: "int", nullable: true),
                    DelegateId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrExcuted", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrExcuted_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrExcuted_HrEmployee_DelegateId",
                        column: x => x.DelegateId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrExcuted_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrExcuted_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrExcuted_TrClassRoom_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "TrClassRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrExcuted_TrCourse_CourseId",
                        column: x => x.CourseId,
                        principalTable: "TrCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrExcuted_TrPurpose_MaterialPurposeId",
                        column: x => x.MaterialPurposeId,
                        principalTable: "TrPurpose",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrExcuted_TrPurpose_PurposeId",
                        column: x => x.PurposeId,
                        principalTable: "TrPurpose",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrExcuted_TrTrainingCenter_TrainingCenterId",
                        column: x => x.TrainingCenterId,
                        principalTable: "TrTrainingCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrInstructor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    InstructorDataId = table.Column<int>(type: "int", nullable: true),
                    TrainingCenterId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrInstructor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrInstructor_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrInstructor_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrInstructor_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrInstructor_TrInstructorData_InstructorDataId",
                        column: x => x.InstructorDataId,
                        principalTable: "TrInstructorData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrInstructor_TrTrainingCenter_TrainingCenterId",
                        column: x => x.TrainingCenterId,
                        principalTable: "TrTrainingCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrGrade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    CommodityId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    StrEmployeeExchangeId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrGrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrGrade_FiAccount_AccountId",
                        column: x => x.AccountId,
                        principalTable: "FiAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrGrade_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrGrade_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrGrade_StrCommodity_CommodityId",
                        column: x => x.CommodityId,
                        principalTable: "StrCommodity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrGrade_StrEmployeeExchange_StrEmployeeExchangeId",
                        column: x => x.StrEmployeeExchangeId,
                        principalTable: "StrEmployeeExchange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrOpeningStock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrOpeningStock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrOpeningStock_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrOpeningStock_ImsSection_SectionId",
                        column: x => x.SectionId,
                        principalTable: "ImsSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrOpeningStock_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrOpeningStock_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrOpeningStock_StrStore_StoreId",
                        column: x => x.StoreId,
                        principalTable: "StrStore",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StrStockTaking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrStockTaking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrStockTaking_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrStockTaking_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrStockTaking_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrStockTaking_StrStore_StoreId",
                        column: x => x.StoreId,
                        principalTable: "StrStore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrUserStore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrUserStore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrUserStore_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrUserStore_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrUserStore_PrUser_UserId",
                        column: x => x.UserId,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrUserStore_StrStore_StoreId",
                        column: x => x.StoreId,
                        principalTable: "StrStore",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StrWithDraw",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalStatusId = table.Column<int>(type: "int", nullable: true),
                    DestStoreId = table.Column<int>(type: "int", nullable: true),
                    DestStoreConfirm = table.Column<bool>(type: "bit", nullable: true),
                    DestStoreUserId = table.Column<int>(type: "int", nullable: false),
                    Attachment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    CostCenterId = table.Column<int>(type: "int", nullable: true),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    CommodityId = table.Column<int>(type: "int", nullable: true),
                    STR_CommodityId = table.Column<int>(type: "int", nullable: true),
                    WithDrawTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrWithDraw", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrWithDraw_CcCostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "CcCostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrWithDraw_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrWithDraw_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrWithDraw_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrWithDraw_PrUser_DestStoreUserId",
                        column: x => x.DestStoreUserId,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrWithDraw_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrWithDraw_StrApprovalStatus_ApprovalStatusId",
                        column: x => x.ApprovalStatusId,
                        principalTable: "StrApprovalStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrWithDraw_StrCommodity_STR_CommodityId",
                        column: x => x.STR_CommodityId,
                        principalTable: "StrCommodity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrWithDraw_StrStore_DestStoreId",
                        column: x => x.DestStoreId,
                        principalTable: "StrStore",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrWithDraw_StrStore_StoreId",
                        column: x => x.StoreId,
                        principalTable: "StrStore",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrWithDraw_StrWithDrawType_WithDrawTypeId",
                        column: x => x.WithDrawTypeId,
                        principalTable: "StrWithDrawType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrExcutedFinancier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExcutedId = table.Column<int>(type: "int", nullable: false),
                    FinancierId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrExcutedFinancier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrExcutedFinancier_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrExcutedFinancier_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrExcutedFinancier_TrExcuted_ExcutedId",
                        column: x => x.ExcutedId,
                        principalTable: "TrExcuted",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrExcutedFinancier_TrFinancier_FinancierId",
                        column: x => x.FinancierId,
                        principalTable: "TrFinancier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrExcutedPosition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExcutedId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrExcutedPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrExcutedPosition_HrPosition_PositionId",
                        column: x => x.PositionId,
                        principalTable: "HrPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrExcutedPosition_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrExcutedPosition_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrExcutedPosition_TrExcuted_ExcutedId",
                        column: x => x.ExcutedId,
                        principalTable: "TrExcuted",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrExcutedTrainee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExcutedId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    TraineeId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrExcutedTrainee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrExcutedTrainee_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrExcutedTrainee_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrExcutedTrainee_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrExcutedTrainee_TrExcuted_ExcutedId",
                        column: x => x.ExcutedId,
                        principalTable: "TrExcuted",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrExcutedTrainee_TrTrainee_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "TrTrainee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrExcutedInstructor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExcutedId = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrExcutedInstructor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrExcutedInstructor_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrExcutedInstructor_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrExcutedInstructor_TrExcuted_ExcutedId",
                        column: x => x.ExcutedId,
                        principalTable: "TrExcuted",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrExcutedInstructor_TrInstructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "TrInstructor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrInstructorCourse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    price = table.Column<float>(type: "real", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrInstructorCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrInstructorCourse_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrInstructorCourse_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrInstructorCourse_TrCourse_CourseId",
                        column: x => x.CourseId,
                        principalTable: "TrCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrInstructorCourse_TrInstructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "TrInstructor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrPlanInstructor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPlanInstructor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrPlanInstructor_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrPlanInstructor_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrPlanInstructor_TrInstructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "TrInstructor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrPlanInstructor_TrPlan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "TrPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrPlatoon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrPlatoon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrPlatoon_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrPlatoon_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrPlatoon_StrGrade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "StrGrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrAdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    EntryNo = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    SourceStoreId = table.Column<int>(type: "int", nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    withdrawId = table.Column<int>(type: "int", nullable: true),
                    SellerId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatusId = table.Column<int>(type: "int", nullable: true),
                    CommodityId = table.Column<int>(type: "int", nullable: false),
                    STR_CommodityId = table.Column<int>(type: "int", nullable: true),
                    AddTypeId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrAdd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrAdd_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrAdd_HrEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrAdd_ProSeller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "ProSeller",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrAdd_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrAdd_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrAdd_StrAddType_AddTypeId",
                        column: x => x.AddTypeId,
                        principalTable: "StrAddType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrAdd_StrApprovalStatus_ApprovalStatusId",
                        column: x => x.ApprovalStatusId,
                        principalTable: "StrApprovalStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrAdd_StrCommodity_STR_CommodityId",
                        column: x => x.STR_CommodityId,
                        principalTable: "StrCommodity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrAdd_StrStore_SourceStoreId",
                        column: x => x.SourceStoreId,
                        principalTable: "StrStore",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrAdd_StrStore_StoreId",
                        column: x => x.StoreId,
                        principalTable: "StrStore",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrAdd_StrWithDraw_withdrawId",
                        column: x => x.withdrawId,
                        principalTable: "StrWithDraw",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PlatoonId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrGroup_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrGroup_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrGroup_StrPlatoon_PlatoonId",
                        column: x => x.PlatoonId,
                        principalTable: "StrPlatoon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    No = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FullCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CommodityId = table.Column<int>(type: "int", nullable: false),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    PlatoonId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrItem_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrItem_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrItem_StrCommodity_CommodityId",
                        column: x => x.CommodityId,
                        principalTable: "StrCommodity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrItem_StrGrade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "StrGrade",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrItem_StrGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "StrGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrItem_StrPlatoon_PlatoonId",
                        column: x => x.PlatoonId,
                        principalTable: "StrPlatoon",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrItem_StrUnit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "StrUnit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StrAddDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    BalanceQty = table.Column<float>(type: "real", nullable: false),
                    AvgPrice = table.Column<float>(type: "real", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<float>(type: "real", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AddId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrAddDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrAddDetails_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrAddDetails_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrAddDetails_StrAdd_AddId",
                        column: x => x.AddId,
                        principalTable: "StrAdd",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrAddDetails_StrItem_ItemId",
                        column: x => x.ItemId,
                        principalTable: "StrItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StrEmployeeExchangeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<float>(type: "real", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Employee_ExchangeId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrEmployeeExchangeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrEmployeeExchangeDetails_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrEmployeeExchangeDetails_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrEmployeeExchangeDetails_StrEmployeeExchange_Employee_ExchangeId",
                        column: x => x.Employee_ExchangeId,
                        principalTable: "StrEmployeeExchange",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrEmployeeExchangeDetails_StrItem_ItemId",
                        column: x => x.ItemId,
                        principalTable: "StrItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StrEmployeeOpeningCustodyDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustodyId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrEmployeeOpeningCustodyDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrEmployeeOpeningCustodyDetails_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrEmployeeOpeningCustodyDetails_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrEmployeeOpeningCustodyDetails_StrEmployeeOpeningCustody_CustodyId",
                        column: x => x.CustodyId,
                        principalTable: "StrEmployeeOpeningCustody",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrEmployeeOpeningCustodyDetails_StrItem_ItemId",
                        column: x => x.ItemId,
                        principalTable: "StrItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StrOpeningStockDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    STR_Opening_StockId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrOpeningStockDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrOpeningStockDetails_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrOpeningStockDetails_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrOpeningStockDetails_StrItem_ItemId",
                        column: x => x.ItemId,
                        principalTable: "StrItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrOpeningStockDetails_StrOpeningStock_STR_Opening_StockId",
                        column: x => x.STR_Opening_StockId,
                        principalTable: "StrOpeningStock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrProduct_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrProduct_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrProduct_StrItem_ItemId",
                        column: x => x.ItemId,
                        principalTable: "StrItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrProduct_StrModel_ModelId",
                        column: x => x.ModelId,
                        principalTable: "StrModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrProduct_StrVendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "StrVendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrStockTakingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemQty = table.Column<float>(type: "real", nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: false),
                    Qty = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    STRStockTakingId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrStockTakingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrStockTakingDetails_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrStockTakingDetails_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrStockTakingDetails_StrItem_ItemId",
                        column: x => x.ItemId,
                        principalTable: "StrItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrStockTakingDetails_StrStockTaking_STRStockTakingId",
                        column: x => x.STRStockTakingId,
                        principalTable: "StrStockTaking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrWithDrawDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<float>(type: "real", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STR_WithdrawId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrWithDrawDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrWithDrawDetails_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrWithDrawDetails_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrWithDrawDetails_StrItem_ItemId",
                        column: x => x.ItemId,
                        principalTable: "StrItem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrWithDrawDetails_StrWithDraw_STR_WithdrawId",
                        column: x => x.STR_WithdrawId,
                        principalTable: "StrWithDraw",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrProductSerial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Serial = table.Column<int>(type: "int", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrProductSerial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrProductSerial_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrProductSerial_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrProductSerial_StrProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "StrProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrAddDetailsSerial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDetailsId = table.Column<int>(type: "int", nullable: false),
                    ProductSerialId = table.Column<int>(type: "int", nullable: false),
                    QTy = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrAddDetailsSerial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrAddDetailsSerial_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrAddDetailsSerial_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrAddDetailsSerial_StrAddDetails_AddDetailsId",
                        column: x => x.AddDetailsId,
                        principalTable: "StrAddDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrAddDetailsSerial_StrProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "StrProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrAddDetailsSerial_StrProductSerial_ProductSerialId",
                        column: x => x.ProductSerialId,
                        principalTable: "StrProductSerial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrEmployeeExchangeSerial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeExchangeDetailId = table.Column<int>(type: "int", nullable: false),
                    ProductSerialId = table.Column<int>(type: "int", nullable: false),
                    QTy = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrEmployeeExchangeSerial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrEmployeeExchangeSerial_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrEmployeeExchangeSerial_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrEmployeeExchangeSerial_StrEmployeeExchangeDetails_EmployeeExchangeDetailId",
                        column: x => x.EmployeeExchangeDetailId,
                        principalTable: "StrEmployeeExchangeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrEmployeeExchangeSerial_StrProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "StrProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrEmployeeExchangeSerial_StrProductSerial_ProductSerialId",
                        column: x => x.ProductSerialId,
                        principalTable: "StrProductSerial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrEmployeeOpeningCustodySerial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeOpeningCustodyDetailId = table.Column<int>(type: "int", nullable: false),
                    ProductSerialId = table.Column<int>(type: "int", nullable: false),
                    QTy = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrEmployeeOpeningCustodySerial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrEmployeeOpeningCustodySerial_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrEmployeeOpeningCustodySerial_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrEmployeeOpeningCustodySerial_StrEmployeeOpeningCustodyDetails_EmployeeOpeningCustodyDetailId",
                        column: x => x.EmployeeOpeningCustodyDetailId,
                        principalTable: "StrEmployeeOpeningCustodyDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrEmployeeOpeningCustodySerial_StrProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "StrProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrEmployeeOpeningCustodySerial_StrProductSerial_ProductSerialId",
                        column: x => x.ProductSerialId,
                        principalTable: "StrProductSerial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrOpeningStockDetailsSerial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpeningStockDetailId = table.Column<int>(type: "int", nullable: false),
                    ProductSerialId = table.Column<int>(type: "int", nullable: false),
                    QTy = table.Column<int>(type: "int", nullable: true),
                    ProductI = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrOpeningStockDetailsSerial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrOpeningStockDetailsSerial_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrOpeningStockDetailsSerial_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrOpeningStockDetailsSerial_StrOpeningStockDetails_OpeningStockDetailId",
                        column: x => x.OpeningStockDetailId,
                        principalTable: "StrOpeningStockDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrOpeningStockDetailsSerial_StrProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "StrProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrOpeningStockDetailsSerial_StrProductSerial_ProductSerialId",
                        column: x => x.ProductSerialId,
                        principalTable: "StrProductSerial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StrWithDrawDetailsSerial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrWithDrawDetailsId = table.Column<int>(type: "int", nullable: false),
                    ProductSerialId = table.Column<int>(type: "int", nullable: false),
                    QTy = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    UpdateByID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrWithDrawDetailsSerial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrWithDrawDetailsSerial_PrUser_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrWithDrawDetailsSerial_PrUser_UpdateByID",
                        column: x => x.UpdateByID,
                        principalTable: "PrUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrWithDrawDetailsSerial_StrProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "StrProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrWithDrawDetailsSerial_StrProductSerial_ProductSerialId",
                        column: x => x.ProductSerialId,
                        principalTable: "StrProductSerial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StrWithDrawDetailsSerial_StrWithDrawDetails_StrWithDrawDetailsId",
                        column: x => x.StrWithDrawDetailsId,
                        principalTable: "StrWithDrawDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CcActivity_CreatedByID",
                table: "CcActivity",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_CcActivity_UpdateByID",
                table: "CcActivity",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_CcCostCenter_ActivityId",
                table: "CcCostCenter",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_CcCostCenter_CreatedByID",
                table: "CcCostCenter",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_CcCostCenter_FunctionId",
                table: "CcCostCenter",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_CcCostCenter_PlantComponentId",
                table: "CcCostCenter",
                column: "PlantComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_CcCostCenter_PlantId",
                table: "CcCostCenter",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_CcCostCenter_RegionId",
                table: "CcCostCenter",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_CcCostCenter_SectionId",
                table: "CcCostCenter",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CcCostCenter_SourceId",
                table: "CcCostCenter",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_CcCostCenter_SubRegionId",
                table: "CcCostCenter",
                column: "SubRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_CcCostCenter_UpdateByID",
                table: "CcCostCenter",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_CcEntry_CreatedByID",
                table: "CcEntry",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_CcEntry_UpdateByID",
                table: "CcEntry",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_CcEntryDetails_AccountId",
                table: "CcEntryDetails",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CcEntryDetails_ActivityId",
                table: "CcEntryDetails",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_CcEntryDetails_CostCenterId",
                table: "CcEntryDetails",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_CcEntryDetails_CreatedByID",
                table: "CcEntryDetails",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_CcEntryDetails_EntryId",
                table: "CcEntryDetails",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_CcEntryDetails_EquipmentId",
                table: "CcEntryDetails",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CcEntryDetails_UpdateByID",
                table: "CcEntryDetails",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_CcEquipment_CostCenterId",
                table: "CcEquipment",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_CcEquipment_CreatedByID",
                table: "CcEquipment",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_CcEquipment_UpdateByID",
                table: "CcEquipment",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_CcFunction_CreatedByID",
                table: "CcFunction",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_CcFunction_UpdateByID",
                table: "CcFunction",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_CcPlant_CreatedByID",
                table: "CcPlant",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_CcPlant_SubRegionId",
                table: "CcPlant",
                column: "SubRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_CcPlant_UpdateByID",
                table: "CcPlant",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_CcPlantComponent_CreatedByID",
                table: "CcPlantComponent",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_CcPlantComponent_UpdateByID",
                table: "CcPlantComponent",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_CcRegion_CreatedByID",
                table: "CcRegion",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_CcRegion_UpdateByID",
                table: "CcRegion",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_CcSource_CreatedByID",
                table: "CcSource",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_CcSource_FunctionId",
                table: "CcSource",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_CcSource_UpdateByID",
                table: "CcSource",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_CcSubRegion_CreatedByID",
                table: "CcSubRegion",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_CcSubRegion_RegionId",
                table: "CcSubRegion",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_CcSubRegion_UpdateByID",
                table: "CcSubRegion",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_Department_CreatedByID",
                table: "Department",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Department_GeneralDepartmentId",
                table: "Department",
                column: "GeneralDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_UpdateByID",
                table: "Department",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFinancialDegree_CreatedByID",
                table: "EmployeeFinancialDegree",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFinancialDegree_FinancialDegreeId",
                table: "EmployeeFinancialDegree",
                column: "FinancialDegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFinancialDegree_UpdateByID",
                table: "EmployeeFinancialDegree",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_FaCategoryFirst_CreatedByID",
                table: "FaCategoryFirst",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_FaCategoryFirst_UpdateByID",
                table: "FaCategoryFirst",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_FaCategorySecond_CreatedByID",
                table: "FaCategorySecond",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_FaCategorySecond_UpdateByID",
                table: "FaCategorySecond",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_FaCategoryThird_CreatedByID",
                table: "FaCategoryThird",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_FaCategoryThird_UpdateByID",
                table: "FaCategoryThird",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_FaFixedAsset_CategoryFirstId",
                table: "FaFixedAsset",
                column: "CategoryFirstId");

            migrationBuilder.CreateIndex(
                name: "IX_FaFixedAsset_CategorySecondId",
                table: "FaFixedAsset",
                column: "CategorySecondId");

            migrationBuilder.CreateIndex(
                name: "IX_FaFixedAsset_CategoryThirdId",
                table: "FaFixedAsset",
                column: "CategoryThirdId");

            migrationBuilder.CreateIndex(
                name: "IX_FaFixedAsset_CostCenterId",
                table: "FaFixedAsset",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_FaFixedAsset_CreatedByID",
                table: "FaFixedAsset",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_FaFixedAsset_EntryId",
                table: "FaFixedAsset",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_FaFixedAsset_UpdateByID",
                table: "FaFixedAsset",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_FaMoveFixedAsset_ActivityId",
                table: "FaMoveFixedAsset",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_FaMoveFixedAsset_CostCenterId",
                table: "FaMoveFixedAsset",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_FaMoveFixedAsset_CreatedByID",
                table: "FaMoveFixedAsset",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_FaMoveFixedAsset_FixedAssetId",
                table: "FaMoveFixedAsset",
                column: "FixedAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_FaMoveFixedAsset_UpdateByID",
                table: "FaMoveFixedAsset",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_FiAccount_Code",
                table: "FiAccount",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FiAccount_CreatedByID",
                table: "FiAccount",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_FiAccount_FiAccountHierarchyId",
                table: "FiAccount",
                column: "FiAccountHierarchyId");

            migrationBuilder.CreateIndex(
                name: "IX_FiAccount_UpdateByID",
                table: "FiAccount",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_FiAccountHierarchy_CreatedByID",
                table: "FiAccountHierarchy",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_FiAccountHierarchy_UpdateByID",
                table: "FiAccountHierarchy",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_FiAccountItem_AccountId",
                table: "FiAccountItem",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FiAccountItem_AccountItemCategoryId",
                table: "FiAccountItem",
                column: "AccountItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FiAccountItem_CreatedByID",
                table: "FiAccountItem",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_FiAccountItem_UpdateByID",
                table: "FiAccountItem",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_FiAccountItemCategory_CreatedByID",
                table: "FiAccountItemCategory",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_FiAccountItemCategory_UpdateByID",
                table: "FiAccountItemCategory",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_FiAccountParent_AccountId",
                table: "FiAccountParent",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FiAccountParent_CreatedByID",
                table: "FiAccountParent",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_FiAccountParent_ParentId",
                table: "FiAccountParent",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_FiAccountParent_UpdateByID",
                table: "FiAccountParent",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_FiEntry_CreatedByID",
                table: "FiEntry",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_FiEntry_FiEntrySourceTypeId",
                table: "FiEntry",
                column: "FiEntrySourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FiEntry_FiscalYearId",
                table: "FiEntry",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_FiEntry_JournalId",
                table: "FiEntry",
                column: "JournalId");

            migrationBuilder.CreateIndex(
                name: "IX_FiEntry_SectionId",
                table: "FiEntry",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FiEntry_UpdateByID",
                table: "FiEntry",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_FiEntryDetails_AccountId",
                table: "FiEntryDetails",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FiEntryDetails_CreatedByID",
                table: "FiEntryDetails",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_FiEntryDetails_EntryId",
                table: "FiEntryDetails",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_FiEntryDetails_FiAccountItemId",
                table: "FiEntryDetails",
                column: "FiAccountItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FiEntryDetails_UpdateByID",
                table: "FiEntryDetails",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_FiEntrySource_CreatedByID",
                table: "FiEntrySource",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_FiEntrySource_UpdateByID",
                table: "FiEntrySource",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_FiEntrySourceType_CreatedByID",
                table: "FiEntrySourceType",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_FiEntrySourceType_EntrySourceId",
                table: "FiEntrySourceType",
                column: "EntrySourceId");

            migrationBuilder.CreateIndex(
                name: "IX_FiEntrySourceType_UpdateByID",
                table: "FiEntrySourceType",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_FiJournal_CreatedByID",
                table: "FiJournal",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_FiJournal_FiscalYearId",
                table: "FiJournal",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_FiJournal_SectionId",
                table: "FiJournal",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FiJournal_UpdateByID",
                table: "FiJournal",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_FiscalYear_CreatedByID",
                table: "FiscalYear",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_FiscalYear_UpdateByID",
                table: "FiscalYear",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralDepartment_CreatedByID",
                table: "GeneralDepartment",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralDepartment_UpdateByID",
                table: "GeneralDepartment",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrAttendanceMachine_CreatedByID",
                table: "HrAttendanceMachine",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrAttendanceMachine_UpdateByID",
                table: "HrAttendanceMachine",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrAttendanceMachineWorkPlace_AttendanceMachineId",
                table: "HrAttendanceMachineWorkPlace",
                column: "AttendanceMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_HrAttendanceMachineWorkPlace_CreatedByID",
                table: "HrAttendanceMachineWorkPlace",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrAttendanceMachineWorkPlace_UpdateByID",
                table: "HrAttendanceMachineWorkPlace",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrAttendanceMachineWorkPlace_WorkPlaceId",
                table: "HrAttendanceMachineWorkPlace",
                column: "WorkPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_HrAttendancePermission_CreatedByID",
                table: "HrAttendancePermission",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrAttendancePermission_UpdateByID",
                table: "HrAttendancePermission",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrAttendanceSchedule_CreatedByID",
                table: "HrAttendanceSchedule",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrAttendanceSchedule_UpdateByID",
                table: "HrAttendanceSchedule",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrCity_CreatedByID",
                table: "HrCity",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrCity_UpdateByID",
                table: "HrCity",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrCityState_CityId",
                table: "HrCityState",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_HrCityState_CreatedByID",
                table: "HrCityState",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrCityState_UpdateByID",
                table: "HrCityState",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrDisciplinary_CreatedByID",
                table: "HrDisciplinary",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrDisciplinary_UpdateByID",
                table: "HrDisciplinary",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_CityStateId",
                table: "HrEmployee",
                column: "CityStateId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_Code",
                table: "HrEmployee",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_CostCenterId",
                table: "HrEmployee",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_CreatedByID",
                table: "HrEmployee",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_DepartmentId",
                table: "HrEmployee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_FinancialDegreeId",
                table: "HrEmployee",
                column: "FinancialDegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_HiringTypeId",
                table: "HrEmployee",
                column: "HiringTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_Id",
                table: "HrEmployee",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_JobTitleId",
                table: "HrEmployee",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_MillitryStateId",
                table: "HrEmployee",
                column: "MillitryStateId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_Name",
                table: "HrEmployee",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_PositionId",
                table: "HrEmployee",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_QualificationId",
                table: "HrEmployee",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_QualificationLevelId",
                table: "HrEmployee",
                column: "QualificationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_SectionId",
                table: "HrEmployee",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_SeveranceReasonId",
                table: "HrEmployee",
                column: "SeveranceReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_SpecializationId",
                table: "HrEmployee",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_UpdateByID",
                table: "HrEmployee",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployee_WorkPlaceId",
                table: "HrEmployee",
                column: "WorkPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeAppraisal_CreatedByID",
                table: "HrEmployeeAppraisal",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeAppraisal_EmployeeId",
                table: "HrEmployeeAppraisal",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeAppraisal_UpdateByID",
                table: "HrEmployeeAppraisal",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeAttendance_AttendanceMachineId",
                table: "HrEmployeeAttendance",
                column: "AttendanceMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeAttendance_CreatedByID",
                table: "HrEmployeeAttendance",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeAttendance_EmployeeId",
                table: "HrEmployeeAttendance",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeAttendance_UpdateByID",
                table: "HrEmployeeAttendance",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeAttendancePermission_AttendancePermissionId",
                table: "HrEmployeeAttendancePermission",
                column: "AttendancePermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeAttendancePermission_CreatedByID",
                table: "HrEmployeeAttendancePermission",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeAttendancePermission_EmployeeId",
                table: "HrEmployeeAttendancePermission",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeAttendancePermission_UpdateByID",
                table: "HrEmployeeAttendancePermission",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeAttendanceSchedule_AttendancePermissionId",
                table: "HrEmployeeAttendanceSchedule",
                column: "AttendancePermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeAttendanceSchedule_AttendanceScheduleId",
                table: "HrEmployeeAttendanceSchedule",
                column: "AttendanceScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeAttendanceSchedule_CreatedByID",
                table: "HrEmployeeAttendanceSchedule",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeAttendanceSchedule_EmployeeId",
                table: "HrEmployeeAttendanceSchedule",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeAttendanceSchedule_UpdateByID",
                table: "HrEmployeeAttendanceSchedule",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeDisciplinary_CreatedByID",
                table: "HrEmployeeDisciplinary",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeDisciplinary_DisciplinaryId",
                table: "HrEmployeeDisciplinary",
                column: "DisciplinaryId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeDisciplinary_EmployeeId",
                table: "HrEmployeeDisciplinary",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeDisciplinary_UpdateByID",
                table: "HrEmployeeDisciplinary",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeePosition_CreatedByID",
                table: "HrEmployeePosition",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeePosition_EmployeeId",
                table: "HrEmployeePosition",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeePosition_PositionId",
                table: "HrEmployeePosition",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeePosition_UpdateByID",
                table: "HrEmployeePosition",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeePosition_WorkPlaceId",
                table: "HrEmployeePosition",
                column: "WorkPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeQualification_CreatedByID",
                table: "HrEmployeeQualification",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeQualification_EmployeeId",
                table: "HrEmployeeQualification",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeQualification_QualificationId",
                table: "HrEmployeeQualification",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeQualification_QualificationLevelId",
                table: "HrEmployeeQualification",
                column: "QualificationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeQualification_SpecializationId",
                table: "HrEmployeeQualification",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeQualification_UpdateByID",
                table: "HrEmployeeQualification",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeVacation_CreatedByID",
                table: "HrEmployeeVacation",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeVacation_EmployeeId",
                table: "HrEmployeeVacation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeVacation_SubstituteEmpolyeeId",
                table: "HrEmployeeVacation",
                column: "SubstituteEmpolyeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeVacation_UpdateByID",
                table: "HrEmployeeVacation",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeVacation_VacationId",
                table: "HrEmployeeVacation",
                column: "VacationId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeVacationBalance_CreatedByID",
                table: "HrEmployeeVacationBalance",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeVacationBalance_EmployeeId",
                table: "HrEmployeeVacationBalance",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeVacationBalance_UpdateByID",
                table: "HrEmployeeVacationBalance",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeVacationBalance_VacationId",
                table: "HrEmployeeVacationBalance",
                column: "VacationId");

            migrationBuilder.CreateIndex(
                name: "IX_HrFinancialDegree_CreatedByID",
                table: "HrFinancialDegree",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrFinancialDegree_UpdateByID",
                table: "HrFinancialDegree",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrFinancialDegreeSalary_CreatedByID",
                table: "HrFinancialDegreeSalary",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrFinancialDegreeSalary_FinancialDegreeId",
                table: "HrFinancialDegreeSalary",
                column: "FinancialDegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_HrFinancialDegreeSalary_UpdateByID",
                table: "HrFinancialDegreeSalary",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrHiringType_CreatedByID",
                table: "HrHiringType",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrHiringType_UpdateByID",
                table: "HrHiringType",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrHoliday_CreatedByID",
                table: "HrHoliday",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrHoliday_UpdateByID",
                table: "HrHoliday",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrHolidaySchedule_CreatedByID",
                table: "HrHolidaySchedule",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrHolidaySchedule_HolidayId",
                table: "HrHolidaySchedule",
                column: "HolidayId");

            migrationBuilder.CreateIndex(
                name: "IX_HrHolidaySchedule_UpdateByID",
                table: "HrHolidaySchedule",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrIncentiveAllowance_CreatedByID",
                table: "HrIncentiveAllowance",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrIncentiveAllowance_EmployeeId",
                table: "HrIncentiveAllowance",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HrIncentiveAllowance_FiscalYearId",
                table: "HrIncentiveAllowance",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_HrIncentiveAllowance_UpdateByID",
                table: "HrIncentiveAllowance",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrJobTitle_CreatedByID",
                table: "HrJobTitle",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrJobTitle_UpdateByID",
                table: "HrJobTitle",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrMillitryState_CreatedByID",
                table: "HrMillitryState",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrMillitryState_UpdateByID",
                table: "HrMillitryState",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrPosition_CreatedByID",
                table: "HrPosition",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrPosition_UpdateByID",
                table: "HrPosition",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrQualification_CreatedByID",
                table: "HrQualification",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrQualification_QualitativeGroupId",
                table: "HrQualification",
                column: "QualitativeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_HrQualification_UpdateByID",
                table: "HrQualification",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrQualificationLevel_CreatedByID",
                table: "HrQualificationLevel",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrQualificationLevel_UpdateByID",
                table: "HrQualificationLevel",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrQualitativeGroup_CreatedByID",
                table: "HrQualitativeGroup",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrQualitativeGroup_UpdateByID",
                table: "HrQualitativeGroup",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrSeveranceReason_CreatedByID",
                table: "HrSeveranceReason",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrSeveranceReason_UpdateByID",
                table: "HrSeveranceReason",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrSpecialization_CreatedByID",
                table: "HrSpecialization",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrSpecialization_QualificationId",
                table: "HrSpecialization",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_HrSpecialization_UpdateByID",
                table: "HrSpecialization",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrVacation_CreatedByID",
                table: "HrVacation",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrVacation_UpdateByID",
                table: "HrVacation",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrWorkPlace_CityStateId",
                table: "HrWorkPlace",
                column: "CityStateId");

            migrationBuilder.CreateIndex(
                name: "IX_HrWorkPlace_CreatedByID",
                table: "HrWorkPlace",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_HrWorkPlace_UpdateByID",
                table: "HrWorkPlace",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_ImsSection_CreatedByID",
                table: "ImsSection",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ImsSection_UpdateByID",
                table: "ImsSection",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_PrGroup_CreatedByID",
                table: "PrGroup",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PrGroup_SectionId",
                table: "PrGroup",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PrGroup_UpdateByID",
                table: "PrGroup",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_PrGroupPrivileges_CreatedByID",
                table: "PrGroupPrivileges",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PrGroupPrivileges_GroupId",
                table: "PrGroupPrivileges",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PrGroupPrivileges_PrivilegesId",
                table: "PrGroupPrivileges",
                column: "PrivilegesId");

            migrationBuilder.CreateIndex(
                name: "IX_PrGroupPrivileges_UpdateByID",
                table: "PrGroupPrivileges",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_PrGroupRole_CreatedByID",
                table: "PrGroupRole",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PrGroupRole_GroupId",
                table: "PrGroupRole",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PrGroupRole_RoleId",
                table: "PrGroupRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PrGroupRole_UpdateByID",
                table: "PrGroupRole",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_PrModule_CreatedByID",
                table: "PrModule",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PrModule_UpdateByID",
                table: "PrModule",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProContractor_CityId",
                table: "ProContractor",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProContractor_CityStateId",
                table: "ProContractor",
                column: "CityStateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProContractor_CreatedByID",
                table: "ProContractor",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProContractor_UpdateByID",
                table: "ProContractor",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProContractorType_CreatedByID",
                table: "ProContractorType",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProContractorType_UpdateByID",
                table: "ProContractorType",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProContractorTypes_ContractorId",
                table: "ProContractorTypes",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProContractorTypes_ContractorTypeId",
                table: "ProContractorTypes",
                column: "ContractorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProContractorTypes_CreatedByID",
                table: "ProContractorTypes",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProContractorTypes_HrCityStateId",
                table: "ProContractorTypes",
                column: "HrCityStateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProContractorTypes_UpdateByID",
                table: "ProContractorTypes",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProOperationType_CreatedByID",
                table: "ProOperationType",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProOperationType_UpdateByID",
                table: "ProOperationType",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProPlantType_CreatedByID",
                table: "ProPlantType",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProPlantType_UpdateByID",
                table: "ProPlantType",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProSeller_CityId",
                table: "ProSeller",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProSeller_CityStateId",
                table: "ProSeller",
                column: "CityStateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProSeller_CreatedByID",
                table: "ProSeller",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProSeller_UpdateByID",
                table: "ProSeller",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProSellerType_CreatedByID",
                table: "ProSellerType",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProSellerType_UpdateByID",
                table: "ProSellerType",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProSellerTypes_CreatedByID",
                table: "ProSellerTypes",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProSellerTypes_SellerId",
                table: "ProSellerTypes",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProSellerTypes_SellerTypeId",
                table: "ProSellerTypes",
                column: "SellerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProSellerTypes_UpdateByID",
                table: "ProSellerTypes",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProTender_CityStateId",
                table: "ProTender",
                column: "CityStateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTender_CreatedByID",
                table: "ProTender",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProTender_OperationTypeId",
                table: "ProTender",
                column: "OperationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTender_PlanTypeId",
                table: "ProTender",
                column: "PlanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTender_TenderTypeId",
                table: "ProTender",
                column: "TenderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProTender_UpdateByID",
                table: "ProTender",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderType_CreatedByID",
                table: "ProTenderType",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ProTenderType_UpdateByID",
                table: "ProTenderType",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_PrPrivileges_CreatedByID",
                table: "PrPrivileges",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PrPrivileges_UpdateByID",
                table: "PrPrivileges",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_PrRole_CreatedByID",
                table: "PrRole",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PrRole_ModuleId",
                table: "PrRole",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_PrRole_UpdateByID",
                table: "PrRole",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_PrUser_Name",
                table: "PrUser",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PrUserGroup_CreatedByID",
                table: "PrUserGroup",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PrUserGroup_GroupId",
                table: "PrUserGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PrUserGroup_UpdateByID",
                table: "PrUserGroup",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_PrUserGroup_UserId",
                table: "PrUserGroup",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PrUserModule_CreatedByID",
                table: "PrUserModule",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PrUserModule_ModuleId",
                table: "PrUserModule",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_PrUserModule_UpdateByID",
                table: "PrUserModule",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_PrUserModule_UserId",
                table: "PrUserModule",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PyExchange_CreatedByID",
                table: "PyExchange",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PyExchange_FiscalYearId",
                table: "PyExchange",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PyExchange_UpdateByID",
                table: "PyExchange",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_PyExchangeDetails_CreatedByID",
                table: "PyExchangeDetails",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PyExchangeDetails_EmployeeId",
                table: "PyExchangeDetails",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PyExchangeDetails_ExChangeId",
                table: "PyExchangeDetails",
                column: "ExChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_PyExchangeDetails_PyItemId",
                table: "PyExchangeDetails",
                column: "PyItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PyExchangeDetails_UpdateByID",
                table: "PyExchangeDetails",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_PyInstallment_CreatedByID",
                table: "PyInstallment",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PyInstallment_EmployeeId",
                table: "PyInstallment",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PyInstallment_PyItemId",
                table: "PyInstallment",
                column: "PyItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PyInstallment_UpdateByID",
                table: "PyInstallment",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_PyItem_CategoryId",
                table: "PyItem",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PyItem_CreatedByID",
                table: "PyItem",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PyItem_UpdateByID",
                table: "PyItem",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_PyItemCategory_CreatedByID",
                table: "PyItemCategory",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PyItemCategory_UpdateByID",
                table: "PyItemCategory",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_PyItemGroup_CreatedByID",
                table: "PyItemGroup",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PyItemGroup_UpdateByID",
                table: "PyItemGroup",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_PyItemGroupDetails_CreatedByID",
                table: "PyItemGroupDetails",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PyItemGroupDetails_ItemGroupId",
                table: "PyItemGroupDetails",
                column: "ItemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PyItemGroupDetails_PyItemId",
                table: "PyItemGroupDetails",
                column: "PyItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PyItemGroupDetails_UpdateByID",
                table: "PyItemGroupDetails",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_PyItemGroupEmployee_CreatedByID",
                table: "PyItemGroupEmployee",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PyItemGroupEmployee_EmployeeId",
                table: "PyItemGroupEmployee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PyItemGroupEmployee_ItemGroupId",
                table: "PyItemGroupEmployee",
                column: "ItemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PyItemGroupEmployee_UpdateByID",
                table: "PyItemGroupEmployee",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_PyTaxBracket_CreatedByID",
                table: "PyTaxBracket",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PyTaxBracket_UpdateByID",
                table: "PyTaxBracket",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrAdd_AddTypeId",
                table: "StrAdd",
                column: "AddTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StrAdd_ApprovalStatusId",
                table: "StrAdd",
                column: "ApprovalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_StrAdd_CreatedByID",
                table: "StrAdd",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrAdd_EmployeeId",
                table: "StrAdd",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StrAdd_FiscalYearId",
                table: "StrAdd",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StrAdd_SellerId",
                table: "StrAdd",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_StrAdd_SourceStoreId",
                table: "StrAdd",
                column: "SourceStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StrAdd_StoreId",
                table: "StrAdd",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StrAdd_STR_CommodityId",
                table: "StrAdd",
                column: "STR_CommodityId");

            migrationBuilder.CreateIndex(
                name: "IX_StrAdd_UpdateByID",
                table: "StrAdd",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrAdd_withdrawId",
                table: "StrAdd",
                column: "withdrawId");

            migrationBuilder.CreateIndex(
                name: "IX_StrAddDetails_AddId",
                table: "StrAddDetails",
                column: "AddId");

            migrationBuilder.CreateIndex(
                name: "IX_StrAddDetails_CreatedByID",
                table: "StrAddDetails",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrAddDetails_ItemId",
                table: "StrAddDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StrAddDetails_UpdateByID",
                table: "StrAddDetails",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrAddDetailsSerial_AddDetailsId",
                table: "StrAddDetailsSerial",
                column: "AddDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_StrAddDetailsSerial_CreatedByID",
                table: "StrAddDetailsSerial",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrAddDetailsSerial_ProductId",
                table: "StrAddDetailsSerial",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StrAddDetailsSerial_ProductSerialId",
                table: "StrAddDetailsSerial",
                column: "ProductSerialId");

            migrationBuilder.CreateIndex(
                name: "IX_StrAddDetailsSerial_UpdateByID",
                table: "StrAddDetailsSerial",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrAddType_AccountId",
                table: "StrAddType",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_StrAddType_CreatedByID",
                table: "StrAddType",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrAddType_UpdateByID",
                table: "StrAddType",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrApprovalStatus_CreatedByID",
                table: "StrApprovalStatus",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrApprovalStatus_UpdateByID",
                table: "StrApprovalStatus",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrCommodity_AccountId",
                table: "StrCommodity",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_StrCommodity_CreatedByID",
                table: "StrCommodity",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrCommodity_UpdateByID",
                table: "StrCommodity",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeExchange_CostCenterId",
                table: "StrEmployeeExchange",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeExchange_CreatedByID",
                table: "StrEmployeeExchange",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeExchange_DestEmployeeId",
                table: "StrEmployeeExchange",
                column: "DestEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeExchange_EmployeeId",
                table: "StrEmployeeExchange",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeExchange_FiscalYearId",
                table: "StrEmployeeExchange",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeExchange_UpdateByID",
                table: "StrEmployeeExchange",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeExchangeDetails_CreatedByID",
                table: "StrEmployeeExchangeDetails",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeExchangeDetails_Employee_ExchangeId",
                table: "StrEmployeeExchangeDetails",
                column: "Employee_ExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeExchangeDetails_ItemId",
                table: "StrEmployeeExchangeDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeExchangeDetails_UpdateByID",
                table: "StrEmployeeExchangeDetails",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeExchangeSerial_CreatedByID",
                table: "StrEmployeeExchangeSerial",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeExchangeSerial_EmployeeExchangeDetailId",
                table: "StrEmployeeExchangeSerial",
                column: "EmployeeExchangeDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeExchangeSerial_ProductId",
                table: "StrEmployeeExchangeSerial",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeExchangeSerial_ProductSerialId",
                table: "StrEmployeeExchangeSerial",
                column: "ProductSerialId");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeExchangeSerial_UpdateByID",
                table: "StrEmployeeExchangeSerial",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeOpeningCustody_CostCenterId",
                table: "StrEmployeeOpeningCustody",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeOpeningCustody_CreatedByID",
                table: "StrEmployeeOpeningCustody",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeOpeningCustody_EmployeeId",
                table: "StrEmployeeOpeningCustody",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeOpeningCustody_FiscalYearId",
                table: "StrEmployeeOpeningCustody",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeOpeningCustody_UpdateByID",
                table: "StrEmployeeOpeningCustody",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeOpeningCustodyDetails_CreatedByID",
                table: "StrEmployeeOpeningCustodyDetails",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeOpeningCustodyDetails_CustodyId",
                table: "StrEmployeeOpeningCustodyDetails",
                column: "CustodyId");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeOpeningCustodyDetails_ItemId",
                table: "StrEmployeeOpeningCustodyDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeOpeningCustodyDetails_UpdateByID",
                table: "StrEmployeeOpeningCustodyDetails",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeOpeningCustodySerial_CreatedByID",
                table: "StrEmployeeOpeningCustodySerial",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeOpeningCustodySerial_EmployeeOpeningCustodyDetailId",
                table: "StrEmployeeOpeningCustodySerial",
                column: "EmployeeOpeningCustodyDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeOpeningCustodySerial_ProductId",
                table: "StrEmployeeOpeningCustodySerial",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeOpeningCustodySerial_ProductSerialId",
                table: "StrEmployeeOpeningCustodySerial",
                column: "ProductSerialId");

            migrationBuilder.CreateIndex(
                name: "IX_StrEmployeeOpeningCustodySerial_UpdateByID",
                table: "StrEmployeeOpeningCustodySerial",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrGrade_AccountId",
                table: "StrGrade",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_StrGrade_CommodityId",
                table: "StrGrade",
                column: "CommodityId");

            migrationBuilder.CreateIndex(
                name: "IX_StrGrade_CreatedByID",
                table: "StrGrade",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrGrade_StrEmployeeExchangeId",
                table: "StrGrade",
                column: "StrEmployeeExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_StrGrade_UpdateByID",
                table: "StrGrade",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrGroup_CreatedByID",
                table: "StrGroup",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrGroup_PlatoonId",
                table: "StrGroup",
                column: "PlatoonId");

            migrationBuilder.CreateIndex(
                name: "IX_StrGroup_UpdateByID",
                table: "StrGroup",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrItem_CommodityId",
                table: "StrItem",
                column: "CommodityId");

            migrationBuilder.CreateIndex(
                name: "IX_StrItem_CreatedByID",
                table: "StrItem",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrItem_FullCode",
                table: "StrItem",
                column: "FullCode",
                unique: true,
                filter: "[FullCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StrItem_GradeId",
                table: "StrItem",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_StrItem_GroupId",
                table: "StrItem",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StrItem_PlatoonId",
                table: "StrItem",
                column: "PlatoonId");

            migrationBuilder.CreateIndex(
                name: "IX_StrItem_UnitId",
                table: "StrItem",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_StrItem_UpdateByID",
                table: "StrItem",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrModel_CreatedByID",
                table: "StrModel",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrModel_UpdateByID",
                table: "StrModel",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrModel_VendorId",
                table: "StrModel",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_StrOpeningStock_CreatedByID",
                table: "StrOpeningStock",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrOpeningStock_FiscalYearId",
                table: "StrOpeningStock",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StrOpeningStock_SectionId",
                table: "StrOpeningStock",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_StrOpeningStock_StoreId",
                table: "StrOpeningStock",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StrOpeningStock_UpdateByID",
                table: "StrOpeningStock",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrOpeningStockDetails_CreatedByID",
                table: "StrOpeningStockDetails",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrOpeningStockDetails_ItemId",
                table: "StrOpeningStockDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StrOpeningStockDetails_STR_Opening_StockId",
                table: "StrOpeningStockDetails",
                column: "STR_Opening_StockId");

            migrationBuilder.CreateIndex(
                name: "IX_StrOpeningStockDetails_UpdateByID",
                table: "StrOpeningStockDetails",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrOpeningStockDetailsSerial_CreatedByID",
                table: "StrOpeningStockDetailsSerial",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrOpeningStockDetailsSerial_OpeningStockDetailId",
                table: "StrOpeningStockDetailsSerial",
                column: "OpeningStockDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_StrOpeningStockDetailsSerial_ProductId",
                table: "StrOpeningStockDetailsSerial",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StrOpeningStockDetailsSerial_ProductSerialId",
                table: "StrOpeningStockDetailsSerial",
                column: "ProductSerialId");

            migrationBuilder.CreateIndex(
                name: "IX_StrOpeningStockDetailsSerial_UpdateByID",
                table: "StrOpeningStockDetailsSerial",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrPlatoon_CreatedByID",
                table: "StrPlatoon",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrPlatoon_GradeId",
                table: "StrPlatoon",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_StrPlatoon_UpdateByID",
                table: "StrPlatoon",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrProduct_CreatedByID",
                table: "StrProduct",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrProduct_ItemId",
                table: "StrProduct",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StrProduct_ModelId",
                table: "StrProduct",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StrProduct_UpdateByID",
                table: "StrProduct",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrProduct_VendorId",
                table: "StrProduct",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_StrProductSerial_CreatedByID",
                table: "StrProductSerial",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrProductSerial_ProductId",
                table: "StrProductSerial",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StrProductSerial_UpdateByID",
                table: "StrProductSerial",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrStockTaking_CreatedByID",
                table: "StrStockTaking",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrStockTaking_FiscalYearId",
                table: "StrStockTaking",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StrStockTaking_StoreId",
                table: "StrStockTaking",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StrStockTaking_UpdateByID",
                table: "StrStockTaking",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrStockTakingDetails_CreatedByID",
                table: "StrStockTakingDetails",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrStockTakingDetails_ItemId",
                table: "StrStockTakingDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StrStockTakingDetails_STRStockTakingId",
                table: "StrStockTakingDetails",
                column: "STRStockTakingId");

            migrationBuilder.CreateIndex(
                name: "IX_StrStockTakingDetails_UpdateByID",
                table: "StrStockTakingDetails",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrStore_CreatedByID",
                table: "StrStore",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrStore_SectionId",
                table: "StrStore",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_StrStore_StorekeeperId",
                table: "StrStore",
                column: "StorekeeperId");

            migrationBuilder.CreateIndex(
                name: "IX_StrStore_UpdateByID",
                table: "StrStore",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrUnit_CreatedByID",
                table: "StrUnit",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrUnit_UpdateByID",
                table: "StrUnit",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrUserStore_CreatedByID",
                table: "StrUserStore",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrUserStore_StoreId",
                table: "StrUserStore",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StrUserStore_UpdateByID",
                table: "StrUserStore",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrUserStore_UserId",
                table: "StrUserStore",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StrVendor_CreatedByID",
                table: "StrVendor",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrVendor_UpdateByID",
                table: "StrVendor",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDraw_ApprovalStatusId",
                table: "StrWithDraw",
                column: "ApprovalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDraw_CostCenterId",
                table: "StrWithDraw",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDraw_CreatedByID",
                table: "StrWithDraw",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDraw_DestStoreId",
                table: "StrWithDraw",
                column: "DestStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDraw_DestStoreUserId",
                table: "StrWithDraw",
                column: "DestStoreUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDraw_EmployeeId",
                table: "StrWithDraw",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDraw_FiscalYearId",
                table: "StrWithDraw",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDraw_StoreId",
                table: "StrWithDraw",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDraw_STR_CommodityId",
                table: "StrWithDraw",
                column: "STR_CommodityId");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDraw_UpdateByID",
                table: "StrWithDraw",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDraw_WithDrawTypeId",
                table: "StrWithDraw",
                column: "WithDrawTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDrawDetails_CreatedByID",
                table: "StrWithDrawDetails",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDrawDetails_ItemId",
                table: "StrWithDrawDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDrawDetails_STR_WithdrawId",
                table: "StrWithDrawDetails",
                column: "STR_WithdrawId");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDrawDetails_UpdateByID",
                table: "StrWithDrawDetails",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDrawDetailsSerial_CreatedByID",
                table: "StrWithDrawDetailsSerial",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDrawDetailsSerial_ProductId",
                table: "StrWithDrawDetailsSerial",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDrawDetailsSerial_ProductSerialId",
                table: "StrWithDrawDetailsSerial",
                column: "ProductSerialId");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDrawDetailsSerial_StrWithDrawDetailsId",
                table: "StrWithDrawDetailsSerial",
                column: "StrWithDrawDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDrawDetailsSerial_UpdateByID",
                table: "StrWithDrawDetailsSerial",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDrawType_AccountId",
                table: "StrWithDrawType",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDrawType_CreatedByID",
                table: "StrWithDrawType",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StrWithDrawType_UpdateByID",
                table: "StrWithDrawType",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrBudget_CourseId",
                table: "TrBudget",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrBudget_CreatedByID",
                table: "TrBudget",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrBudget_UpdateByID",
                table: "TrBudget",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrClassRoom_CityStateId",
                table: "TrClassRoom",
                column: "CityStateId");

            migrationBuilder.CreateIndex(
                name: "IX_TrClassRoom_CreatedByID",
                table: "TrClassRoom",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrClassRoom_TrainingCenterId",
                table: "TrClassRoom",
                column: "TrainingCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_TrClassRoom_UpdateByID",
                table: "TrClassRoom",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrCorporateCLient_CityId",
                table: "TrCorporateCLient",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TrCorporateCLient_CreatedByID",
                table: "TrCorporateCLient",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrCorporateCLient_UpdateByID",
                table: "TrCorporateCLient",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrCourse_CategoryId",
                table: "TrCourse",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TrCourse_CourseTypeId",
                table: "TrCourse",
                column: "CourseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrCourse_CreatedByID",
                table: "TrCourse",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrCourse_UpdateByID",
                table: "TrCourse",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrCourseCategory_CreatedByID",
                table: "TrCourseCategory",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrCourseCategory_UpdateByID",
                table: "TrCourseCategory",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrCourseType_CreatedByID",
                table: "TrCourseType",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrCourseType_UpdateByID",
                table: "TrCourseType",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcuted_ClassRoomId",
                table: "TrExcuted",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcuted_CourseId",
                table: "TrExcuted",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcuted_CreatedByID",
                table: "TrExcuted",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcuted_DelegateId",
                table: "TrExcuted",
                column: "DelegateId");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcuted_FiscalYearId",
                table: "TrExcuted",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcuted_MaterialPurposeId",
                table: "TrExcuted",
                column: "MaterialPurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcuted_PurposeId",
                table: "TrExcuted",
                column: "PurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcuted_TrainingCenterId",
                table: "TrExcuted",
                column: "TrainingCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcuted_UpdateByID",
                table: "TrExcuted",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcutedFinancier_CreatedByID",
                table: "TrExcutedFinancier",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcutedFinancier_ExcutedId",
                table: "TrExcutedFinancier",
                column: "ExcutedId");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcutedFinancier_FinancierId",
                table: "TrExcutedFinancier",
                column: "FinancierId");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcutedFinancier_UpdateByID",
                table: "TrExcutedFinancier",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcutedInstructor_CreatedByID",
                table: "TrExcutedInstructor",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcutedInstructor_ExcutedId",
                table: "TrExcutedInstructor",
                column: "ExcutedId");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcutedInstructor_InstructorId",
                table: "TrExcutedInstructor",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcutedInstructor_UpdateByID",
                table: "TrExcutedInstructor",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcutedPosition_CreatedByID",
                table: "TrExcutedPosition",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcutedPosition_ExcutedId",
                table: "TrExcutedPosition",
                column: "ExcutedId");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcutedPosition_PositionId",
                table: "TrExcutedPosition",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcutedPosition_UpdateByID",
                table: "TrExcutedPosition",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcutedTrainee_CreatedByID",
                table: "TrExcutedTrainee",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcutedTrainee_EmployeeId",
                table: "TrExcutedTrainee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcutedTrainee_ExcutedId",
                table: "TrExcutedTrainee",
                column: "ExcutedId");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcutedTrainee_TraineeId",
                table: "TrExcutedTrainee",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrExcutedTrainee_UpdateByID",
                table: "TrExcutedTrainee",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrFinancier_CreatedByID",
                table: "TrFinancier",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrFinancier_UpdateByID",
                table: "TrFinancier",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrInstructor_CreatedByID",
                table: "TrInstructor",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrInstructor_EmployeeId",
                table: "TrInstructor",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInstructor_InstructorDataId",
                table: "TrInstructor",
                column: "InstructorDataId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInstructor_TrainingCenterId",
                table: "TrInstructor",
                column: "TrainingCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInstructor_UpdateByID",
                table: "TrInstructor",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrInstructorCourse_CourseId",
                table: "TrInstructorCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInstructorCourse_CreatedByID",
                table: "TrInstructorCourse",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrInstructorCourse_InstructorId",
                table: "TrInstructorCourse",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInstructorCourse_UpdateByID",
                table: "TrInstructorCourse",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrInstructorData_CityId",
                table: "TrInstructorData",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInstructorData_CreatedByID",
                table: "TrInstructorData",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrInstructorData_UpdateByID",
                table: "TrInstructorData",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlan_ClassRoomId",
                table: "TrPlan",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlan_CourseId",
                table: "TrPlan",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlan_CreatedByID",
                table: "TrPlan",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlan_FinanacielDegreeId",
                table: "TrPlan",
                column: "FinanacielDegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlan_FiscalYearId",
                table: "TrPlan",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlan_PurposeId",
                table: "TrPlan",
                column: "PurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlan_TrainingCenterId",
                table: "TrPlan",
                column: "TrainingCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlan_UpdateByID",
                table: "TrPlan",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlanCourseData_CreatedByID",
                table: "TrPlanCourseData",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlanCourseData_Hr_FinancialDegreeId",
                table: "TrPlanCourseData",
                column: "Hr_FinancialDegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlanCourseData_Hr_PositionId",
                table: "TrPlanCourseData",
                column: "Hr_PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlanCourseData_TR_CourseId",
                table: "TrPlanCourseData",
                column: "TR_CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlanCourseData_UpdateByID",
                table: "TrPlanCourseData",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlanFinancier_CreatedByID",
                table: "TrPlanFinancier",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlanFinancier_FinancierId",
                table: "TrPlanFinancier",
                column: "FinancierId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlanFinancier_PlanId",
                table: "TrPlanFinancier",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlanFinancier_UpdateByID",
                table: "TrPlanFinancier",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlanInstructor_CreatedByID",
                table: "TrPlanInstructor",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlanInstructor_InstructorId",
                table: "TrPlanInstructor",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlanInstructor_PlanId",
                table: "TrPlanInstructor",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlanInstructor_UpdateByID",
                table: "TrPlanInstructor",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlanPosition_CreatedByID",
                table: "TrPlanPosition",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlanPosition_PlanId",
                table: "TrPlanPosition",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlanPosition_PositionId",
                table: "TrPlanPosition",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPlanPosition_UpdateByID",
                table: "TrPlanPosition",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrPurpose_CreatedByID",
                table: "TrPurpose",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrPurpose_UpdateByID",
                table: "TrPurpose",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrTrack_CreatedByID",
                table: "TrTrack",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrTrack_UpdateByID",
                table: "TrTrack",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrTrackDetails_CourseId",
                table: "TrTrackDetails",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrTrackDetails_CreatedByID",
                table: "TrTrackDetails",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrTrackDetails_TrackId",
                table: "TrTrackDetails",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_TrTrackDetails_UpdateByID",
                table: "TrTrackDetails",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrTrainee_CityId",
                table: "TrTrainee",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TrTrainee_CityStateId",
                table: "TrTrainee",
                column: "CityStateId");

            migrationBuilder.CreateIndex(
                name: "IX_TrTrainee_CorporationCLientId",
                table: "TrTrainee",
                column: "CorporationCLientId");

            migrationBuilder.CreateIndex(
                name: "IX_TrTrainee_CreatedByID",
                table: "TrTrainee",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrTrainee_UpdateByID",
                table: "TrTrainee",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrTrainingCenter_CityId",
                table: "TrTrainingCenter",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TrTrainingCenter_CreatedByID",
                table: "TrTrainingCenter",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrTrainingCenter_UpdateByID",
                table: "TrTrainingCenter",
                column: "UpdateByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrTrainingCenterCourse_CourseId",
                table: "TrTrainingCenterCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrTrainingCenterCourse_CreatedByID",
                table: "TrTrainingCenterCourse",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TrTrainingCenterCourse_TrainingCenterId",
                table: "TrTrainingCenterCourse",
                column: "TrainingCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_TrTrainingCenterCourse_UpdateByID",
                table: "TrTrainingCenterCourse",
                column: "UpdateByID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CcEntryDetails");

            migrationBuilder.DropTable(
                name: "EmployeeFinancialDegree");

            migrationBuilder.DropTable(
                name: "FaMoveFixedAsset");

            migrationBuilder.DropTable(
                name: "FiAccountParent");

            migrationBuilder.DropTable(
                name: "FiEntryDetails");

            migrationBuilder.DropTable(
                name: "HrAttendanceMachineWorkPlace");

            migrationBuilder.DropTable(
                name: "HrEmployeeAppraisal");

            migrationBuilder.DropTable(
                name: "HrEmployeeAttendance");

            migrationBuilder.DropTable(
                name: "HrEmployeeAttendancePermission");

            migrationBuilder.DropTable(
                name: "HrEmployeeAttendanceSchedule");

            migrationBuilder.DropTable(
                name: "HrEmployeeDisciplinary");

            migrationBuilder.DropTable(
                name: "HrEmployeePosition");

            migrationBuilder.DropTable(
                name: "HrEmployeeQualification");

            migrationBuilder.DropTable(
                name: "HrEmployeeVacation");

            migrationBuilder.DropTable(
                name: "HrEmployeeVacationBalance");

            migrationBuilder.DropTable(
                name: "HrFinancialDegreeSalary");

            migrationBuilder.DropTable(
                name: "HrHolidaySchedule");

            migrationBuilder.DropTable(
                name: "HrIncentiveAllowance");

            migrationBuilder.DropTable(
                name: "PrGroupPrivileges");

            migrationBuilder.DropTable(
                name: "PrGroupRole");

            migrationBuilder.DropTable(
                name: "ProContractorTypes");

            migrationBuilder.DropTable(
                name: "ProSellerTypes");

            migrationBuilder.DropTable(
                name: "ProTender");

            migrationBuilder.DropTable(
                name: "PrUserGroup");

            migrationBuilder.DropTable(
                name: "PrUserModule");

            migrationBuilder.DropTable(
                name: "PyExchangeDetails");

            migrationBuilder.DropTable(
                name: "PyInstallment");

            migrationBuilder.DropTable(
                name: "PyItemGroupDetails");

            migrationBuilder.DropTable(
                name: "PyItemGroupEmployee");

            migrationBuilder.DropTable(
                name: "PyTaxBracket");

            migrationBuilder.DropTable(
                name: "StrAddDetailsSerial");

            migrationBuilder.DropTable(
                name: "StrEmployeeExchangeSerial");

            migrationBuilder.DropTable(
                name: "StrEmployeeOpeningCustodySerial");

            migrationBuilder.DropTable(
                name: "StrOpeningStockDetailsSerial");

            migrationBuilder.DropTable(
                name: "StrStockTakingDetails");

            migrationBuilder.DropTable(
                name: "StrUserStore");

            migrationBuilder.DropTable(
                name: "StrWithDrawDetailsSerial");

            migrationBuilder.DropTable(
                name: "TrBudget");

            migrationBuilder.DropTable(
                name: "TrExcutedFinancier");

            migrationBuilder.DropTable(
                name: "TrExcutedInstructor");

            migrationBuilder.DropTable(
                name: "TrExcutedPosition");

            migrationBuilder.DropTable(
                name: "TrExcutedTrainee");

            migrationBuilder.DropTable(
                name: "TrInstructorCourse");

            migrationBuilder.DropTable(
                name: "TrPlanCourseData");

            migrationBuilder.DropTable(
                name: "TrPlanFinancier");

            migrationBuilder.DropTable(
                name: "TrPlanInstructor");

            migrationBuilder.DropTable(
                name: "TrPlanPosition");

            migrationBuilder.DropTable(
                name: "TrTrackDetails");

            migrationBuilder.DropTable(
                name: "TrTrainingCenterCourse");

            migrationBuilder.DropTable(
                name: "CcEntry");

            migrationBuilder.DropTable(
                name: "CcEquipment");

            migrationBuilder.DropTable(
                name: "FaFixedAsset");

            migrationBuilder.DropTable(
                name: "FiAccountItem");

            migrationBuilder.DropTable(
                name: "HrAttendanceMachine");

            migrationBuilder.DropTable(
                name: "HrAttendancePermission");

            migrationBuilder.DropTable(
                name: "HrAttendanceSchedule");

            migrationBuilder.DropTable(
                name: "HrDisciplinary");

            migrationBuilder.DropTable(
                name: "HrVacation");

            migrationBuilder.DropTable(
                name: "HrHoliday");

            migrationBuilder.DropTable(
                name: "PrPrivileges");

            migrationBuilder.DropTable(
                name: "PrRole");

            migrationBuilder.DropTable(
                name: "ProContractor");

            migrationBuilder.DropTable(
                name: "ProContractorType");

            migrationBuilder.DropTable(
                name: "ProSellerType");

            migrationBuilder.DropTable(
                name: "ProOperationType");

            migrationBuilder.DropTable(
                name: "ProPlantType");

            migrationBuilder.DropTable(
                name: "ProTenderType");

            migrationBuilder.DropTable(
                name: "PrGroup");

            migrationBuilder.DropTable(
                name: "PyExchange");

            migrationBuilder.DropTable(
                name: "PyItem");

            migrationBuilder.DropTable(
                name: "PyItemGroup");

            migrationBuilder.DropTable(
                name: "StrAddDetails");

            migrationBuilder.DropTable(
                name: "StrEmployeeExchangeDetails");

            migrationBuilder.DropTable(
                name: "StrEmployeeOpeningCustodyDetails");

            migrationBuilder.DropTable(
                name: "StrOpeningStockDetails");

            migrationBuilder.DropTable(
                name: "StrStockTaking");

            migrationBuilder.DropTable(
                name: "StrProductSerial");

            migrationBuilder.DropTable(
                name: "StrWithDrawDetails");

            migrationBuilder.DropTable(
                name: "TrExcuted");

            migrationBuilder.DropTable(
                name: "TrTrainee");

            migrationBuilder.DropTable(
                name: "TrFinancier");

            migrationBuilder.DropTable(
                name: "TrInstructor");

            migrationBuilder.DropTable(
                name: "TrPlan");

            migrationBuilder.DropTable(
                name: "TrTrack");

            migrationBuilder.DropTable(
                name: "FaCategoryFirst");

            migrationBuilder.DropTable(
                name: "FaCategorySecond");

            migrationBuilder.DropTable(
                name: "FaCategoryThird");

            migrationBuilder.DropTable(
                name: "FiEntry");

            migrationBuilder.DropTable(
                name: "FiAccountItemCategory");

            migrationBuilder.DropTable(
                name: "PrModule");

            migrationBuilder.DropTable(
                name: "PyItemCategory");

            migrationBuilder.DropTable(
                name: "StrAdd");

            migrationBuilder.DropTable(
                name: "StrEmployeeOpeningCustody");

            migrationBuilder.DropTable(
                name: "StrOpeningStock");

            migrationBuilder.DropTable(
                name: "StrProduct");

            migrationBuilder.DropTable(
                name: "TrCorporateCLient");

            migrationBuilder.DropTable(
                name: "TrInstructorData");

            migrationBuilder.DropTable(
                name: "TrClassRoom");

            migrationBuilder.DropTable(
                name: "TrCourse");

            migrationBuilder.DropTable(
                name: "TrPurpose");

            migrationBuilder.DropTable(
                name: "FiEntrySourceType");

            migrationBuilder.DropTable(
                name: "FiJournal");

            migrationBuilder.DropTable(
                name: "ProSeller");

            migrationBuilder.DropTable(
                name: "StrAddType");

            migrationBuilder.DropTable(
                name: "StrWithDraw");

            migrationBuilder.DropTable(
                name: "StrItem");

            migrationBuilder.DropTable(
                name: "StrModel");

            migrationBuilder.DropTable(
                name: "TrTrainingCenter");

            migrationBuilder.DropTable(
                name: "TrCourseCategory");

            migrationBuilder.DropTable(
                name: "TrCourseType");

            migrationBuilder.DropTable(
                name: "FiEntrySource");

            migrationBuilder.DropTable(
                name: "StrApprovalStatus");

            migrationBuilder.DropTable(
                name: "StrStore");

            migrationBuilder.DropTable(
                name: "StrWithDrawType");

            migrationBuilder.DropTable(
                name: "StrGroup");

            migrationBuilder.DropTable(
                name: "StrUnit");

            migrationBuilder.DropTable(
                name: "StrVendor");

            migrationBuilder.DropTable(
                name: "StrPlatoon");

            migrationBuilder.DropTable(
                name: "StrGrade");

            migrationBuilder.DropTable(
                name: "StrCommodity");

            migrationBuilder.DropTable(
                name: "StrEmployeeExchange");

            migrationBuilder.DropTable(
                name: "FiAccount");

            migrationBuilder.DropTable(
                name: "FiscalYear");

            migrationBuilder.DropTable(
                name: "HrEmployee");

            migrationBuilder.DropTable(
                name: "FiAccountHierarchy");

            migrationBuilder.DropTable(
                name: "CcCostCenter");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "HrFinancialDegree");

            migrationBuilder.DropTable(
                name: "HrHiringType");

            migrationBuilder.DropTable(
                name: "HrJobTitle");

            migrationBuilder.DropTable(
                name: "HrMillitryState");

            migrationBuilder.DropTable(
                name: "HrPosition");

            migrationBuilder.DropTable(
                name: "HrQualificationLevel");

            migrationBuilder.DropTable(
                name: "HrSeveranceReason");

            migrationBuilder.DropTable(
                name: "HrSpecialization");

            migrationBuilder.DropTable(
                name: "HrWorkPlace");

            migrationBuilder.DropTable(
                name: "CcActivity");

            migrationBuilder.DropTable(
                name: "CcPlant");

            migrationBuilder.DropTable(
                name: "CcPlantComponent");

            migrationBuilder.DropTable(
                name: "CcSource");

            migrationBuilder.DropTable(
                name: "ImsSection");

            migrationBuilder.DropTable(
                name: "GeneralDepartment");

            migrationBuilder.DropTable(
                name: "HrQualification");

            migrationBuilder.DropTable(
                name: "HrCityState");

            migrationBuilder.DropTable(
                name: "CcSubRegion");

            migrationBuilder.DropTable(
                name: "CcFunction");

            migrationBuilder.DropTable(
                name: "HrQualitativeGroup");

            migrationBuilder.DropTable(
                name: "HrCity");

            migrationBuilder.DropTable(
                name: "CcRegion");

            migrationBuilder.DropTable(
                name: "PrUser");
        }
    }
}
