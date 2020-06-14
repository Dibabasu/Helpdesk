using Helpdesk.Domain.Common;
using System;
using System.Collections.Generic;

namespace Helpdesk.Domain.Entities
{
    public class Country : AuditableEntity
    {
        public Country()
        {
            Locations = new HashSet<Location>();
        }

        public Guid Id { get; set; }
        public String Description { get; set; }
        public String CountryCode { get; set; }
        public ICollection<Location> Locations { get; private set; }
    }
}