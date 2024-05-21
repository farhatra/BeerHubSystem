using BeerHubSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerHubSystem.Persistence.Configurations
{
    public class BeerConfiguration : IEntityTypeConfiguration<Beer>
    {
        public void Configure(EntityTypeBuilder<Beer> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.AlcoholPercentage)
                .IsRequired();
            builder.Property(b => b.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasOne(b => b.Brewery)
                .WithMany(b => b.Beers)
                .HasForeignKey(b => b.BreweryId);

            builder.HasMany(b => b.BeerSales)
                .WithOne(bs => bs.Beer)
                .HasForeignKey(bs => bs.BeerId);
        }
    }
}
