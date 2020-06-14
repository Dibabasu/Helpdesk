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

namespace Helpdesk.Application.BusinessLogic.ApproverMappingBL.Query.GetAll
{
    public class GetAllApproverMappingQuery : IRequest<ApproverMappingListModel>
    {
        public class Handler : IRequestHandler<GetAllApproverMappingQuery, ApproverMappingListModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ApproverMappingListModel> Handle(
                GetAllApproverMappingQuery request,
                CancellationToken cancellationToken)
            {
                return new ApproverMappingListModel
                {
                    ApproverMappings = await _context.Set<ApproverMapping>()
                    .Where(x => x.IsDeleted == false)
                    .ProjectTo<ApproverMappingModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
                };
            }
        }
    }
}