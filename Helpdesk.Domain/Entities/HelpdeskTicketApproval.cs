﻿using Helpdesk.Domain.Common;

namespace Helpdesk.Domain.Entities
{
    public class HelpdeskTicketApproval : TicketApproval
    {
        public HelpdeskTicket HelpdeskTicket { get; set; }
    }
}