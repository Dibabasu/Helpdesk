using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.LastTicketBL.Command.Add
{
    class AddLastTicketCommand : IRequest<LastTicket>
    {

        public class Handler : IRequestHandler<AddLastTicketCommand, LastTicket>
        {
            private readonly IHelpdeskDbContext _context;

            public Handler(IHelpdeskDbContext context)
            {
                _context = context;
            }

            public async Task<LastTicket> Handle(
                AddLastTicketCommand request,
                CancellationToken cancellationToken)
            {
                var entity = new LastTicket
                {
                    LastTicketNo = 0,
                    Year = DateTime.UtcNow.Year
                };

                _context.Set<LastTicket>().Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity;
            }
        }
    }
}