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
    [Migration("20241219175835_2024.12.19_FoodUpdate")]
    partial class _20241219_FoodUpdate
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
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateModified")
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

                    b.ToTable("Foods");
                });
#pragma warning restore 612, 618
        }
    }
}
