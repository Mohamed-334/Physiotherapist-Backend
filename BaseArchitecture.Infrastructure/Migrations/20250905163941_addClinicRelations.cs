using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhysiotherapistProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addClinicRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ClinicId",
                table: "Courses",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Clinics_ClinicId",
                table: "Courses",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Clinics_ClinicId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_ClinicId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Courses");
        }
    }
}
