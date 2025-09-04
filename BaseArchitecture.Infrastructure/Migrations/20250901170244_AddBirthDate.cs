using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhysiotherapistProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBirthDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_AspNetUsers_ClinicMangerId",
                table: "Clinics");

            migrationBuilder.AddColumn<int>(
                name: "SessionTime",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ClinicMangerId",
                table: "Clinics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_AspNetUsers_ClinicMangerId",
                table: "Clinics",
                column: "ClinicMangerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_AspNetUsers_ClinicMangerId",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "SessionTime",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ClinicMangerId",
                table: "Clinics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_AspNetUsers_ClinicMangerId",
                table: "Clinics",
                column: "ClinicMangerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
