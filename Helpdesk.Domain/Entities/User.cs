using Helpdesk.Domain.Common;
using Helpdesk.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Helpdesk.Domain.Entities
{
    public class User : AuditableEntity
    {
        public User()
        {
            HelpdeskTickets = new HashSet<HelpdeskTicket>();
            UserRoles = new HashSet<UserRole>();
        }

        public Guid UserId { get; set; }
        public AdAccount AdAccount { get; set; }
        public String DepartmentName { get; set; }
        public String Division { get; set; }
        public Name Name { get; set; }

        public Guid LocaitonId { get; set; }
        public Location Location { get; set; }
        public ICollection<HelpdeskTicket> HelpdeskTickets { get; private set; }
        public ICollection<UserRole> UserRoles { get; private set; }
    }
}