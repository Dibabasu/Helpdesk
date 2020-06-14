using AutoMapper;
using AutoMapper.QueryableExtensions;
using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.IssueSubCatagoryBL.Query.GetAll
{
    public class GetAllIssueSubCatagoryQuery : IRequest<IssueSubCatagoryListModel>
    {
        public class Handler : IRequestHandler<GetAllIssueSubCatagoryQuery, IssueSubCatagoryListModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IssueSubCatagoryListModel> Handle(
                GetAllIssueSubCatagoryQuery request,
                CancellationToken cancellationToken)
            {
                return new IssueSubCatagoryListModel
                {
                    IssueSubCatagories = await _context.Set<IssueSubCatagory>()
                    .Where(x => x.IsDeleted == false)
                    .ProjectTo<IssueSubCatagoryModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
                };
            }
        }
    }
}