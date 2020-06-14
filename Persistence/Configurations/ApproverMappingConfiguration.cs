using Helpdesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpdesk.Persistence.Configurations
{
    public class ApproverMappingConfiguration : IEntityTypeConfiguration<ApproverMapping>
    {
        public void Configure(EntityTypeBuilder<ApproverMapping> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.UserId)
                .IsRequired();

            builder.Property(e => e.Timestamp)
                .IsRowVersion();
        }
    }
}