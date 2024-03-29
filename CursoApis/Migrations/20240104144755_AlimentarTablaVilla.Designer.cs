﻿// <auto-generated />
using System;
using CursoApis.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CursoApis.Migrations
{
    [DbContext(typeof(ApliccationDboContext))]
    [Migration("20240104144755_AlimentarTablaVilla")]
    partial class AlimentarTablaVilla
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CursoApis.Modelos.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("MetrosCuadrados")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ocupantes")
                        .HasColumnType("int");

                    b.Property<int>("Tarifa")
                        .HasColumnType("int");

                    b.Property<string>("imageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenidad = "",
                            Detalle = "Detalle de la Villa...",
                            FechaActualizacion = new DateTime(2024, 1, 4, 11, 47, 55, 411, DateTimeKind.Local).AddTicks(6530),
                            FechaCreacion = new DateTime(2024, 1, 4, 11, 47, 55, 411, DateTimeKind.Local).AddTicks(6541),
                            MetrosCuadrados = 50,
                            Nombre = "Villa Real",
                            Ocupantes = 5,
                            Tarifa = 200,
                            imageUrl = ""
                        },
                        new
                        {
                            Id = 2,
                            Amenidad = "",
                            Detalle = "Detalle de la Villa...",
                            FechaActualizacion = new DateTime(2024, 1, 4, 11, 47, 55, 411, DateTimeKind.Local).AddTicks(6544),
                            FechaCreacion = new DateTime(2024, 1, 4, 11, 47, 55, 411, DateTimeKind.Local).AddTicks(6544),
                            MetrosCuadrados = 50,
                            Nombre = "Villa Falsa",
                            Ocupantes = 5,
                            Tarifa = 200,
                            imageUrl = ""
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
