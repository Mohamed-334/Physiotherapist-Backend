using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNationalIdNameForUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NationalId",
                table: "AspNetUsers",
                newName: "NationalNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NationalNumber",
                table: "AspNetUsers",
                newName: "NationalId");
        }
    }
}
