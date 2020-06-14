using Helpdesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpdesk.Persistence.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.LocationCode)
                .IsRequired()
                .HasMaxLength(6);
            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(e => e.Timestamp)
                 .IsRowVersion();

            builder.HasOne(d => d.LocationType)
                .WithMany(p => p.Locations)
                .HasForeignKey(d => d.LocationTypeId)
                .HasConstraintName("FK_Locations_LocationType");

            builder.HasOne(d => d.Country)
               .WithMany(p => p.Locations)
               .HasForeignKey(d => d.CountryId)
               .HasConstraintName("FK_Locations_Country");
        }
    }
}