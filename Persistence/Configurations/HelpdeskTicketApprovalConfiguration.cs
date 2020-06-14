using Helpdesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpdesk.Persistence.Configurations
{
    public class HelpdeskTicketApprovalConfiguration : IEntityTypeConfiguration<HelpdeskTicketApproval>
    {
        public void Configure(EntityTypeBuilder<HelpdeskTicketApproval> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.TicketId)
                .IsRequired();
            builder.Property(e => e.Status)
                .IsRequired();

            builder.Property(e => e.Timestamp)
                .IsRowVersion();

            builder.Property(e => e.ApprovalStatus)
                .HasColumnType("smallint")
                .HasDefaultValueSql("((1))")
                .IsRequired();

            builder.HasOne(d => d.HelpdeskTicket)
                 .WithMany(p => p.HelpdeskTicketApprovals)
                 .HasForeignKey(d => d.TicketId)
                 .HasConstraintName("FK_HelpdeskTicketApprovals_HelpdeskTicket");
        }
    }
}