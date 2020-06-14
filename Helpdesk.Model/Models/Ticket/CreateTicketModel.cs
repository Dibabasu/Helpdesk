using Helpdesk.Shared.Enums;
using System;

namespace Helpdesk.Application.Models.Ticket
{
    public class CreateTicketModel
    {
        public Guid ID { get; set; }
        public Guid IssueCatagoryId { get; set; }
        public Guid IssueSubCatagoryId { get; set; }
        public Guid IssueTypeId { get; set; }
        public String Desciption { get; set; }
        public PriorityLevel PriorityLevel { get; set; }

        public Guid LocationId { get; set; }
    }
}