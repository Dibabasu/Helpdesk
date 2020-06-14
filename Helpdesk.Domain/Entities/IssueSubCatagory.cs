using Helpdesk.Domain.Common;
using System;
using System.Collections.Generic;

namespace Helpdesk.Domain.Entities
{
    public class IssueSubCatagory : AuditableEntity
    {
        public IssueSubCatagory()
        {
            HelpdeskTickets = new HashSet<HelpdeskTicket>();
            ApproverMappings = new HashSet<ApproverMapping>();
            ConsultantMappings = new HashSet<ConsultantMapping>();
        }

        public Guid Id { get; set; }
        public String Description { get; set; }
        public String IssueSubCatagoryCode { get; set; }

        public Guid IssueCatagoryId { get; set; }

        public IssueCatagory IssueCatagory { get; set; }

        public ICollection<HelpdeskTicket> HelpdeskTickets { get; private set; }
        public ICollection<ApproverMapping> ApproverMappings { get; private set; }
        public ICollection<ConsultantMapping> ConsultantMappings { get; private set; }
    }
}