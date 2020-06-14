using System;

namespace Helpdesk.Models.Create
{
    public class IssueSubCatagoryCreateModel
    {
        public Guid Id { get; set; }
        public String Description { get; set; }
        public String IssueSubCatagoryCode { get; set; }

        public Guid IssueCatagoryId { get; set; }
    }
}