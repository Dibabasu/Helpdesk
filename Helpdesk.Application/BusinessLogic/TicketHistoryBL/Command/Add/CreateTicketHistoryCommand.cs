using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Model.Models.Create;
using Helpdesk.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.TicketHistoryBL.Command.Add
{
   public class CreateTicketHistoryCommand : IRequest
    {
        public TicketHistoryCreateModel TicketHistory { get; set; }
        public UserModel User { get; set; }

        public class CreateCountryCommandHandler : IRequestHandler<CreateTicketHistoryCommand, Unit>
        {
            private readonly IHelpdeskDbContext _context;

            public CreateCountryCommandHandler(IHelpdeskDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CreateTicketHistoryCommand request, CancellationToken cancellationToken)
            {
                var entity = new HelpdeskTicketHistory
                {
                    CreatedBy=request.User.UserName,
                    LastModifiedBy=request.User.UserName,
                    Response=request.TicketHistory.Response,
                    Status=request.TicketHistory.Status,
                    TicketNumber=request.TicketHistory.TicketNumber,
                    TicketId=request.TicketHistory.TicketId,
                    ElapsedTime=request.TicketHistory.ElapsedTime
                };

                _context.Set<HelpdeskTicketHistory>().Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
