using System;

namespace Helpdesk.Models.Create
{
    public class LocationTypeCreateModel
    {
        public Guid Id { get; set; }
        public String Description { get; set; }
        public String LocationTypeCode { get; set; }
    }
}