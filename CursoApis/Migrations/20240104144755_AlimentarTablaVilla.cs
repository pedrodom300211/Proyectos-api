using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CursoApis.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarTablaVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa", "imageUrl" },
                values: new object[,]
                {
                    { 1, "", "Detalle de la Villa...", new DateTime(2024, 1, 4, 11, 47, 55, 411, DateTimeKind.Local).AddTicks(6530), new DateTime(2024, 1, 4, 11, 47, 55, 411, DateTimeKind.Local).AddTicks(6541), 50, "Villa Real", 5, 200, "" },
                    { 2, "", "Detalle de la Villa...", new DateTime(2024, 1, 4, 11, 47, 55, 411, DateTimeKind.Local).AddTicks(6544), new DateTime(2024, 1, 4, 11, 47, 55, 411, DateTimeKind.Local).AddTicks(6544), 50, "Villa Falsa", 5, 200, "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
