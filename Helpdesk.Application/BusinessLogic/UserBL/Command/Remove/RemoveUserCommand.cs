using Helpdesk.Application.Exceptions;
using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Helpdesk.Application.BusinessLogic.UserBL.Command.Remove
{
    public class RemoveUserCommand : IRequest
    {
        public String UserName { get; set; }
        public Guid Id { get; set; }

        public bool IsDeleted
        {
            get
            {
                return true;
            }
        }
        public class Handler : IRequestHandler<RemoveUserCommand>
        {
            private readonly IHelpdeskDbContext _context;

            public Handler(IHelpdeskDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Set<User>().FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(User), request.Id);
                }

                entity.IsDeleted = request.IsDeleted;
                entity.LastModifiedBy = request.UserName;
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

