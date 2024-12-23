using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class usda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DescriptionTr = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodNutrientSources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DescriptionTr = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodNutrientSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FoodClass = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DescriptionTr = table.Column<string>(type: "text", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsHistoricalReference = table.Column<bool>(type: "boolean", nullable: false),
                    NdbNumber = table.Column<int>(type: "integer", nullable: false),
                    DataType = table.Column<string>(type: "text", nullable: false),
                    FoodCategory = table.Column<string>(type: "text", nullable: false),
                    FdcId = table.Column<int>(type: "integer", nullable: false),
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
                name: "MeasureUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NameTr = table.Column<string>(type: "text", nullable: false),
                    Abbreviation = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasureUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nutrients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Rank = table.Column<int>(type: "integer", nullable: false),
                    UnitName = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutrients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodNutrientDerivations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DescriptionTr = table.Column<string>(type: "text", nullable: false),
                    SourceId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodNutrientDerivations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodNutrientDerivations_FoodNutrientSources_SourceId",
                        column: x => x.SourceId,
                        principalTable: "FoodNutrientSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InputFoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FoodDescription = table.Column<string>(type: "text", nullable: false),
                    FoodDescriptionTr = table.Column<string>(type: "text", nullable: false),
                    FoodId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputFoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputFoods_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutrientConversionFactors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ProteinValue = table.Column<float>(type: "real", nullable: false),
                    CarbohydrateValue = table.Column<float>(type: "real", nullable: false),
                    FatValue = table.Column<float>(type: "real", nullable: false),
                    FoodId = table.Column<int>(type: "integer", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutrientConversionFactors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutrientConversionFactors_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FoodPortions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<float>(type: "real", nullable: false),
                    MeasureUnitId = table.Column<int>(type: "integer", nullable: false),
                    GramWeight = table.Column<float>(type: "real", nullable: false),
                    SequenceNumber = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    MinYearAcquired = table.Column<int>(type: "integer", nullable: false),
                    FoodId = table.Column<int>(type: "integer", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodPortions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodPortions_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FoodPortions_MeasureUnits_MeasureUnitId",
                        column: x => x.MeasureUnitId,
                        principalTable: "MeasureUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodNutrients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    NutrientId = table.Column<int>(type: "integer", nullable: false),
                    DataPoints = table.Column<int>(type: "integer", nullable: false),
                    DerivationId = table.Column<int>(type: "integer", nullable: false),
                    Median = table.Column<float>(type: "real", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    FoodId = table.Column<int>(type: "integer", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodNutrients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodNutrients_FoodNutrientDerivations_DerivationId",
                        column: x => x.DerivationId,
                        principalTable: "FoodNutrientDerivations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodNutrients_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FoodNutrients_Nutrients_NutrientId",
                        column: x => x.NutrientId,
                        principalTable: "Nutrients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodNutrientDerivations_SourceId",
                table: "FoodNutrientDerivations",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodNutrients_DerivationId",
                table: "FoodNutrients",
                column: "DerivationId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodNutrients_FoodId",
                table: "FoodNutrients",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodNutrients_NutrientId",
                table: "FoodNutrients",
                column: "NutrientId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodPortions_FoodId",
                table: "FoodPortions",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodPortions_MeasureUnitId",
                table: "FoodPortions",
                column: "MeasureUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_InputFoods_FoodId",
                table: "InputFoods",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_NutrientConversionFactors_FoodId",
                table: "NutrientConversionFactors",
                column: "FoodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodCategories");

            migrationBuilder.DropTable(
                name: "FoodNutrients");

            migrationBuilder.DropTable(
                name: "FoodPortions");

            migrationBuilder.DropTable(
                name: "InputFoods");

            migrationBuilder.DropTable(
                name: "NutrientConversionFactors");

            migrationBuilder.DropTable(
                name: "FoodNutrientDerivations");

            migrationBuilder.DropTable(
                name: "Nutrients");

            migrationBuilder.DropTable(
                name: "MeasureUnits");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "FoodNutrientSources");
        }
    }
}
