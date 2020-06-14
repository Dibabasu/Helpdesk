using AutoMapper;
using AutoMapper.QueryableExtensions;
using Helpdesk.Application.Exceptions;
using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.LocationBL.Query.GetById
{
    public class GetLocationByIdQuery : IRequest<LocationModel>
    {
        public Guid Id { get; set; }

        public class Handler : IRequestHandler<GetLocationByIdQuery, LocationModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<LocationModel> Handle(
                GetLocationByIdQuery request,
                CancellationToken cancellationToken)
            {
                var entity = await _context.Set<Location>()
                 .Where(r => r.Id == request.Id)
                 .ProjectTo<LocationModel>(_mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(LocationModel), request.Id);
                }

                return entity;
            }
        }
    }
}