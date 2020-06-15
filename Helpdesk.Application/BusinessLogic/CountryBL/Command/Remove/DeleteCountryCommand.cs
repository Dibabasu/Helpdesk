using Helpdesk.Application.Exceptions;
using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Helpdesk.Application.BusinessLogic.CountryBL.Command.Remove
{
    public class DeleteCountryCommand : IRequest
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
        public class Handler : IRequestHandler<DeleteCountryCommand>
        {
            private readonly IHelpdeskDbContext _context;

            public Handler(IHelpdeskDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Set<Country>().FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Country), request.Id);
                }

                entity.IsDeleted = request.IsDeleted;
                entity.LastModifiedBy = request.UserModel.UserName;
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}