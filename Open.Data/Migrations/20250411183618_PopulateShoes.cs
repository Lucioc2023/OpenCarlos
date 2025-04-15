using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Open.Data.Migrations
{
    /// <inheritdoc />
    public partial class PopulateShoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("INSERT INTO Shoes (Model, Release, Size, SportHouseId) VALUES ('Nike Air Force', '1982-01-01', 44, 1)");
            migrationBuilder.Sql("INSERT INTO Shoes (Model, Release, Size, SportHouseId) VALUES ('Adidas Superstar', '1969-01-01', 32, 2)");
            migrationBuilder.Sql("INSERT INTO Shoes (Model, Release, Size, SportHouseId) VALUES ('Jordan 1 Retro High OG', '1985-01-01', 48, 3)");
            migrationBuilder.Sql("INSERT INTO Shoes (Model, Release, Size, SportHouseId) VALUES ('New Balance 550', '1989-01-01', 40, 4)");
            migrationBuilder.Sql("INSERT INTO Shoes (Model, Release, Size, SportHouseId) VALUES ('Puma Suede Classic XXI', '1968-01-01', 36, 5)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Shoes WHERE Id IN (1,2,3,4,5)");
        }
    }
}
