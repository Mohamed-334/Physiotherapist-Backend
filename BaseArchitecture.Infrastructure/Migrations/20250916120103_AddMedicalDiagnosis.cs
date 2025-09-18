using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhysiotherapistProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMedicalDiagnosis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MedicalDiagnosis",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicalDiagnosis",
                table: "Sessions");
        }
    }
}
