using Helpdesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpdesk.Persistence.Configurations
{
    public class IssueSubCatagoryConfiguration : IEntityTypeConfiguration<IssueSubCatagory>
    {
        public void Configure(EntityTypeBuilder<IssueSubCatagory> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.IssueSubCatagoryCode)
                .IsRequired()
                .HasMaxLength(6);
            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.Timestamp)
                .IsRowVersion();
            builder.HasOne(d => d.IssueCatagory)
               .WithMany(p => p.IssueSubCatagories)
               .HasForeignKey(d => d.IssueCatagoryId)
               .HasConstraintName("FK_IssueSubCatagories_IssueCatagory");
        }
    }
}