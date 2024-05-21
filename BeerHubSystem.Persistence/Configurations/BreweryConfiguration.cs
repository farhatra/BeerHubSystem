using BeerHubSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BeerHubSystem.Persistence.Configurations
{
    public class BreweryConfiguration : IEntityTypeConfiguration<Brewery>
    {
        public void Configure(EntityTypeBuilder<Brewery> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(b => b.Beers)
                .WithOne(b => b.Brewery)
                .HasForeignKey(b => b.BreweryId);
        }
    }
}

