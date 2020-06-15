using Helpdesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpdesk.Persistence.Configurations
{
    internal class HelpdeskTicketHistoryConfiguration : IEntityTypeConfiguration<HelpdeskTicketHistory>
    {
        public void Configure(EntityTypeBuilder<HelpdeskTicketHistory> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Response)
                .IsRequired();


            builder.Property(e => e.Status)
                .IsRequired();
            builder.Property(e => e.Timestamp)
                .IsRowVersion();

            builder.HasOne(d => d.HelpdeskTicket)
              .WithMany(p => p.HelpdeskTicketHistories)
              .HasForeignKey(d => d.TicketId)
              .HasConstraintName("FK_HelpdeskTicketHistories_HelpdeskTicket");
        }
    }
}