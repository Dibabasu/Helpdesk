using Helpdesk.Application.BusinessLogic.LastTicketBL.Command.Add;
using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.LastTicketBL.Query.GetLastTicketByYear
{
    public class GetLastTicketByYearCommand : IRequest<LastTicket>
    {
        public Guid Id { get; set; }

        public class Handler : IRequestHandler<GetLastTicketByYearCommand, LastTicket>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMediator _mediator;
            public Handler(IHelpdeskDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<LastTicket> Handle(
                GetLastTicketByYearCommand request,
                CancellationToken cancellationToken)
            {
                var entity = await _context.Set<LastTicket>()
                 .Where(r => r.Year == DateTime.UtcNow.Year)
                 .FirstOrDefaultAsync();

                if (entity == null)
                {
                    var lastTicket = await _mediator.Send(new AddLastTicketCommand());

                    entity = lastTicket;
                }

                return entity;
            }
        }
    }
}