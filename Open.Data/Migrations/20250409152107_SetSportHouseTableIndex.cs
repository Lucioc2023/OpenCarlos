using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Open.Data.Migrations
{
    /// <inheritdoc />
    public partial class SetSportHouseTableIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SportHouses_Name_Addres",
                table: "SportHouses",
                columns: new[] { "Name", "Addres" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SportHouses_Name_Addres",
                table: "SportHouses");
        }
    }
}
