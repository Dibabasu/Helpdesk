using System;

namespace Helpdesk.Models.Create
{
    public class LocationCreateModel
    {
        public Guid Id { get; set; }
        public String Description { get; set; }
        public String LocationCode { get; set; }
        public Guid LocationTypeId { get; set; }
        public Guid CountryId { get; set; }
    }
}