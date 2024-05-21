﻿// <auto-generated />
using BeerHubSystem.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeerHubSystem.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240519161032_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BeerHubSystem.Domain.Entities.Beer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("AlcoholPercentage")
                        .HasColumnType("float");

                    b.Property<int>("BreweryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BreweryId");

                    b.ToTable("Beers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlcoholPercentage = 6.5999999999999996,
                            BreweryId = 1,
                            Name = "Leffe Blonde",
                            Price = 2.20m
                        },
                        new
                        {
                            Id = 2,
                            AlcoholPercentage = 8.5,
                            BreweryId = 2,
                            Name = "Duvel",
                            Price = 3.00m
                        },
                        new
                        {
                            Id = 3,
                            AlcoholPercentage = 8.5,
                            BreweryId = 3,
                            Name = "Gouden Carolus Classic",
                            Price = 2.80m
                        },
                        new
                        {
                            Id = 4,
                            AlcoholPercentage = 6.0,
                            BreweryId = 4,
                            Name = "Brugse Zot",
                            Price = 2.50m
                        },
                        new
                        {
                            Id = 5,
                            AlcoholPercentage = 9.5,
                            BreweryId = 5,
                            Name = "Westmalle Tripel",
                            Price = 3.50m
                        },
                        new
                        {
                            Id = 6,
                            AlcoholPercentage = 6.0,
                            BreweryId = 6,
                            Name = "Rodenbach Grand Cru",
                            Price = 2.70m
                        },
                        new
                        {
                            Id = 7,
                            AlcoholPercentage = 10.0,
                            BreweryId = 7,
                            Name = "St. Bernardus Abt 12",
                            Price = 3.20m
                        });
                });

            modelBuilder.Entity("BeerHubSystem.Domain.Entities.BeerSale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BeerId")
                        .HasColumnType("int");

                    b.Property<decimal>("FixedPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("WholesalerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BeerId");

                    b.HasIndex("WholesalerId");

                    b.ToTable("BeerSales");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BeerId = 1,
                            FixedPrice = 2.20m,
                            Quantity = 10,
                            WholesalerId = 1
                        },
                        new
                        {
                            Id = 2,
                            BeerId = 2,
                            FixedPrice = 3.00m,
                            Quantity = 15,
                            WholesalerId = 2
                        },
                        new
                        {
                            Id = 3,
                            BeerId = 3,
                            FixedPrice = 2.80m,
                            Quantity = 20,
                            WholesalerId = 3
                        },
                        new
                        {
                            Id = 4,
                            BeerId = 4,
                            FixedPrice = 2.50m,
                            Quantity = 12,
                            WholesalerId = 4
                        },
                        new
                        {
                            Id = 5,
                            BeerId = 5,
                            FixedPrice = 3.50m,
                            Quantity = 18,
                            WholesalerId = 5
                        },
                        new
                        {
                            Id = 6,
                            BeerId = 6,
                            FixedPrice = 2.70m,
                            Quantity = 8,
                            WholesalerId = 6
                        },
                        new
                        {
                            Id = 7,
                            BeerId = 7,
                            FixedPrice = 3.20m,
                            Quantity = 25,
                            WholesalerId = 7
                        });
                });

            modelBuilder.Entity("BeerHubSystem.Domain.Entities.Brewery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Breweries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Abbey of Leffe"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Brouwerij Duvel Moortgat"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Brouwerij Het Anker"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Brouwerij De Halve Maan"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Brouwerij Westmalle"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Brouwerij Rodenbach"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Brouwerij St. Bernardus"
                        });
                });

            modelBuilder.Entity("BeerHubSystem.Domain.Entities.Wholesaler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Wholesalers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "GeneDrinks"
                        },
                        new
                        {
                            Id = 2,
                            Name = "BeerWholesaler"
                        },
                        new
                        {
                            Id = 3,
                            Name = "BelgianBeerDistributors"
                        },
                        new
                        {
                            Id = 4,
                            Name = "TopBeerSuppliers"
                        },
                        new
                        {
                            Id = 5,
                            Name = "PremierBeerWholesalers"
                        },
                        new
                        {
                            Id = 6,
                            Name = "QualityBeerWholesalers"
                        },
                        new
                        {
                            Id = 7,
                            Name = "EliteBeerDistributors"
                        });
                });

            modelBuilder.Entity("BeerHubSystem.Domain.Entities.Beer", b =>
                {
                    b.HasOne("BeerHubSystem.Domain.Entities.Brewery", "Brewery")
                        .WithMany("Beers")
                        .HasForeignKey("BreweryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brewery");
                });

            modelBuilder.Entity("BeerHubSystem.Domain.Entities.BeerSale", b =>
                {
                    b.HasOne("BeerHubSystem.Domain.Entities.Beer", "Beer")
                        .WithMany("BeerSales")
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeerHubSystem.Domain.Entities.Wholesaler", "Wholesaler")
                        .WithMany("BeerSales")
                        .HasForeignKey("WholesalerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beer");

                    b.Navigation("Wholesaler");
                });

            modelBuilder.Entity("BeerHubSystem.Domain.Entities.Beer", b =>
                {
                    b.Navigation("BeerSales");
                });

            modelBuilder.Entity("BeerHubSystem.Domain.Entities.Brewery", b =>
                {
                    b.Navigation("Beers");
                });

            modelBuilder.Entity("BeerHubSystem.Domain.Entities.Wholesaler", b =>
                {
                    b.Navigation("BeerSales");
                });
#pragma warning restore 612, 618
        }
    }
}
