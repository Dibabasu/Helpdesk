using System;

namespace Helpdesk.Models.Create
{
    public class StatusCreateModel
    {
        public Guid Id { get; set; }
        public String Description { get; set; }
        public String StatusCode { get; set; }
    }
}