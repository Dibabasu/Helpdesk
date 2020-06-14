using AutoMapper;
using Helpdesk.Application.Common;

namespace Helpdesk.Application.BusinessLogic
{
    public class RequestDomainToProfile : Profile
    {
        public RequestDomainToProfile()
        {
            CreateMap<PaginationQuery, PaginationFilter>();
        }
    }
}