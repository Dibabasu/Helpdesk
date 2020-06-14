using Helpdesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Helpdesk.Persistence.Configurations
{
    internal class HelpdeskTicketConfiguration : IEntityTypeConfiguration<HelpdeskTicket>
    {
        public void Configure(EntityTypeBuilder<HelpdeskTicket> builder)
        {
            builder.HasKey(e => e.TicketId);
            builder.Property(e => e.TicketNumber)
                .IsRequired()
                .HasMaxLength(25);
            builder.Property(e => e.Timestamp)
                .IsRowVersion();
            builder.Property(e => e.ReportedBy)
                .IsRequired();
            builder.Property(e => e.Detail)
                .IsRequired();
            builder.Property(e => e.PriorityLevel).HasColumnType("smallint");

            builder.HasOne(d => d.User)
                .WithMany(p => p.HelpdeskTickets)
                .HasForeignKey(d => d.ReportedBy)
                .HasConstraintName("FK_HelpdeskTickets_User");
        }
    }
}