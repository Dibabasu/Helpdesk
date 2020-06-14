using Helpdesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpdesk.Persistence.Configurations
{
    public class LocationTypeConfiguration : IEntityTypeConfiguration<LocationType>
    {
        public void Configure(EntityTypeBuilder<LocationType> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.LocationTypeCode)
                .IsRequired()
                .HasMaxLength(6);
            builder.Property(e => e.Timestamp)
                .IsRowVersion();
        }
    }
}