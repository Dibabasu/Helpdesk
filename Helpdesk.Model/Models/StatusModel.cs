using AutoMapper;
using Helpdesk.Domain.Entities;
using Helpdesk.Model.Common.AutoMapper.Interface;
using System;

namespace Helpdesk.Models
{
    public class StatusModel : IMapFrom<Status>
    {
        public Guid Id { get; set; }
        public String Description { get; set; }
        public String StatusCode { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Status, StatusModel>();
        }
    }
}