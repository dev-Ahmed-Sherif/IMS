using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InsuranceNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "TrCourseType",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InsuranceNumber",
                table: "HrEmployee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TrCourseType_SectionId",
                table: "TrCourseType",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrCourseType_ImsSection_SectionId",
                table: "TrCourseType",
                column: "SectionId",
                principalTable: "ImsSection",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrCourseType_ImsSection_SectionId",
                table: "TrCourseType");

            migrationBuilder.DropIndex(
                name: "IX_TrCourseType_SectionId",
                table: "TrCourseType");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "TrCourseType");

            migrationBuilder.DropColumn(
                name: "InsuranceNumber",
                table: "HrEmployee");
        }
    }
}
