using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Open.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyShoesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoe_SportHouses_SportHouseId",
                table: "Shoe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shoe",
                table: "Shoe");

            migrationBuilder.RenameTable(
                name: "Shoe",
                newName: "Shoes");

            migrationBuilder.RenameIndex(
                name: "IX_Shoe_SportHouseId",
                table: "Shoes",
                newName: "IX_Shoes_SportHouseId");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Release",
                table: "Shoes",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Shoes",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shoes",
                table: "Shoes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Shoes",
                columns: new[] { "Id", "Model", "Release", "Size", "SportHouseId" },
                values: new object[,]
                {
                    { 6, "Foundation and Earth", new DateOnly(1986, 10, 30), 400, 1 },
                    { 7, "Second Foundation", new DateOnly(1953, 10, 10), 400, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_Model_SportHousesId",
                table: "Shoes",
                columns: new[] { "Model", "SportHouseId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_SportHouses_SportHouseId",
                table: "Shoes",
                column: "SportHouseId",
                principalTable: "SportHouses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_SportHouses_SportHouseId",
                table: "Shoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shoes",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_Model_SportHousesId",
                table: "Shoes");

            migrationBuilder.DeleteData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Shoes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.RenameTable(
                name: "Shoes",
                newName: "Shoe");

            migrationBuilder.RenameIndex(
                name: "IX_Shoes_SportHouseId",
                table: "Shoe",
                newName: "IX_Shoe_SportHouseId");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Release",
                table: "Shoe",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Shoe",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shoe",
                table: "Shoe",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoe_SportHouses_SportHouseId",
                table: "Shoe",
                column: "SportHouseId",
                principalTable: "SportHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
