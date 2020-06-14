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

namespace Helpdesk.Application.BusinessLogic.Tickets.Query.GetTicketByNumber
{
    public class GetHelpdeskTicketByTicektNumberQuery : IRequest<HelpdeskTicketModel>
    {
        public String TicketNumber { get; set; }

        public class Handler : IRequestHandler<GetHelpdeskTicketByTicektNumberQuery, HelpdeskTicketModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<HelpdeskTicketModel> Handle(GetHelpdeskTicketByTicektNumberQuery request, CancellationToken cancellationToken)
            {
                var entity = await _context.Set<HelpdeskTicket>()
               .Where(r => r.TicketNumber == request.TicketNumber)
               .ProjectTo<HelpdeskTicketModel>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync()
               ;

                if (entity == null)
                {
                    throw new NotFoundException(nameof(HelpdeskTicketModel), request.TicketNumber);
                }

                return entity;
            }
        }
    }
}