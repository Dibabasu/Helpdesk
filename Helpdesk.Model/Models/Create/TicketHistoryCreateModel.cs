using System;
using System.Collections.Generic;
using System.Text;

namespace Helpdesk.Model.Models.Create
{
    public class TicketHistoryCreateModel
    {
        public Guid Id { get; set; }
        public String TicketNumber { get; set; }
        public Guid TicketId { get; set; }
        public String Response { get; set; }
        public Guid Status { get; set; }
        public int ElapsedTime { get; set; }
    }
}
