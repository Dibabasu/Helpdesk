using Helpdesk.Application.BusinessLogic.LastTicketBL.Command.Add;
using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.LastTicketBL.Command.Update
{
    public class UpdateLastTicketCommand : IRequest
    {

        public long TicketNumber { get; set; }

        public class Handler : IRequestHandler<UpdateLastTicketCommand>
        {
            private readonly IHelpdeskDbContext _context;

            private readonly IMediator _mediator;
            public Handler(IHelpdeskDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(UpdateLastTicketCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Set<LastTicket>()
                    .Where(r => r.Year == DateTime.UtcNow.Year)
                    .FirstOrDefaultAsync();


                if (entity == null)
                {
                    await _mediator.Send(new AddLastTicketCommand());
                }

                entity.LastTicketNo = request.TicketNumber;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
