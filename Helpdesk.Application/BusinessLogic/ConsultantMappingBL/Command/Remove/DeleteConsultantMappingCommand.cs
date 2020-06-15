using Helpdesk.Application.Exceptions;
using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Helpdesk.Application.BusinessLogic.ConsultantMappingBL.Command.Remove
{
    public class DeleteConsultantMappingCommand : IRequest
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
        public class Handler : IRequestHandler<DeleteConsultantMappingCommand>
        {
            private readonly IHelpdeskDbContext _context;

            public Handler(IHelpdeskDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteConsultantMappingCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Set<ConsultantMapping>().FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(ConsultantMapping), request.Id);
                }

                entity.IsDeleted = request.IsDeleted;
                entity.LastModifiedBy = request.UserModel.UserName;
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}