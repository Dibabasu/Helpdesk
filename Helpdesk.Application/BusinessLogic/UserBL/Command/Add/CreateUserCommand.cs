using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Domain.ValueObjects;
using Helpdesk.Model.Models.Create;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.UserBL.Command.Add
{
    public class CreateUserCommand : IRequest
    {
        public Guid UserId { get; set; }
        public String UserName { get; set; }
        public String DepartmentName { get; set; }
        public String Division { get; set; }
        public String FirstMidName { get; set; }
        public String LastName { get; set; }

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
                    CreatedBy = AdAccount.For(request.UserName).UserName,
                    DepartmentName = request.DepartmentName,
                    Division = request.Division,
                    LastModifiedBy = AdAccount.For(request.UserName).UserName,
                    Name = new Name(request.FirstMidName, request.LastName),
                    AdAccount = AdAccount.For(request.UserName),
                };

                _context.Set<User>().Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}