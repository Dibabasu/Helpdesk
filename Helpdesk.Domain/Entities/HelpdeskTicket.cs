using Helpdesk.Domain.Common;
using System;
using System.Collections.Generic;

namespace Helpdesk.Domain.Entities
{
    public class HelpdeskTicket : Ticket
    {
        public HelpdeskTicket()
        {
            HelpdeskTicketHistories = new HashSet<HelpdeskTicketHistory>();
            HelpdeskTicketApprovals = new HashSet<HelpdeskTicketApproval>();
            HelpdeskTicketUploads = new HashSet<HelpdeskTicketUpload>();
        }

        public Guid IssueSubCatagoryId { get; set; }
        public IssueSubCatagory IssueSubCatagory { get; set; }

        public Guid IssueTypeId { get; set; }
        public IssueType IssueType { get; set; }

        public Status Status { get; set; }
        public Guid StatusId { get; set; }

        public Guid LocationId { get; set; }
        public Location Location { get; set; }
        public Guid ReportedBy { get; set; }
        public User User { get; set; }
        public ICollection<HelpdeskTicketHistory> HelpdeskTicketHistories { get; private set; }
        public ICollection<HelpdeskTicketApproval> HelpdeskTicketApprovals { get; private set; }
        public ICollection<HelpdeskTicketUpload> HelpdeskTicketUploads { get; private set; }
    }
}