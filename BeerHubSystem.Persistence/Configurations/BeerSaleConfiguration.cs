using BeerHubSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerHubSystem.Persistence.Configurations
{
    public class BeerSaleConfiguration : IEntityTypeConfiguration<BeerSale>
    {
        public void Configure(EntityTypeBuilder<BeerSale> builder)
        {
            builder.HasKey(bs => bs.Id);
            builder.Property(bs => bs.Quantity)
                .IsRequired();
            builder.Property(bs => bs.FixedPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasOne(bs => bs.Beer)
                .WithMany(b => b.BeerSales)
                .HasForeignKey(bs => bs.BeerId);

            builder.HasOne(bs => bs.Wholesaler)
                .WithMany(w => w.BeerSales)
                .HasForeignKey(bs => bs.WholesalerId);
        }
    }
}
