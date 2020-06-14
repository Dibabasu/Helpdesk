using AutoMapper;
using Helpdesk.Domain.Entities;
using Helpdesk.Model.Common.AutoMapper.Interface;
using System;
using System.Collections.Generic;

namespace Helpdesk.Models
{
    public class IssueTypeModel : IMapFrom<IssueType>
    {
        public IssueTypeModel()
        {
            HelpdeskTickets = new HashSet<HelpdeskTicketModel>();
            ApproverMappings = new HashSet<ApproverMappingModel>();
            ConsultantMappings = new HashSet<ConsultantMappingModel>();
        }

        public Guid Id { get; set; }
        public String Description { get; set; }
        public string IssueTypeCode { get; set; }

        public ICollection<HelpdeskTicketModel> HelpdeskTickets { get; private set; }
        public ICollection<ApproverMappingModel> ApproverMappings { get; private set; }
        public ICollection<ConsultantMappingModel> ConsultantMappings { get; private set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<IssueType, IssueTypeModel>();
        }
    }
}