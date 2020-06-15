using Helpdesk.Application.Interface;
using Helpdesk.Domain.Common;
using Helpdesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Persistence
{
    public class HelpdeskDbContext : DbContext, IHelpdeskDbContext
    {
        public HelpdeskDbContext()
        {
        }

        public HelpdeskDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<HelpdeskTicket> HelpdeskTickets { get; set; }
        public DbSet<HelpdeskTicketApproval> HelpdeskTicketApproval { get; set; }
        public DbSet<HelpdeskTicketHistory> HelpdeskTicketHistory { get; set; }
        public DbSet<HelpdeskTicketUpload> HelpdeskTicketUploads { get; set; }
        public DbSet<IssueSubCatagory> IssueSubCatagories { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<IssueType> IssueType { get; set; }
        public DbSet<ApproverMapping> ApproverMappings { get; set; }
        public DbSet<ConsultantMapping> ConsultantMappings { get; set; }

        public DbSet<LastTicket> LastTicket { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:

                        entry.Entity.Created = DateTime.UtcNow;
                        entry.Entity.LastModified = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:

                        entry.Entity.LastModified = DateTime.UtcNow;
                        break;
                }
            }
            foreach (var entry in ChangeTracker.Entries<AuditableTicketEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:

                        entry.Entity.Created = DateTime.UtcNow;
                        entry.Entity.LastModified = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:

                        entry.Entity.LastModified = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HelpdeskDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}