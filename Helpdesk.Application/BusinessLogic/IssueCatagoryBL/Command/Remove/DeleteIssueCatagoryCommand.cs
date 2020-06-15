using Helpdesk.Application.Exceptions;
using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.IssueCatagoryBL.Command.Remove
{
    public class DeleteIssueCatagoryCommand : IRequest
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
        public class Handler : IRequestHandler<DeleteIssueCatagoryCommand>
        {
            private readonly IHelpdeskDbContext _context;

            public Handler(IHelpdeskDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteIssueCatagoryCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Set<IssueCatagory>().FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(IssueCatagory), request.Id);
                }

                entity.IsDeleted = request.IsDeleted;
                entity.LastModifiedBy = request.UserModel.UserName;
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}