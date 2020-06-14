using Helpdesk.Domain.Common;

namespace Helpdesk.Domain.Entities
{
    public class HelpdeskTicketHistory : TicketHistory
    {
        public HelpdeskTicket HelpdeskTicket { get; set; }
    }
}