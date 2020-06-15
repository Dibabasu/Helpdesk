using Helpdesk.Application.Exceptions;
using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.IssueSubCatagoryBL.Command.Remove
{
    public class DeleteIssueSubCatagoryCommand : IRequest
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
        public class Handler : IRequestHandler<DeleteIssueSubCatagoryCommand>
        {
            private readonly IHelpdeskDbContext _context;

            public Handler(IHelpdeskDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteIssueSubCatagoryCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Set<IssueSubCatagory>().FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(IssueSubCatagory), request.Id);
                }

                entity.IsDeleted = request.IsDeleted;
                entity.LastModifiedBy = request.UserModel.UserName;
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}