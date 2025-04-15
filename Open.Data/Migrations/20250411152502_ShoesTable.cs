using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Open.Data.Migrations
{
    /// <inheritdoc />
    public partial class ShoesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shoe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Release = table.Column<DateOnly>(type: "date", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    SportHouseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shoe_SportHouses_SportHouseId",
                        column: x => x.SportHouseId,
                        principalTable: "SportHouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shoe_SportHouseId",
                table: "Shoe",
                column: "SportHouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shoe");
        }
    }
}
