using AutoMapper;
using Helpdesk.Domain.Entities;
using Helpdesk.Model.Common.AutoMapper.Interface;
using System;

namespace Helpdesk.Models
{
    public class CountryModel : IMapFrom<Country>
    {
        public String CountryCode { get; set; }
        public String CountryName { get; set; }

        //public LocationListModel Locations { get; private set; }

        public void Mapping(Profile configuration)
        {
            configuration.CreateMap<Country, CountryModel>()
                .ForMember(dto => dto.CountryName, opt => opt.MapFrom(src => src.Description))
                .ForMember(dto => dto.CountryCode, opt => opt.MapFrom(src => src.CountryCode))

                ;


        }
    }
}