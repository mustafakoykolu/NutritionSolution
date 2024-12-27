using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class lastt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NameTr = table.Column<string>(type: "text", nullable: false),
                    KCal = table.Column<float>(type: "real", nullable: false),
                    Protein = table.Column<float>(type: "real", nullable: false),
                    Water = table.Column<float>(type: "real", nullable: false),
                    Nitrogen = table.Column<float>(type: "real", nullable: false),
                    ImageName = table.Column<string>(type: "text", nullable: false),
                    Benefits = table.Column<string>(type: "text", nullable: false),
                    History = table.Column<string>(type: "text", nullable: false),
                    Portion = table.Column<float>(type: "real", nullable: false),
                    PortionUnit = table.Column<string>(type: "text", nullable: false),
                    Cholesterol = table.Column<float>(type: "real", nullable: false),
                    Caffeine = table.Column<float>(type: "real", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sugars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sucrose = table.Column<float>(type: "real", nullable: false),
                    Glucose = table.Column<float>(type: "real", nullable: false),
                    Fructose = table.Column<float>(type: "real", nullable: false),
                    Lactose = table.Column<float>(type: "real", nullable: false),
                    Maltose = table.Column<float>(type: "real", nullable: false),
                    Galactose = table.Column<float>(type: "real", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sugars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lipids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Saturated = table.Column<float>(type: "real", nullable: false),
                    Unsaturated = table.Column<float>(type: "real", nullable: false),
                    Trans = table.Column<float>(type: "real", nullable: false),
                    FoodId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lipids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lipids_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Minerals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Calcium = table.Column<float>(type: "real", nullable: false),
                    Iron = table.Column<float>(type: "real", nullable: false),
                    Magnesium = table.Column<float>(type: "real", nullable: false),
                    Phosphorus = table.Column<float>(type: "real", nullable: false),
                    Potassium = table.Column<float>(type: "real", nullable: false),
                    Sodium = table.Column<float>(type: "real", nullable: false),
                    Zinc = table.Column<float>(type: "real", nullable: false),
                    Copper = table.Column<float>(type: "real", nullable: false),
                    Manganese = table.Column<float>(type: "real", nullable: false),
                    Selenium = table.Column<float>(type: "real", nullable: false),
                    FoodId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Minerals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Minerals_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vitamins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FoodId = table.Column<int>(type: "integer", nullable: false),
                    VitaminC = table.Column<float>(type: "real", nullable: false),
                    Thiamin = table.Column<float>(type: "real", nullable: false),
                    Riboflavin = table.Column<float>(type: "real", nullable: false),
                    Niacin = table.Column<float>(type: "real", nullable: false),
                    PantothenicAcid = table.Column<float>(type: "real", nullable: false),
                    VitaminB6 = table.Column<float>(type: "real", nullable: false),
                    Folate = table.Column<float>(type: "real", nullable: false),
                    Choline = table.Column<float>(type: "real", nullable: false),
                    Betaine = table.Column<float>(type: "real", nullable: false),
                    VitaminA = table.Column<float>(type: "real", nullable: false),
                    Lycopene = table.Column<float>(type: "real", nullable: false),
                    LuteinZeaxanthin = table.Column<float>(type: "real", nullable: false),
                    VitaminE = table.Column<float>(type: "real", nullable: false),
                    VitaminK = table.Column<float>(type: "real", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vitamins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vitamins_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carbohydrates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SugarId = table.Column<int>(type: "integer", nullable: false),
                    Fiber = table.Column<float>(type: "real", nullable: false),
                    Starch = table.Column<float>(type: "real", nullable: false),
                    FoodId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carbohydrates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carbohydrates_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carbohydrates_Sugars_SugarId",
                        column: x => x.SugarId,
                        principalTable: "Sugars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carbohydrates_FoodId",
                table: "Carbohydrates",
                column: "FoodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carbohydrates_SugarId",
                table: "Carbohydrates",
                column: "SugarId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_Name",
                table: "Foods",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_NameTr",
                table: "Foods",
                column: "NameTr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lipids_FoodId",
                table: "Lipids",
                column: "FoodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Minerals_FoodId",
                table: "Minerals",
                column: "FoodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vitamins_FoodId",
                table: "Vitamins",
                column: "FoodId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carbohydrates");

            migrationBuilder.DropTable(
                name: "Lipids");

            migrationBuilder.DropTable(
                name: "Minerals");

            migrationBuilder.DropTable(
                name: "Vitamins");

            migrationBuilder.DropTable(
                name: "Sugars");

            migrationBuilder.DropTable(
                name: "Foods");
        }
    }
}
