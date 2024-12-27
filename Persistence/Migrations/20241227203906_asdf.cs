using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class asdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Thiamin",
                table: "Vitamins",
                newName: "VitaminD3");

            migrationBuilder.RenameColumn(
                name: "Riboflavin",
                table: "Vitamins",
                newName: "VitaminD");

            migrationBuilder.RenameColumn(
                name: "PantothenicAcid",
                table: "Vitamins",
                newName: "VitaminB9");

            migrationBuilder.RenameColumn(
                name: "Niacin",
                table: "Vitamins",
                newName: "VitaminB7");

            migrationBuilder.RenameColumn(
                name: "Lycopene",
                table: "Vitamins",
                newName: "VitaminB5");

            migrationBuilder.RenameColumn(
                name: "LuteinZeaxanthin",
                table: "Vitamins",
                newName: "VitaminB3");

            migrationBuilder.RenameColumn(
                name: "Folate",
                table: "Vitamins",
                newName: "VitaminB2");

            migrationBuilder.RenameColumn(
                name: "Choline",
                table: "Vitamins",
                newName: "VitaminB12");

            migrationBuilder.RenameColumn(
                name: "Betaine",
                table: "Vitamins",
                newName: "VitaminB1");

            migrationBuilder.AddColumn<float>(
                name: "VitaminA1",
                table: "Vitamins",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "VitaminA2",
                table: "Vitamins",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VitaminA1",
                table: "Vitamins");

            migrationBuilder.DropColumn(
                name: "VitaminA2",
                table: "Vitamins");

            migrationBuilder.RenameColumn(
                name: "VitaminD3",
                table: "Vitamins",
                newName: "Thiamin");

            migrationBuilder.RenameColumn(
                name: "VitaminD",
                table: "Vitamins",
                newName: "Riboflavin");

            migrationBuilder.RenameColumn(
                name: "VitaminB9",
                table: "Vitamins",
                newName: "PantothenicAcid");

            migrationBuilder.RenameColumn(
                name: "VitaminB7",
                table: "Vitamins",
                newName: "Niacin");

            migrationBuilder.RenameColumn(
                name: "VitaminB5",
                table: "Vitamins",
                newName: "Lycopene");

            migrationBuilder.RenameColumn(
                name: "VitaminB3",
                table: "Vitamins",
                newName: "LuteinZeaxanthin");

            migrationBuilder.RenameColumn(
                name: "VitaminB2",
                table: "Vitamins",
                newName: "Folate");

            migrationBuilder.RenameColumn(
                name: "VitaminB12",
                table: "Vitamins",
                newName: "Choline");

            migrationBuilder.RenameColumn(
                name: "VitaminB1",
                table: "Vitamins",
                newName: "Betaine");
        }
    }
}
