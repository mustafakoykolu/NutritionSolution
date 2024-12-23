using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class usda2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodCategory",
                table: "Foods");

            migrationBuilder.AddColumn<int>(
                name: "FoodCategoryId",
                table: "Foods",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FoodCategoryId",
                table: "Foods",
                column: "FoodCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodCategories_FoodCategoryId",
                table: "Foods",
                column: "FoodCategoryId",
                principalTable: "FoodCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_FoodCategories_FoodCategoryId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_FoodCategoryId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodCategoryId",
                table: "Foods");

            migrationBuilder.AddColumn<string>(
                name: "FoodCategory",
                table: "Foods",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
