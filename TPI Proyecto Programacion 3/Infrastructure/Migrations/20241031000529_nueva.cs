using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class nueva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appartments_Users_TenantId",
                table: "Appartments");

            migrationBuilder.DropIndex(
                name: "IX_Appartments_TenantId",
                table: "Appartments");

            migrationBuilder.AlterColumn<string>(
                name: "Ubication",
                table: "Buildings",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Buildings",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AppartmentId",
                table: "Users",
                column: "AppartmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Appartments_AppartmentId",
                table: "Users",
                column: "AppartmentId",
                principalTable: "Appartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Appartments_AppartmentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AppartmentId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Ubication",
                table: "Buildings",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Buildings",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.CreateIndex(
                name: "IX_Appartments_TenantId",
                table: "Appartments",
                column: "TenantId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appartments_Users_TenantId",
                table: "Appartments",
                column: "TenantId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
