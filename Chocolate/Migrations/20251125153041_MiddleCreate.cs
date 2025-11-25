using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chocolate.Migrations
{
    /// <inheritdoc />
    public partial class MiddleCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Categories",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Categories",
                table: "Products",
                column: "Categories");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_Categories",
                table: "Products",
                column: "Categories",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_Categories",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Categories",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Categories",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
