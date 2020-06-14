using AutoMapper;
using Helpdesk.Domain.Entities;
using Helpdesk.Model.Common.AutoMapper.Interface;
using System;

namespace Helpdesk.Models
{
    public class UserModel : IMapFrom<User>
    {
        public Guid UserId { get; set; }
        public String UserName { get; set; }
        public String Domain { get; set; }
        public String DepartmentName { get; set; }
        public String Division { get; set; }
        public String FirstMidName { get; set; }
        public String LastName { get; set; }

        public void Mapping(Profile configuration)
        {
            configuration.CreateMap<User, UserModel>()
                .ForMember(dto => dto.FirstMidName, opt => opt.MapFrom(src => src.Name.FirstMidName))
                .ForMember(dto => dto.LastName, opt => opt.MapFrom(src => src.Name.LastName))
                .ForMember(dto => dto.UserName, opt => opt.MapFrom(src => src.AdAccount.UserName))
                .ForMember(dto => dto.Domain, opt => opt.MapFrom(src => src.AdAccount.Domain))
                ;

        }
    }
}