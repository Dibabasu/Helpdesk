using Helpdesk.Domain.Common;
using System;
using System.Collections.Generic;

namespace Helpdesk.Domain.Entities
{
    public class IssueCatagory : AuditableEntity
    {
        public IssueCatagory()
        {
            IssueSubCatagories = new HashSet<IssueSubCatagory>();
        }

        public Guid Id { get; set; }
        public String IssueCatagoryCode { get; set; }
        public String Description { get; set; }

        public ICollection<IssueSubCatagory> IssueSubCatagories { get; private set; }
    }
}