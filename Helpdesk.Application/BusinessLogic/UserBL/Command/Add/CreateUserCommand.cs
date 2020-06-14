using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Domain.ValueObjects;
using Helpdesk.Model.Models.Create;
using Helpdesk.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.UserBL.Command.Add
{
    public class CreateUserCommand : IRequest
    {
        public UserCreateModel User { get; set; }

        public class CreateCountryCommandHandler : IRequestHandler<CreateUserCommand, Unit>
        {
            private readonly IHelpdeskDbContext _context;

            public CreateCountryCommandHandler(IHelpdeskDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var entity = new User
                {
                    CreatedBy = AdAccount.For(request.User.UserName).UserName,
                    DepartmentName = request.User.DepartmentName,
                    Division = request.User.Division,
                    LastModifiedBy = AdAccount.For(request.User.UserName).UserName,
                    Name = new Name(request.User.FirstMidName, request.User.LastName),
                    AdAccount = AdAccount.For(request.User.UserName),
                };

                _context.Set<User>().Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}