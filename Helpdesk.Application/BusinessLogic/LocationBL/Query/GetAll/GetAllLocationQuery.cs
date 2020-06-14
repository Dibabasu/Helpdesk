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

namespace Helpdesk.Application.BusinessLogic.LocationBL.Query.GetAll
{
    public class GetAllLocationQuery : IRequest<LocationListModel>
    {
        public class Handler : IRequestHandler<GetAllLocationQuery, LocationListModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<LocationListModel> Handle(
                GetAllLocationQuery request,
                CancellationToken cancellationToken)
            {
                return new LocationListModel
                {
                    Locations = await _context.Set<Location>()
                    .Where(x => x.IsDeleted == false)
                    .ProjectTo<LocationModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
                };
            }
        }
    }
}