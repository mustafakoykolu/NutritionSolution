using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class asdf3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carbohydrates_Sugars_SugarId",
                table: "Carbohydrates");

            migrationBuilder.DropIndex(
                name: "IX_Carbohydrates_SugarId",
                table: "Carbohydrates");

            migrationBuilder.DropColumn(
                name: "SugarId",
                table: "Carbohydrates");

            migrationBuilder.AddColumn<int>(
                name: "CarbohydrateId",
                table: "Sugars",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sugars_CarbohydrateId",
                table: "Sugars",
                column: "CarbohydrateId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sugars_Carbohydrates_CarbohydrateId",
                table: "Sugars",
                column: "CarbohydrateId",
                principalTable: "Carbohydrates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sugars_Carbohydrates_CarbohydrateId",
                table: "Sugars");

            migrationBuilder.DropIndex(
                name: "IX_Sugars_CarbohydrateId",
                table: "Sugars");

            migrationBuilder.DropColumn(
                name: "CarbohydrateId",
                table: "Sugars");

            migrationBuilder.AddColumn<int>(
                name: "SugarId",
                table: "Carbohydrates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carbohydrates_SugarId",
                table: "Carbohydrates",
                column: "SugarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carbohydrates_Sugars_SugarId",
                table: "Carbohydrates",
                column: "SugarId",
                principalTable: "Sugars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
