using Helpdesk.Shared.Enums;
using System;

namespace Helpdesk.Domain.Common
{
    public class TicketApproval : AuditableTicketEntity
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public Guid Reportedy { get; set; }
        public Guid Status { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
    }
}