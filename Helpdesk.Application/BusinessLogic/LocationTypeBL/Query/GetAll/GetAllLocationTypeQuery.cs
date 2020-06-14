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

namespace Helpdesk.Application.BusinessLogic.LocationTypeBL.Query.GetAll
{
    public class GetAllLocationTypeQuery : IRequest<LocationTypeListModel>
    {
        public class Handler : IRequestHandler<GetAllLocationTypeQuery, LocationTypeListModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<LocationTypeListModel> Handle(
                GetAllLocationTypeQuery request,
                CancellationToken cancellationToken)
            {
                return new LocationTypeListModel
                {
                    LocationTypes = await _context.Set<LocationType>()
                    .Where(x => x.IsDeleted == false)
                    .ProjectTo<LocationTypeModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
                };
            }
        }
    }
}