using Helpdesk.Domain.Common;
using System;
using System.Collections.Generic;

namespace Helpdesk.Domain.Entities
{
    public class Status : AuditableEntity
    {
        public Status()
        {
            HelpdeskTickets = new HashSet<HelpdeskTicket>();
            ApproverMappings = new HashSet<ApproverMapping>();
        }

        public Guid Id { get; set; }
        public String Description { get; set; }
        public String StatusCode { get; set; }
        public ICollection<HelpdeskTicket> HelpdeskTickets { get; private set; }
        public ICollection<ApproverMapping> ApproverMappings { get; private set; }
    }
}