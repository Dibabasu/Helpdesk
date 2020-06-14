using Helpdesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpdesk.Persistence.Configurations
{
    public class IssueTypeConfiguration : IEntityTypeConfiguration<IssueType>
    {
        public void Configure(EntityTypeBuilder<IssueType> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.IssueTypeCode)
                .IsRequired()
                .HasMaxLength(6);
            builder.Property(e => e.Timestamp)
                .IsRowVersion();
        }
    }
}