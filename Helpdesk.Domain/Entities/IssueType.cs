using Helpdesk.Domain.Common;
using System;
using System.Collections.Generic;

namespace Helpdesk.Domain.Entities
{
    public class IssueType : AuditableEntity
    {
        public IssueType()
        {
            HelpdeskTickets = new HashSet<HelpdeskTicket>();
            ApproverMappings = new HashSet<ApproverMapping>();
            ConsultantMappings = new HashSet<ConsultantMapping>();
        }

        public Guid Id { get; set; }
        public String Description { get; set; }
        public string IssueTypeCode { get; set; }

        public ICollection<HelpdeskTicket> HelpdeskTickets { get; private set; }
        public ICollection<ApproverMapping> ApproverMappings { get; private set; }
        public ICollection<ConsultantMapping> ConsultantMappings { get; private set; }
    }
}