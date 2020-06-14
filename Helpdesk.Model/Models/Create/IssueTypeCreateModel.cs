using System;

namespace Helpdesk.Models.Create
{
    public class IssueTypeCreateModel
    {
        public Guid Id { get; set; }
        public String Description { get; set; }
        public string IssueTypeCode { get; set; }
    }
}