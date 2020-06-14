using System;

namespace Helpdesk.Domain.Common
{
    public class TicketHistory : AuditableTicketEntity
    {
        public Guid Id { get; set; }
        public String TicketNumber { get; set; }
        public Guid TicketId { get; set; }
        public String Response { get; set; }
        public Guid Status { get; set; }
        public int ElapsedTime { get; set; }
    }
}