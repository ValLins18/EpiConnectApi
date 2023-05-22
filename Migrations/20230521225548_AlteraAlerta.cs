using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EpiConnectAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlteraAlerta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOpen",
                table: "Alert",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "UnprotectedTime",
                table: "Alert",
                type: "time",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOpen",
                table: "Alert");

            migrationBuilder.DropColumn(
                name: "UnprotectedTime",
                table: "Alert");
        }
    }
}
