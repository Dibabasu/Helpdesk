using AutoMapper;
using Helpdesk.Domain.Entities;
using Helpdesk.Model.Common.AutoMapper.Interface;
using System;

namespace Helpdesk.Models
{
    public class ApproverMappingModel : IMapFrom<ApproverMapping>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
        public Guid LocationId { get; set; }
        public LocationTypeModel Location { get; set; }
        public Guid IssueTypeId { get; set; }
        public IssueTypeModel IssueType { get; set; }
        public Guid IssueSubCatagoryId { get; set; }
        public IssueSubCatagoryModel IssueSubCatagory { get; set; }
        public Guid StatusId { get; set; }
        public StatusModel Status { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<ApproverMapping, ApproverMappingModel>();
        }
    }
}