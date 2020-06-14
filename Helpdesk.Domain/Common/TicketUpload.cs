using System;

namespace Helpdesk.Domain.Common
{
    public class TicketUpload : AuditableTicketEntity
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public String TicketNumber { get; set; }
        public String OriginalFileName { get; set; }
        public String UploadedFileName { get; set; }
    }
}