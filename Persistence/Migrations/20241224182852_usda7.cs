using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class usda7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InputFoods_Foods_FoodId",
                table: "InputFoods");

            migrationBuilder.AlterColumn<int>(
                name: "FoodId",
                table: "InputFoods",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Foods",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_InputFoods_Foods_FoodId",
                table: "InputFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InputFoods_Foods_FoodId",
                table: "InputFoods");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Foods");

            migrationBuilder.AlterColumn<int>(
                name: "FoodId",
                table: "InputFoods",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InputFoods_Foods_FoodId",
                table: "InputFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
