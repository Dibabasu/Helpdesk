using System;

namespace Helpdesk.Domain.Common
{
    public abstract class AuditableEntity
    {
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public byte[] Timestamp { get; set; }

        public bool IsDeleted { get; set; }
    }

    public abstract class AuditableTicketEntity
    {
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public byte[] Timestamp { get; set; }
    }
}