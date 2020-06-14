using Helpdesk.Domain.Common;
using Helpdesk.Shared.Enums;
using System;

namespace Helpdesk.Domain.Entities
{
    public class UserRole : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Roles Role { get; set; }
    }
}