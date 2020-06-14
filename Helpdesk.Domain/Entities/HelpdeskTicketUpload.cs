using Helpdesk.Domain.Common;

namespace Helpdesk.Domain.Entities
{
    public class HelpdeskTicketUpload : TicketUpload
    {
        public HelpdeskTicket HelpdeskTicket { get; set; }
    }
}