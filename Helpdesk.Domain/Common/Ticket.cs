using Helpdesk.Shared.Enums;
using System;

namespace Helpdesk.Domain.Common
{
    public class Ticket : AuditableTicketEntity
    {
        public Guid TicketId { get; set; }
        public String TicketNumber { get; set; }
        public String Detail { get; set; }
        public PriorityLevel PriorityLevel { get; set; }
        public int TotalTime { get; set; }
        public String ClosureRemark { get; set; }
    }
}