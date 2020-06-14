using AutoMapper;
using Helpdesk.Domain.Entities;
using Helpdesk.Model.Common.AutoMapper.Interface;
using System;

namespace Helpdesk.Models
{
    public class LocationTypeModel : IMapFrom<LocationType>
    {
        public Guid Id { get; set; }
        public String Description { get; set; }
        public String LocationTypeCode { get; set; }
        public LocationListModel Locations { get; private set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<LocationType, LocationTypeModel>();
        }
    }
}