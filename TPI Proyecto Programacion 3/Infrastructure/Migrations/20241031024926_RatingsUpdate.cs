using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RatingsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_OwnerId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_OwnerId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Ratings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Ratings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_OwnerId",
                table: "Ratings",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_OwnerId",
                table: "Ratings",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
