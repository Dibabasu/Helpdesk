using Helpdesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpdesk.Persistence.Configurations
{
    public class CountyConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.CountryCode)
                .IsRequired()
                .HasMaxLength(6);
            builder.Property(e => e.Timestamp)
                .IsRowVersion();
        }
    }
}