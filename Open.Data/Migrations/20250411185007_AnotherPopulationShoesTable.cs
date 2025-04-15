using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Open.Data.Migrations
{
    /// <inheritdoc />
    public partial class AnotherPopulationShoesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Model", "Release", "Size" },
                values: new object[] { "Reebok Classic Leather", new DateOnly(2006, 10, 30), 44 });

            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Model", "Release", "Size" },
                values: new object[] { "Converse Chuck Taylor All Star", new DateOnly(1970, 10, 10), 42 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Model", "Release", "Size" },
                values: new object[] { "Foundation and Earth", new DateOnly(1986, 10, 30), 400 });

            migrationBuilder.UpdateData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Model", "Release", "Size" },
                values: new object[] { "Second Foundation", new DateOnly(1953, 10, 10), 400 });
        }
    }
}
