using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Open.Data.Migrations
{
    /// <inheritdoc />
    public partial class PopulateSportHousesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                 table: "SportHouses",
                columns: new[] { "Id", "Name", "Addres" },
                values: new object[,]
                    {
                        {1, "Iron Will Sports", "Asimov" },
                        {2, "Victory Sporting Goods","Clarke" },
                        {3, "All-Star Athletics", "Bradbury" },
                        {4, "Champion's Outfitters","Dick" },
                        {5, "Game On Sports","Le Guin" }
                    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SportHouses",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5 });
        }
    }
}
