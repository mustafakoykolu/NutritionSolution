using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFoods : Migration
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
                    KCal = table.Column<float>(type: "real", nullable: false),
                    Protein = table.Column<float>(type: "real", nullable: false),
                    Fat = table.Column<float>(type: "real", nullable: false),
                    Carbs = table.Column<float>(type: "real", nullable: false),
                    Fiber = table.Column<float>(type: "real", nullable: false),
                    Sugar = table.Column<float>(type: "real", nullable: false),
                    Salt = table.Column<float>(type: "real", nullable: false),
                    Iron = table.Column<float>(type: "real", nullable: false),
                    VitaminA = table.Column<float>(type: "real", nullable: false),
                    VitaminC = table.Column<float>(type: "real", nullable: false),
                    VitaminD = table.Column<float>(type: "real", nullable: false),
                    VitaminE = table.Column<float>(type: "real", nullable: false),
                    VitaminK = table.Column<float>(type: "real", nullable: false),
                    VitaminB1 = table.Column<float>(type: "real", nullable: false),
                    VitaminB2 = table.Column<float>(type: "real", nullable: false),
                    VitaminB3 = table.Column<float>(type: "real", nullable: false),
                    VitaminB5 = table.Column<float>(type: "real", nullable: false),
                    VitaminB6 = table.Column<float>(type: "real", nullable: false),
                    VitaminB7 = table.Column<float>(type: "real", nullable: false),
                    VitaminB9 = table.Column<float>(type: "real", nullable: false),
                    VitaminB12 = table.Column<float>(type: "real", nullable: false),
                    Calcium = table.Column<float>(type: "real", nullable: false),
                    Phosphorus = table.Column<float>(type: "real", nullable: false),
                    Magnesium = table.Column<float>(type: "real", nullable: false),
                    Zinc = table.Column<float>(type: "real", nullable: false),
                    Copper = table.Column<float>(type: "real", nullable: false),
                    Manganese = table.Column<float>(type: "real", nullable: false),
                    Selenium = table.Column<float>(type: "real", nullable: false),
                    Potassium = table.Column<float>(type: "real", nullable: false),
                    Sodium = table.Column<float>(type: "real", nullable: false),
                    Cholesterol = table.Column<float>(type: "real", nullable: false),
                    Caffeine = table.Column<float>(type: "real", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    Benefits = table.Column<string>(type: "text", nullable: false),
                    History = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");
        }
    }
}
