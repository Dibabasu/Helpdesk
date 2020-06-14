using Helpdesk.Domain.Common;
using System;

namespace Helpdesk.Domain.Entities
{
    public class ApproverMapping : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid LocationId { get; set; }
        public Location Location { get; set; }
        public Guid IssueTypeId { get; set; }
        public IssueType IssueType { get; set; }
        public Guid IssueSubCatagoryId { get; set; }
        public IssueSubCatagory IssueSubCatagory { get; set; }
        public Guid StatusId { get; set; }
        public Status Status { get; set; }
    }
}