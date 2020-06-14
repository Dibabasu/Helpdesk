using Helpdesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpdesk.Persistence.Configurations
{
    internal class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.StatusCode)
                .IsRequired()
                .HasMaxLength(6);
            builder.Property(e => e.Timestamp)
                .IsRowVersion();
        }
    }
}