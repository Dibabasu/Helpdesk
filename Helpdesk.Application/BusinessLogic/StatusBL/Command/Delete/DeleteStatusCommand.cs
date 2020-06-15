using Helpdesk.Application.Exceptions;
using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.StatusBL.Command.Delete
{
    public class DeleteStatusCommand : IRequest
    {
        private UserModel UserModel { get; set; }
        public Guid Id { get; set; }

        public bool IsDeleted
        {
            get
            {
                return true;
            }
        }
        public class Handler : IRequestHandler<DeleteStatusCommand>
        {
            private readonly IHelpdeskDbContext _context;

            public Handler(IHelpdeskDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Set<Status>().FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Status), request.Id);
                }

                entity.IsDeleted = request.IsDeleted;
                entity.LastModifiedBy = request.UserModel.UserName;
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

