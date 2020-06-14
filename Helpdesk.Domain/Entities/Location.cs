using Helpdesk.Domain.Common;
using System;
using System.Collections.Generic;

namespace Helpdesk.Domain.Entities
{
    public class Location : AuditableEntity
    {
        public Location()
        {
            HelpdeskTickets = new HashSet<HelpdeskTicket>();
            ApproverMappings = new HashSet<ApproverMapping>();
            ConsultantMappings = new HashSet<ConsultantMapping>();
        }

        public Guid Id { get; set; }
        public String Description { get; set; }
        public String LocationCode { get; set; }
        public Guid LocationTypeId { get; set; }
        public LocationType LocationType { get; set; }

        public Guid CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<HelpdeskTicket> HelpdeskTickets { get; private set; }
        public ICollection<ApproverMapping> ApproverMappings { get; private set; }
        public ICollection<ConsultantMapping> ConsultantMappings { get; private set; }
    }
}