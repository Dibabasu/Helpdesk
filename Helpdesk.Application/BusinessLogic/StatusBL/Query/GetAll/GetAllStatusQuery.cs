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

namespace Helpdesk.Application.BusinessLogic.StatusBL.Query.GetAll
{
    public class GetAllStatusQuery : IRequest<StatusListModel>
    {
        public class Handler : IRequestHandler<GetAllStatusQuery, StatusListModel>
        {
            private readonly IHelpdeskDbContext _context;
            private IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<StatusListModel> Handle(
                GetAllStatusQuery request,
                CancellationToken cancellationToken)
            {
                return new StatusListModel
                {
                    Statuses = await _context.Set<Status>()
                    .Where(x => x.IsDeleted == false)
                    .ProjectTo<StatusModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
                };
            }
        }
    }
}