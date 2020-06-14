using Helpdesk.Domain.Common;
using System;
using System.Collections.Generic;

namespace Helpdesk.Domain.Entities
{
    public class LocationType : AuditableEntity
    {
        public LocationType()
        {
            Locations = new HashSet<Location>();
        }

        public Guid Id { get; set; }
        public String Description { get; set; }
        public String LocationTypeCode { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}