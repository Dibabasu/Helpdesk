using AutoMapper;

using Helpdesk.Domain.Entities;
using Helpdesk.Model.Common.AutoMapper.Interface;
using System;

namespace Helpdesk.Models
{
    public class IssueSubCatagoryModel : IMapFrom<IssueSubCatagory>
    {
        public Guid Id { get; set; }
        public String Description { get; set; }
        public String IssueSubCatagoryCode { get; set; }

        public Guid IssueCatagoryId { get; set; }

        public IssueCatagoryModel IssueCatagory { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<IssueSubCatagory, IssueSubCatagoryModel>();
        }
    }
}