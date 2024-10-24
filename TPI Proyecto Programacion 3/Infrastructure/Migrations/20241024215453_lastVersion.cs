using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class lastVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppartmentId",
                table: "Appartments");

            migrationBuilder.AddColumn<int>(
                name: "AppartmentId",
                table: "Users",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppartmentId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "AppartmentId",
                table: "Appartments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
