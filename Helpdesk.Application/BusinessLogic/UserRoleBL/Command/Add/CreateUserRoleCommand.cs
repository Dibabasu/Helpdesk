using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.UserRoleBL.Command.Add
{
    public class CreateUserRoleCommand : IRequest
    {
        public UserRoleModel UserRoleModel { get; set; }

        public class CreateCountryCommandHandler : IRequestHandler<CreateUserRoleCommand, Unit>
        {
            private readonly IHelpdeskDbContext _context;

            public CreateCountryCommandHandler(IHelpdeskDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
            {
                var entity = new UserRole
                {
                    CreatedBy = "Admin",
                    LastModifiedBy = "Admin",
                    Role = request.UserRoleModel.Role,
                    UserId = request.UserRoleModel.UserId
                };

                _context.Set<UserRole>().Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}