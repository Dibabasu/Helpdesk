using AutoMapper;
using AutoMapper.QueryableExtensions;
using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.IssueTypeBL.Query
{
    public class GetAllIssueTypeQuery : IRequest<IssueTypeListModel>
    {
        public class Handler : IRequestHandler<GetAllIssueTypeQuery, IssueTypeListModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IssueTypeListModel> Handle(
                GetAllIssueTypeQuery request,
                CancellationToken cancellationToken)
            {
                return new IssueTypeListModel
                {
                    IssueTypes = await _context.Set<IssueType>()
                    .ProjectTo<IssueTypeModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
                };
            }
        }
    }
}