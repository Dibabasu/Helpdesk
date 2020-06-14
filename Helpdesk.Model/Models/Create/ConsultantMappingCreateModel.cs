using System;

namespace Helpdesk.Model.Create
{
    public class ConsultantMappingCreateModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid LocationId { get; set; }
        public Guid IssueTypeId { get; set; }
        public Guid IssueSubCatagoryId { get; set; }
    }
}