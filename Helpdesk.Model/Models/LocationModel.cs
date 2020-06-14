using AutoMapper;
using Helpdesk.Domain.Entities;
using Helpdesk.Model.Common.AutoMapper.Interface;
using System;

namespace Helpdesk.Models
{
    public class LocationModel : IMapFrom<Location>
    {
        public Guid Id { get; set; }
        public String Description { get; set; }
        public String LocationCode { get; set; }
        public Guid LocationTypeId { get; set; }

        public Guid CountryId { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Location, LocationModel>();
        }
    }
}