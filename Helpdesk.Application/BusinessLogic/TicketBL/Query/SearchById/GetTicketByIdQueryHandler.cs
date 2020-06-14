using AutoMapper;
using AutoMapper.QueryableExtensions;
using Helpdesk.Application.Exceptions;
using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.Tickets.Query.GetTicketById
{
    public class GetTicketByIdQueryHandler : IRequestHandler<GetHelpdeskTicketByIdQuery, HelpdeskTicketModel>
    {
        private readonly IHelpdeskDbContext _context;
        private readonly IMapper _mapper;

        public GetTicketByIdQueryHandler(IHelpdeskDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<HelpdeskTicketModel> Handle(GetHelpdeskTicketByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Set<HelpdeskTicket>()
             .Where(r => r.TicketId == request.Id)
             .ProjectTo<HelpdeskTicketModel>(_mapper.ConfigurationProvider)
             .FirstOrDefaultAsync()
             ;

            if (entity == null)
            {
                throw new NotFoundException(nameof(HelpdeskTicketModel), request.Id);
            }

            return entity;
        }
    }
}