using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerHubSystem.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breweries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breweries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wholesalers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wholesalers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AlcoholPercentage = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BreweryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beers_Breweries_BreweryId",
                        column: x => x.BreweryId,
                        principalTable: "Breweries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeerSales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeerId = table.Column<int>(type: "int", nullable: false),
                    WholesalerId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    FixedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeerSales_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeerSales_Wholesalers_WholesalerId",
                        column: x => x.WholesalerId,
                        principalTable: "Wholesalers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Breweries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Abbey of Leffe" },
                    { 2, "Brouwerij Duvel Moortgat" },
                    { 3, "Brouwerij Het Anker" },
                    { 4, "Brouwerij De Halve Maan" },
                    { 5, "Brouwerij Westmalle" },
                    { 6, "Brouwerij Rodenbach" },
                    { 7, "Brouwerij St. Bernardus" }
                });

            migrationBuilder.InsertData(
                table: "Wholesalers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "GeneDrinks" },
                    { 2, "BeerWholesaler" },
                    { 3, "BelgianBeerDistributors" },
                    { 4, "TopBeerSuppliers" },
                    { 5, "PremierBeerWholesalers" },
                    { 6, "QualityBeerWholesalers" },
                    { 7, "EliteBeerDistributors" }
                });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "AlcoholPercentage", "BreweryId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 6.5999999999999996, 1, "Leffe Blonde", 2.20m },
                    { 2, 8.5, 2, "Duvel", 3.00m },
                    { 3, 8.5, 3, "Gouden Carolus Classic", 2.80m },
                    { 4, 6.0, 4, "Brugse Zot", 2.50m },
                    { 5, 9.5, 5, "Westmalle Tripel", 3.50m },
                    { 6, 6.0, 6, "Rodenbach Grand Cru", 2.70m },
                    { 7, 10.0, 7, "St. Bernardus Abt 12", 3.20m }
                });

            migrationBuilder.InsertData(
                table: "BeerSales",
                columns: new[] { "Id", "BeerId", "FixedPrice", "Quantity", "WholesalerId" },
                values: new object[,]
                {
                    { 1, 1, 2.20m, 10, 1 },
                    { 2, 2, 3.00m, 15, 2 },
                    { 3, 3, 2.80m, 20, 3 },
                    { 4, 4, 2.50m, 12, 4 },
                    { 5, 5, 3.50m, 18, 5 },
                    { 6, 6, 2.70m, 8, 6 },
                    { 7, 7, 3.20m, 25, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BreweryId",
                table: "Beers",
                column: "BreweryId");

            migrationBuilder.CreateIndex(
                name: "IX_BeerSales_BeerId",
                table: "BeerSales",
                column: "BeerId");

            migrationBuilder.CreateIndex(
                name: "IX_BeerSales_WholesalerId",
                table: "BeerSales",
                column: "WholesalerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeerSales");

            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "Wholesalers");

            migrationBuilder.DropTable(
                name: "Breweries");
        }
    }
}
