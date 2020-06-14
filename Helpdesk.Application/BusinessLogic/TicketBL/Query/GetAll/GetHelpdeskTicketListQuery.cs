using AutoMapper;
using AutoMapper.QueryableExtensions;
using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.Tickets.Query.GetAllTickets
{
    public class GetHelpdeskTicketListQuery : IRequest<HelpdeskTicketListModel>
    {
        public class Handler : IRequestHandler<GetHelpdeskTicketListQuery, HelpdeskTicketListModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<HelpdeskTicketListModel> Handle(GetHelpdeskTicketListQuery request, CancellationToken cancellationToken)
            {
                return new HelpdeskTicketListModel
                {
                    HelpdeskTickets = await _context.Set<HelpdeskTicket>()
                    .ProjectTo<HelpdeskTicketModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
                };
            }
        }
    }
}