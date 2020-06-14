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

namespace Helpdesk.Application.BusinessLogic.LocationTypeBL.Query.GetById
{
    public class GetLocationTypeByIdQuery : IRequest<LocationTypeModel>
    {
        public Guid Id { get; set; }

        public class Handler : IRequestHandler<GetLocationTypeByIdQuery, LocationTypeModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<LocationTypeModel> Handle(
                GetLocationTypeByIdQuery request,
                CancellationToken cancellationToken)
            {
                var entity = await _context.Set<LocationType>()
                 .Where(r => r.Id == request.Id)
                 .ProjectTo<LocationTypeModel>(_mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(LocationTypeModel), request.Id);
                }

                return entity;
            }
        }
    }
}