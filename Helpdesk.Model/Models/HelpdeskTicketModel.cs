using AutoMapper;
using Helpdesk.Domain.Entities;
using Helpdesk.Model.Common.AutoMapper.Interface;

namespace Helpdesk.Models
{
    public class HelpdeskTicketModel : IMapFrom<HelpdeskTicket>
    {
        public string Status { get; set; }
        public string Location { get; set; }
        public string IssueCatagory { get; set; }
        public string IssueSubCatagory { get; set; }
        public string IssueType { get; set; }
        public string LocationType { get; set; }
        public string ReportedByUserName { get; set; }
        public string ReportedByUserId { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<HelpdeskTicket, HelpdeskTicketModel>()
                .ForMember(dto => dto.Status, opt => opt.MapFrom(src => src.Status.Description))
                .ForMember(dto => dto.Location, opt => opt.MapFrom(src => src.Location.Description))
                .ForMember(dto => dto.IssueSubCatagory, opt => opt.MapFrom(src => src.IssueSubCatagory.Description))
                .ForMember(dto => dto.IssueCatagory, opt => opt.MapFrom(src => src.IssueSubCatagory.IssueCatagory.Description))
                .ForMember(dto => dto.IssueType, opt => opt.MapFrom(src => src.IssueType.Description))
                .ForMember(dto => dto.LocationType, opt => opt.MapFrom(src => src.Location.LocationType.Description))
                .ForMember(dto => dto.ReportedByUserId, opt => opt.MapFrom(src => src.User.AdAccount.UserName))
                .ForMember(dto => dto.ReportedByUserName, opt => opt
                .MapFrom(src => string.Format("{0} {1}", src.User.Name.FirstMidName, src.User.Name.LastName)));
        }
    }
}