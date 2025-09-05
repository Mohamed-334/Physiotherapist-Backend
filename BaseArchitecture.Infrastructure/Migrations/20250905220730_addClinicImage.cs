using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhysiotherapistProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addClinicImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClinicImage",
                table: "Clinics",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClinicImage",
                table: "Clinics");
        }
    }
}
