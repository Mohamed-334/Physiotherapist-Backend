using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDeletionDateAndName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeleterName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleterName",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleterName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeleterName",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "AspNetRoles");
        }
    }
}
