using BeerHubSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerHubSystem.Persistence.Configurations
{ 
    public class WholesalerConfiguration : IEntityTypeConfiguration<Wholesaler>
    {
        public void Configure(EntityTypeBuilder<Wholesaler> builder)
        {
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(w => w.BeerSales)
                .WithOne(bs => bs.Wholesaler)
                .HasForeignKey(bs => bs.WholesalerId);
        }
    }
}
