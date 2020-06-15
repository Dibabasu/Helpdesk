using Helpdesk.Application.Exceptions;
using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.IssueTypeBL.Command.Remove
{
    class DeleteIssueTypeCommand : IRequest
    {
        public Guid Id { get; set; }
        public UserModel UserModel { get; set; }
        public bool IsDeleted
        {
            get
            {
                return true;
            }
        }
        public class Handler : IRequestHandler<DeleteIssueTypeCommand>
        {
            private readonly IHelpdeskDbContext _context;

            public Handler(IHelpdeskDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteIssueTypeCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Set<IssueType>().FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(IssueType), request.Id);
                }

                entity.IsDeleted = request.IsDeleted;
                entity.LastModifiedBy = request.UserModel.UserName;
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}