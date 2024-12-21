﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence.DatabaseContext;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(PersistenceDbContext))]
    [Migration("20241221080227_2024.12.21_MealIngredientNavigationProperty")]
    partial class _20241221_MealIngredientNavigationProperty
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entity.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Benefits")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Caffeine")
                        .HasColumnType("real");

                    b.Property<float>("Calcium")
                        .HasColumnType("real");

                    b.Property<float>("Carbs")
                        .HasColumnType("real");

                    b.Property<float>("Cholesterol")
                        .HasColumnType("real");

                    b.Property<float>("Copper")
                        .HasColumnType("real");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<float>("Fat")
                        .HasColumnType("real");

                    b.Property<float>("Fiber")
                        .HasColumnType("real");

                    b.Property<string>("History")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Iron")
                        .HasColumnType("real");

                    b.Property<float>("KCal")
                        .HasColumnType("real");

                    b.Property<float>("Magnesium")
                        .HasColumnType("real");

                    b.Property<float>("Manganese")
                        .HasColumnType("real");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Phosphorus")
                        .HasColumnType("real");

                    b.Property<float>("Portion")
                        .HasColumnType("real");

                    b.Property<string>("PortionUnit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Potassium")
                        .HasColumnType("real");

                    b.Property<float>("Protein")
                        .HasColumnType("real");

                    b.Property<float>("Salt")
                        .HasColumnType("real");

                    b.Property<float>("Selenium")
                        .HasColumnType("real");

                    b.Property<float>("Sodium")
                        .HasColumnType("real");

                    b.Property<float>("Sugar")
                        .HasColumnType("real");

                    b.Property<float>("VitaminA")
                        .HasColumnType("real");

                    b.Property<float>("VitaminB1")
                        .HasColumnType("real");

                    b.Property<float>("VitaminB12")
                        .HasColumnType("real");

                    b.Property<float>("VitaminB2")
                        .HasColumnType("real");

                    b.Property<float>("VitaminB3")
                        .HasColumnType("real");

                    b.Property<float>("VitaminB5")
                        .HasColumnType("real");

                    b.Property<float>("VitaminB6")
                        .HasColumnType("real");

                    b.Property<float>("VitaminB7")
                        .HasColumnType("real");

                    b.Property<float>("VitaminB9")
                        .HasColumnType("real");

                    b.Property<float>("VitaminC")
                        .HasColumnType("real");

                    b.Property<float>("VitaminD")
                        .HasColumnType("real");

                    b.Property<float>("VitaminE")
                        .HasColumnType("real");

                    b.Property<float>("VitaminK")
                        .HasColumnType("real");

                    b.Property<float>("Zinc")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("Domain.Entity.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("History")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Recipe")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("Domain.Entity.MealIngredient", b =>
                {
                    b.Property<int>("MealId")
                        .HasColumnType("integer");

                    b.Property<int>("FoodId")
                        .HasColumnType("integer");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MealId", "FoodId");

                    b.HasIndex("FoodId");

                    b.ToTable("MealRecipes");
                });

            modelBuilder.Entity("Domain.Entity.MealIngredient", b =>
                {
                    b.HasOne("Domain.Entity.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entity.Meal", "Meal")
                        .WithMany("MealIngredients")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("Domain.Entity.Meal", b =>
                {
                    b.Navigation("MealIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
