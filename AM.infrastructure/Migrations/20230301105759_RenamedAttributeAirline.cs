using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenamedAttributeAirline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Airline",
                table: "Flights",
                newName: "Airlinelogo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Airlinelogo",
                table: "Flights",
                newName: "Airline");
        }
    }
}
