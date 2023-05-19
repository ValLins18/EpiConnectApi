using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EpiConnectAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameProtectionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProtectionTypeId",
                schema: "dbo",
                table: "Epi",
                newName: "ProtectionType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProtectionType",
                schema: "dbo",
                table: "Epi",
                newName: "ProtectionTypeId");
        }
    }
}
