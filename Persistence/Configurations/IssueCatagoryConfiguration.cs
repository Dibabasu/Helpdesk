using Helpdesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpdesk.Persistence.Configurations
{
    public class IssueCatagoryConfiguration : IEntityTypeConfiguration<IssueCatagory>
    {
        public void Configure(EntityTypeBuilder<IssueCatagory> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.IssueCatagoryCode)
                .IsRequired()
                .HasMaxLength(6);
            builder.Property(e => e.Timestamp)
                .IsRowVersion();
        }
    }
}