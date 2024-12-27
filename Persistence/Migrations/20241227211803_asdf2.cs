
using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class asdf2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cholesterol",
                table: "Foods");

            migrationBuilder.AddColumn<float>(
                name: "Cholesterol",
                table: "Lipids",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cholesterol",
                table: "Lipids");

            migrationBuilder.AddColumn<float>(
                name: "Cholesterol",
                table: "Foods",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
