using AutoMapper;
using Helpdesk.Domain.Entities;
using Helpdesk.Model.Common.AutoMapper.Interface;
using System;
using System.Collections.Generic;

namespace Helpdesk.Models
{
    public class IssueCatagoryModel : IMapFrom<IssueCatagory>
    {
        public IssueCatagoryModel()
        {
            IssueSubCatagories = new HashSet<IssueSubCatagoryModel>();
        }

        public Guid Id { get; set; }
        public String IssueCatagoryCode { get; set; }
        public String Description { get; set; }

        public ICollection<IssueSubCatagoryModel> IssueSubCatagories { get; private set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<IssueCatagory, IssueCatagoryModel>();
        }
    }
}