using Helpdesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpdesk.Persistence.Configurations
{
    public class HelpdeskTicketUploadConfiguration : IEntityTypeConfiguration<HelpdeskTicketUpload>
    {
        public void Configure(EntityTypeBuilder<HelpdeskTicketUpload> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.OriginalFileName)
                .IsRequired();
            builder.Property(e => e.Timestamp)
                .IsRowVersion();

            builder.HasOne(d => d.HelpdeskTicket)
           .WithMany(p => p.HelpdeskTicketUploads)
           .HasForeignKey(d => d.TicketId)
           .HasConstraintName("FK_HelpdeskTicketUploads_HelpdeskTicket");
        }
    }
}