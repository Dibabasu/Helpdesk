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

namespace Helpdesk.Application.BusinessLogic.ConsultantMappingBL.Query.GetById
{
    public class GetConsultantMappingByIdQuery : IRequest<ConsultantMappingModel>
    {
        public Guid Id { get; set; }

        public class Handler : IRequestHandler<GetConsultantMappingByIdQuery, ConsultantMappingModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ConsultantMappingModel> Handle(
                GetConsultantMappingByIdQuery request,
                CancellationToken cancellationToken)
            {
                var entity = await _context.Set<ConsultantMapping>()
                 .Where(r => r.Id == request.Id)
                 .ProjectTo<ConsultantMappingModel>(_mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(ConsultantMappingModel), request.Id);
                }

                return entity;
            }
        }
    }
}