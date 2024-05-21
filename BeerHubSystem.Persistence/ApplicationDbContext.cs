using BeerHubSystem.Domain.Entities;
using BeerHubSystem.Persistence.Configurations;
namespace BeerHubSystem.Persistence;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Brewery> Breweries { get; set; }
    public DbSet<Beer> Beers { get; set; }
    public DbSet<Wholesaler> Wholesalers { get; set; }
    public DbSet<BeerSale> BeerSales { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BreweryConfiguration());
        modelBuilder.ApplyConfiguration(new BeerConfiguration());
        modelBuilder.ApplyConfiguration(new WholesalerConfiguration());
        modelBuilder.ApplyConfiguration(new BeerSaleConfiguration());

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Seed Breweries
        var breweries = new List<Brewery>
        {
            new Brewery { Id = 1, Name = "Abbey of Leffe" },
            new Brewery { Id = 2, Name = "Brouwerij Duvel Moortgat" },
            new Brewery { Id = 3, Name = "Brouwerij Het Anker" },
            new Brewery { Id = 4, Name = "Brouwerij De Halve Maan" },
            new Brewery { Id = 5, Name = "Brouwerij Westmalle" },
            new Brewery { Id = 6, Name = "Brouwerij Rodenbach" },
            new Brewery { Id = 7, Name = "Brouwerij St. Bernardus" }
        };
        modelBuilder.Entity<Brewery>().HasData(breweries);

        // Seed Beers
        var beers = new List<Beer>
        {
            new Beer { Id = 1, Name = "Leffe Blonde", AlcoholPercentage = 6.6, Price = 2.20m, BreweryId = 1 },
            new Beer { Id = 2, Name = "Duvel", AlcoholPercentage = 8.5, Price = 3.00m, BreweryId = 2 },
            new Beer { Id = 3, Name = "Gouden Carolus Classic", AlcoholPercentage = 8.5, Price = 2.80m, BreweryId = 3 },
            new Beer { Id = 4, Name = "Brugse Zot", AlcoholPercentage = 6.0, Price = 2.50m, BreweryId = 4 },
            new Beer { Id = 5, Name = "Westmalle Tripel", AlcoholPercentage = 9.5, Price = 3.50m, BreweryId = 5 },
            new Beer { Id = 6, Name = "Rodenbach Grand Cru", AlcoholPercentage = 6.0, Price = 2.70m, BreweryId = 6 },
            new Beer { Id = 7, Name = "St. Bernardus Abt 12", AlcoholPercentage = 10.0, Price = 3.20m, BreweryId = 7 }
        };
        modelBuilder.Entity<Beer>().HasData(beers);

        // Seed Wholesalers
        var wholesalers = new List<Wholesaler>
        {
            new Wholesaler { Id = 1, Name = "GeneDrinks" },
            new Wholesaler { Id = 2, Name = "BeerWholesaler" },
            new Wholesaler { Id = 3, Name = "BelgianBeerDistributors" },
            new Wholesaler { Id = 4, Name = "TopBeerSuppliers" },
            new Wholesaler { Id = 5, Name = "PremierBeerWholesalers" },
            new Wholesaler { Id = 6, Name = "QualityBeerWholesalers" },
            new Wholesaler { Id = 7, Name = "EliteBeerDistributors" }
        };
        modelBuilder.Entity<Wholesaler>().HasData(wholesalers);

        // Seed BeerSales
        var beerSales = new List<BeerSale>
        {
            new BeerSale { Id = 1, BeerId = 1, WholesalerId = 1, Quantity = 10, FixedPrice = 2.20m },
            new BeerSale { Id = 2, BeerId = 2, WholesalerId = 2, Quantity = 15, FixedPrice = 3.00m },
            new BeerSale { Id = 3, BeerId = 3, WholesalerId = 3, Quantity = 20, FixedPrice = 2.80m },
            new BeerSale { Id = 4, BeerId = 4, WholesalerId = 4, Quantity = 12, FixedPrice = 2.50m },
            new BeerSale { Id = 5, BeerId = 5, WholesalerId = 5, Quantity = 18, FixedPrice = 3.50m },
            new BeerSale { Id = 6, BeerId = 6, WholesalerId = 6, Quantity = 8, FixedPrice = 2.70m },
            new BeerSale { Id = 7, BeerId = 7, WholesalerId = 7, Quantity = 25, FixedPrice = 3.20m }
        };
        modelBuilder.Entity<BeerSale>().HasData(beerSales);
    }
}



