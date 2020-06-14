using AutoMapper;
using Helpdesk.Domain.Entities;
using Helpdesk.Model.Common.AutoMapper.Interface;
using Helpdesk.Shared.Enums;
using System;

namespace Helpdesk.Models
{
    public class UserRoleModel : IMapFrom<UserRole>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
        public Roles Role { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<UserRole, UserRoleModel>();
        }
    }
}